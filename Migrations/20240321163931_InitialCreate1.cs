using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsersInsurancePolicies.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePolicy_User_UserID",
                table: "InsurancePolicy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePolicy",
                table: "InsurancePolicy");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "InsurancePolicy",
                newName: "InsurancePolicies");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePolicy_UserID",
                table: "InsurancePolicies",
                newName: "IX_InsurancePolicies_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies",
                column: "InsurancePolicyID");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePolicies_Users_UserID",
                table: "InsurancePolicies",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsurancePolicies_Users_UserID",
                table: "InsurancePolicies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsurancePolicies",
                table: "InsurancePolicies");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "InsurancePolicies",
                newName: "InsurancePolicy");

            migrationBuilder.RenameIndex(
                name: "IX_InsurancePolicies_UserID",
                table: "InsurancePolicy",
                newName: "IX_InsurancePolicy_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsurancePolicy",
                table: "InsurancePolicy",
                column: "InsurancePolicyID");

            migrationBuilder.AddForeignKey(
                name: "FK_InsurancePolicy_User_UserID",
                table: "InsurancePolicy",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
