using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptiRest.Data.Migrations
{
    public partial class ItemCategoriesFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Items",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "tenantId",
                table: "Items",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "summary",
                table: "Items",
                newName: "Summary");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "kitchenId",
                table: "Items",
                newName: "KitchenId");

            migrationBuilder.RenameColumn(
                name: "code",
                table: "Items",
                newName: "Code");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Items",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Items",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "ItemCategoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Items",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Items",
                newName: "tenantId");

            migrationBuilder.RenameColumn(
                name: "Summary",
                table: "Items",
                newName: "summary");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "KitchenId",
                table: "Items",
                newName: "kitchenId");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Items",
                newName: "code");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Items",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "ItemCategoryId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategories_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId",
                principalTable: "ItemCategories",
                principalColumn: "Id");
        }
    }
}
