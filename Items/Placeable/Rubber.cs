using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;
using BounceBack.Tiles;

namespace BounceBack.Items.Placeable
{
	public class Rubber : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A springy material");

		}

		public override void SetDefaults() {
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<RubberTile>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RubberBand>(), 6);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
