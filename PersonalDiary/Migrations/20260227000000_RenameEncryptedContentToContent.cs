using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalDiary.Migrations
{
    /// <inheritdoc />
    public partial class RenameEncryptedContentToContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EncryptedContent",
                table: "DiaryEntries",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "DiaryEntries",
                newName: "EncryptedContent");
        }
    }
}
