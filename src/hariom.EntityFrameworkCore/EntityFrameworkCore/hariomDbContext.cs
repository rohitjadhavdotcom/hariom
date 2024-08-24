using Hariom.Diseases;
using Hariom.Mantras;
using Hariom.Medicines;
using Hariom.TreatmentDiseaseMaps;
using Hariom.TreatmentMantraMaps;
using Hariom.TreatmentMedicineMaps;
using Hariom.Treatments;
using Hariom.TreatmentYogTherapyMaps;
using Hariom.YogTherapies;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Hariom.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class HariomDbContext :
    AbpDbContext<HariomDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    public DbSet<Disease> Diseases { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Mantra> Mantras { get; set; }
    public DbSet<YogTherapy> YogTherapies { get; set; }
    public DbSet<Treatment> Treatments { get; set; }

    public DbSet<TreatmentDiseaseMap> TreatmentDiseaseMaps { get; set; }
    public DbSet<TreatmentMantraMap> TreatmentMantraMaps { get; set; }
    public DbSet<TreatmentMedicineMap> TreatmentMedicineMaps { get; set; }
    public DbSet<TreatmentYogTherapyMap> TreatmentYogTherapyMaps { get; set; }
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public HariomDbContext(DbContextOptions<HariomDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /* Include modules to your migration db context */

        modelBuilder.ConfigurePermissionManagement();
        modelBuilder.ConfigureSettingManagement();
        modelBuilder.ConfigureBackgroundJobs();
        modelBuilder.ConfigureAuditLogging();
        modelBuilder.ConfigureIdentity();
        modelBuilder.ConfigureOpenIddict();
        modelBuilder.ConfigureFeatureManagement();
        modelBuilder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        modelBuilder.Entity<Disease>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "Diseases",
                HariomConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Medicine>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "Medicines",
                HariomConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Mantra>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "Mantras",
                HariomConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);
        });

        modelBuilder.Entity<YogTherapy>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "YogTherapies",
                HariomConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.YogopcharCategory)
                .IsRequired()
                .HasMaxLength(500);
            b.Property(x => x.YogopcharTherapy)
                .IsRequired()
                .HasMaxLength(500);
        });


        modelBuilder.Entity<Treatment>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "Treatments",
                HariomConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.AboutDisease)
                .HasMaxLength(TreatmentConsts.MaxAboutDiseaseLength);
            b.Property(x => x.DiseaseSymptoms)
                .HasMaxLength(TreatmentConsts.MaxDiseaseSymptomsLength)
                .IsRequired(false);
            b.Property(x => x.DiseaseCauses)
                .HasMaxLength(TreatmentConsts.MaxDiseaseCausesLength)
                .IsRequired(false);
            b.Property(x => x.DiseaseDiagnose).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxDiseaseDiagnoseLength);
            b.Property(x => x.MedicineDescription)
                .IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxMedicineDescriptionLength);
            b.Property(x => x.MantraDescription).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxMantraDescriptionLength);
            b.Property(x => x.YogupcharDescription).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxYogupcharDescriptionLength);
            b.Property(x => x.OtherRemedies).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxOtherRemediesLength);
            b.Property(x => x.ImmediateTreatment).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxImmediateTreatmentLength);

            b.Property(x => x.PathyaAahar).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxPathyaAaharLinkLength);
            b.Property(x => x.PathyaVihar).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxPathyaViharLinkLength);
            b.Property(x => x.ApathyaAahar).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxApathyaAaharLinkLength);
            b.Property(x => x.ApathyaVihar).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxApathyaViharLinkLength);

            b.Property(x => x.SantsangLink).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxImmediateTreatmentLength);
            b.Property(x => x.SadhakAnubhavLink).IsRequired(false)
                .HasMaxLength(TreatmentConsts.MaxSadhakAnubhavLinkLength);
        });


        modelBuilder.Entity<TreatmentDiseaseMap>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "TreatmentDiseaseMaps", HariomConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Treatment>().WithMany().HasForeignKey(x => x.TreatmentId).IsRequired();
            b.HasOne<Disease>().WithMany().HasForeignKey(x => x.DiseaseId).IsRequired();
        });

        modelBuilder.Entity<TreatmentMantraMap>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "TreatmentMantraMaps", HariomConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Treatment>().WithMany().HasForeignKey(x => x.TreatmentId).IsRequired();
            b.HasOne<Mantra>().WithMany().HasForeignKey(x => x.MantraId).IsRequired();
        });

        modelBuilder.Entity<TreatmentMedicineMap>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "TreatmentMedicineMaps", HariomConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Treatment>().WithMany().HasForeignKey(x => x.TreatmentId).IsRequired();
            b.HasOne<Medicine>().WithMany().HasForeignKey(x => x.MedicineId).IsRequired();
        });

        modelBuilder.Entity<TreatmentYogTherapyMap>(b =>
        {
            b.ToTable(HariomConsts.DbTablePrefix + "TreatmentYogTherapyMaps", HariomConsts.DbSchema);
            b.ConfigureByConvention();
            b.HasOne<Treatment>().WithMany().HasForeignKey(x => x.TreatmentId).IsRequired();
            b.HasOne<YogTherapy>().WithMany().HasForeignKey(x => x.YogTherapyId).IsRequired();
        });
    }
}
