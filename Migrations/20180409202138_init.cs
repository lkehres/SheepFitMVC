using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sheep.Site.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    sheepDOB = table.Column<DateTime>(nullable: false),
                    sheepGender = table.Column<char>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pregnancies",
                columns: table => new
                {
                    pregnancyID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    actBirth = table.Column<string>(nullable: true),
                    conceptionDate = table.Column<string>(nullable: true),
                    estBirth = table.Column<string>(nullable: true),
                    numberOfBabies = table.Column<int>(nullable: false),
                    pregnancyComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregnancies", x => x.pregnancyID);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    treatmentID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    treatmentComment = table.Column<string>(nullable: true),
                    treatmentDate = table.Column<DateTime>(nullable: false),
                    treatmentDosage = table.Column<string>(nullable: true),
                    treatmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.treatmentID);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    vaccineID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    vaccineComment = table.Column<string>(nullable: true),
                    vaccineDate = table.Column<DateTime>(nullable: false),
                    vaccineDosage = table.Column<string>(nullable: true),
                    vaccineName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.vaccineID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Pregnancies");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Vaccines");
        }
    }
}
