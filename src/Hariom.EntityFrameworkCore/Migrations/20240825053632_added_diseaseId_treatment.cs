using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hariom.Migrations
{
    /// <inheritdoc />
    public partial class added_diseaseId_treatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiseaseId",
                table: "AppTreatments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppTreatments_DiseaseId",
                table: "AppTreatments",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTreatments_AppDiseases_DiseaseId",
                table: "AppTreatments",
                column: "DiseaseId",
                principalTable: "AppDiseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTreatments_AppDiseases_DiseaseId",
                table: "AppTreatments");

            migrationBuilder.DropIndex(
                name: "IX_AppTreatments_DiseaseId",
                table: "AppTreatments");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "AppTreatments");
        }
    }
}
