using Microsoft.EntityFrameworkCore.Migrations;

namespace DylanThierbachCsharpExam.Migrations
{
    public partial class CreatedActivsAndParticipantsDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activ_Users_UserId",
                table: "Activ");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Activ_ActivId",
                table: "Participant");

            migrationBuilder.DropForeignKey(
                name: "FK_Participant_Users_UserId",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participant",
                table: "Participant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activ",
                table: "Activ");

            migrationBuilder.RenameTable(
                name: "Participant",
                newName: "Participants");

            migrationBuilder.RenameTable(
                name: "Activ",
                newName: "Activs");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_UserId",
                table: "Participants",
                newName: "IX_Participants_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participant_ActivId",
                table: "Participants",
                newName: "IX_Participants_ActivId");

            migrationBuilder.RenameIndex(
                name: "IX_Activ_UserId",
                table: "Activs",
                newName: "IX_Activs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "ParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activs",
                table: "Activs",
                column: "ActivId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activs_Users_UserId",
                table: "Activs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Activs_ActivId",
                table: "Participants",
                column: "ActivId",
                principalTable: "Activs",
                principalColumn: "ActivId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activs_Users_UserId",
                table: "Activs");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Activs_ActivId",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Users_UserId",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Activs",
                table: "Activs");

            migrationBuilder.RenameTable(
                name: "Participants",
                newName: "Participant");

            migrationBuilder.RenameTable(
                name: "Activs",
                newName: "Activ");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_UserId",
                table: "Participant",
                newName: "IX_Participant_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Participants_ActivId",
                table: "Participant",
                newName: "IX_Participant_ActivId");

            migrationBuilder.RenameIndex(
                name: "IX_Activs_UserId",
                table: "Activ",
                newName: "IX_Activ_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participant",
                table: "Participant",
                column: "ParticipantId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activ",
                table: "Activ",
                column: "ActivId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activ_Users_UserId",
                table: "Activ",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Activ_ActivId",
                table: "Participant",
                column: "ActivId",
                principalTable: "Activ",
                principalColumn: "ActivId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participant_Users_UserId",
                table: "Participant",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
