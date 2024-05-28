using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCDemo.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseResultTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<float>(type: "real", nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Trainee_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseResult_Course_Course_Id",
                        column: x => x.Course_Id,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CourseResult_Trainee_Trainee_Id",
                        column: x => x.Trainee_Id,
                        principalTable: "Trainee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_Course_Id",
                table: "CourseResult",
                column: "Course_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseResult_Trainee_Id",
                table: "CourseResult",
                column: "Trainee_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseResult");
        }
    }
}
