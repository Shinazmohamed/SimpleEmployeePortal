using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeePortal.Migrations
{
    public partial class InitEmployeeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    E1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    E2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    M1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    M2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmployee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbEmployee");
        }
    }
}
