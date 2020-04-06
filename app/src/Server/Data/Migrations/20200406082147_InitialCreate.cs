using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerChurn.Server.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(10)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(6)", nullable: true),
                    SeniorCitizen = table.Column<bool>(nullable: false),
                    Partner = table.Column<bool>(nullable: false),
                    Dependents = table.Column<bool>(nullable: false),
                    Tenure = table.Column<int>(nullable: false),
                    PhoneService = table.Column<string>(type: "varchar(13)", nullable: false),
                    MultipleLines = table.Column<string>(type: "varchar(13)", nullable: false),
                    InternetService = table.Column<string>(type: "varchar(13)", nullable: false),
                    OnlineSecurity = table.Column<string>(type: "varchar(13)", nullable: false),
                    OnlineBackup = table.Column<string>(type: "varchar(13)", nullable: false),
                    DeviceProtection = table.Column<string>(type: "varchar(13)", nullable: false),
                    TechSupport = table.Column<string>(type: "varchar(13)", nullable: false),
                    StreamingTV = table.Column<string>(type: "varchar(13)", nullable: false),
                    StreamingMovies = table.Column<string>(type: "varchar(13)", nullable: false),
                    Contract = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaperlessBilling = table.Column<bool>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: false),
                    MonthlyCharges = table.Column<decimal>(type: "money", nullable: false),
                    TotalCharges = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
