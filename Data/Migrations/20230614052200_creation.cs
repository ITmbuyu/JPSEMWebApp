using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPSEMWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessPackages",
                columns: table => new
                {
                    BusinessPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RedundancyPrice = table.Column<double>(type: "float", nullable: false),
                    InstallationPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPackages", x => x.BusinessPackageId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmpSurname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmpEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmpPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeRole = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdPackages",
                columns: table => new
                {
                    HouseholdPackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdPackages", x => x.HouseholdPackageId);
                });

            migrationBuilder.CreateTable(
                name: "LtePackages",
                columns: table => new
                {
                    LtePackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InstallationPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LtePackages", x => x.LtePackageId);
                });

            migrationBuilder.CreateTable(
                name: "Routers",
                columns: table => new
                {
                    RouterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    OnceOffPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routers", x => x.RouterId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPackages");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "HouseholdPackages");

            migrationBuilder.DropTable(
                name: "LtePackages");

            migrationBuilder.DropTable(
                name: "Routers");
        }
    }
}
