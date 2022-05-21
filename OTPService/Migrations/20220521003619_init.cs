using Microsoft.EntityFrameworkCore.Migrations;

namespace OTPService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Verification",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    OTPCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Verification", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Verification");
        }
    }
}
