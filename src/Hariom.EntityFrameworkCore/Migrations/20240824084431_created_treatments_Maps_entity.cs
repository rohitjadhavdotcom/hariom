using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hariom.Migrations
{
    /// <inheritdoc />
    public partial class created_treatments_Maps_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTreatmentDiseaseMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTreatmentDiseaseMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTreatmentDiseaseMaps_AppDiseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "AppDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTreatmentDiseaseMaps_AppTreatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "AppTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTreatmentMantraMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    MantraId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTreatmentMantraMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTreatmentMantraMaps_AppMantras_MantraId",
                        column: x => x.MantraId,
                        principalTable: "AppMantras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTreatmentMantraMaps_AppTreatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "AppTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTreatmentMedicineMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicineId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTreatmentMedicineMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTreatmentMedicineMaps_AppMedicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "AppMedicines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTreatmentMedicineMaps_AppTreatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "AppTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTreatmentYogTherapyMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    YogTherapyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTreatmentYogTherapyMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTreatmentYogTherapyMaps_AppTreatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "AppTreatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTreatmentYogTherapyMaps_AppYogTherapies_YogTherapyId",
                        column: x => x.YogTherapyId,
                        principalTable: "AppYogTherapies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentDiseaseMaps_DiseaseId",
                table: "AppTreatmentDiseaseMaps",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentDiseaseMaps_TreatmentId",
                table: "AppTreatmentDiseaseMaps",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentMantraMaps_MantraId",
                table: "AppTreatmentMantraMaps",
                column: "MantraId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentMantraMaps_TreatmentId",
                table: "AppTreatmentMantraMaps",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentMedicineMaps_MedicineId",
                table: "AppTreatmentMedicineMaps",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentMedicineMaps_TreatmentId",
                table: "AppTreatmentMedicineMaps",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentYogTherapyMaps_TreatmentId",
                table: "AppTreatmentYogTherapyMaps",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatmentYogTherapyMaps_YogTherapyId",
                table: "AppTreatmentYogTherapyMaps",
                column: "YogTherapyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTreatmentDiseaseMaps");

            migrationBuilder.DropTable(
                name: "AppTreatmentMantraMaps");

            migrationBuilder.DropTable(
                name: "AppTreatmentMedicineMaps");

            migrationBuilder.DropTable(
                name: "AppTreatmentYogTherapyMaps");
        }
    }
}
