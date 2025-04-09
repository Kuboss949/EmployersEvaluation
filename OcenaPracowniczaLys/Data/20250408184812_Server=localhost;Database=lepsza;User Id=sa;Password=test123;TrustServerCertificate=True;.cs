using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OcenaPracowniczaLys.Data
{
    /// <inheritdoc />
    public partial class ServerlocalhostDatabaselepszaUserIdsaPasswordtest123TrustServerCertificateTrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__departme__B2079BCD09D70254", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "evaluationbiuro",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Question1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question5 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question6 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    EvaluatorNameID = table.Column<int>(type: "int", nullable: false),
                    Question10 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question11 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question7 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question8 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question9 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    EvaluationAnswerID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Stanowisko = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evaluati__36AE68D384D55F66", x => x.EvaluationID)
                        .Annotation("SqlServer:FillFactor", 1);
                });

            migrationBuilder.CreateTable(
                name: "evaluationbiuroanswers",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question5 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question6 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question7 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question8 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question9 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question10 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question11 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evaluati__36AE68D31E8108F0", x => x.EvaluationID);
                });

            migrationBuilder.CreateTable(
                name: "evaluationnames",
                columns: table => new
                {
                    EvaluatorNameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvaluatorName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evaluati__0892287A98BA4AF3", x => x.EvaluatorNameID);
                });

            migrationBuilder.CreateTable(
                name: "evaluationprodukcjaanswers",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question5 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evaluati__36AE68D325F5EC39", x => x.EvaluationID);
                });

            migrationBuilder.CreateTable(
                name: "evaluationsprodukcja",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EvaluatorNameID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Question1 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question2 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question3 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Question4 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    EvaluationAnswerID = table.Column<int>(type: "int", nullable: false),
                    Question5 = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Stanowisko = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evaluati__36AE68D31B5E548B", x => x.EvaluationID);
                });

            migrationBuilder.CreateTable(
                name: "globalsettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CurrentEvaluationName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__globalse__3214EC07F78B72CF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Login = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true, defaultValueSql: "(NULL)"),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__1788CCAC279B5EBA", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_users_roles",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "evaluationbiuro");

            migrationBuilder.DropTable(
                name: "evaluationbiuroanswers");

            migrationBuilder.DropTable(
                name: "evaluationnames");

            migrationBuilder.DropTable(
                name: "evaluationprodukcjaanswers");

            migrationBuilder.DropTable(
                name: "evaluationsprodukcja");

            migrationBuilder.DropTable(
                name: "globalsettings");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
