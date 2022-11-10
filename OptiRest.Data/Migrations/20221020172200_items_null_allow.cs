using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Data.Migrations
{
    public partial class items_null_allow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCategoryId",
                table: "ItemCategories");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_TenantId",
                table: "Tables",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_UserId",
                table: "Tables",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_KitchenId",
                table: "Items",
                column: "KitchenId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessConfigs_TenantId",
                table: "BusinessConfigs",
                column: "TenantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessConfigs_Tenants_TenantId",
                table: "BusinessConfigs",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Kitchens_KitchenId",
                table: "Items",
                column: "KitchenId",
                principalTable: "Kitchens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Tenants_TenantId",
                table: "Tables",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Users_UserId",
                table: "Tables",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessConfigs_Tenants_TenantId",
                table: "BusinessConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Kitchens_KitchenId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Tenants_TenantId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Users_UserId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_TenantId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_UserId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Items_KitchenId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_BusinessConfigs_TenantId",
                table: "BusinessConfigs");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryId",
                table: "ItemCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
