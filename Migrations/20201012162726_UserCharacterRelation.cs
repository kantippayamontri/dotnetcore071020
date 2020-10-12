using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetcore31_071020.Migrations
{
    public partial class UserCharacterRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) // defind in database
        {
            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Character",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Character_userId",
                table: "Character",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Users_userId",
                table: "Character",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                //onDelete: ReferentialAction.Restrict ,//mean you cant delete a user when user have Character in database 
                onDelete: ReferentialAction.Cascade // mean Character will be deleted if the user would be deleted 
                ); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Users_userId",
                table: "Character");

            migrationBuilder.DropIndex(
                name: "IX_Character_userId",
                table: "Character");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Character");
        }
    }
}
