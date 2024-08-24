using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hariom.Migrations
{
    /// <inheritdoc />
    public partial class created_treatments_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTreatments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AboutDisease = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DiseaseSymptoms = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DiseaseCauses = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    DiseaseDiagnose = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    MedicineDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    MantraDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    YogupcharDescription = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    OtherRemedies = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ImmediateTreatment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PathyaAahar = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PathyaVihar = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ApathyaAahar = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ApathyaVihar = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    SantsangLink = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    SadhakAnubhavLink = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTreatments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTreatments");
        }
    }
}
