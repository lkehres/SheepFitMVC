using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sheep.Site.Api.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Vaccines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Treatments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Pregnancies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_AnimalId",
                table: "Vaccines",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_AnimalId",
                table: "Treatments",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregnancies_AnimalId",
                table: "Pregnancies",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pregnancies_Animals_AnimalId",
                table: "Pregnancies",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_Animals_AnimalId",
                table: "Vaccines",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pregnancies_Animals_AnimalId",
                table: "Pregnancies");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Animals_AnimalId",
                table: "Treatments");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_Animals_AnimalId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_AnimalId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_AnimalId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Pregnancies_AnimalId",
                table: "Pregnancies");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                table: "Pregnancies");
        }
    }
}
