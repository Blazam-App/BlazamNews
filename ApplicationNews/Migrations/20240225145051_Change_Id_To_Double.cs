using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationNews.Migrations
{
    /// <inheritdoc />
    public partial class Change_Id_To_Double : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Id",
                table: "NewsItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "NewsItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
