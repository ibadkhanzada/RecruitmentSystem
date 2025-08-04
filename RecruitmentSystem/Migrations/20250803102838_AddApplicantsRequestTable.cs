using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitmentSystem.Migrations
{
    public partial class AddApplicantsRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantsRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaOfExpertise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    LinkedInProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CvFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantsRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantsRequests");
        }
    }
}
