using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JPSEMWebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class airandmessageupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirfibrePackages",
                columns: table => new
                {
                    AirfibrePackageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    InstallationPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirfibrePackages", x => x.AirfibrePackageId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceNotices",
                columns: table => new
                {
                    ServiceNoticeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceNotices", x => x.ServiceNoticeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirfibrePackages");

            migrationBuilder.DropTable(
                name: "ServiceNotices");
        }
    }
}
