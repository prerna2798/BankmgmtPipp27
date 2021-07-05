using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthServiceProject.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLoans",
                columns: table => new
                {
                    UId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoanAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplyDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RateOfInterest = table.Column<int>(type: "int", nullable: false),
                    LoanDuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseFee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOcc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherExp = table.Column<int>(type: "int", nullable: false),
                    RationCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherInc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualIncome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalExp = table.Column<int>(type: "int", nullable: false),
                    CurrExp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoans", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuardianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citizenship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CitizenStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitDeposit = table.Column<int>(type: "int", nullable: false),
                    IdentityProof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UId);
                });

            migrationBuilder.InsertData(
                table: "UserLoans",
                columns: new[] { "UId", "AnnualIncome", "ApplyDate", "CompanyName", "CourseFee", "CourseName", "CurrExp", "Desig", "FatherExp", "FatherInc", "FatherName", "FatherOcc", "LoanAmount", "LoanDuration", "LoanType", "RateOfInterest", "RationCard", "TotalExp" },
                values: new object[] { "R-000", "400000", "01-01-2021", "Cognizant", null, null, 1, "PAT", 0, null, null, null, "300000", "5", "personal", 10, null, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UId", "AccountNumber", "AccountType", "Address", "Age", "BranchName", "CitizenStatus", "Citizenship", "ConfirmPassword", "Contact", "Country", "Dob", "Email", "Gender", "GuardianName", "GuardianType", "IdentityProof", "InitDeposit", "MaritalStatus", "Pan", "Password", "RefAccountNo", "RefAddress", "RefName", "State", "UserName" },
                values: new object[] { "R-000", "6700345528779000", "Savings", "45 Church Road Los Angeles", 21, "Alaska", "Normal", "Other", "P@ssw0rd", "8811209877", "USA", "2000-01-16", "thomas234@gmail.com", "Male", "Steve Jacob", "Father", "Aadhaar", 5000, "Single", "1234tytt4987", "P@ssw0rd", "5600063211678820", "23 Wiston Road Alaska", "Martin P", "Alaska", "Thomas Jacob" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLoans");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
