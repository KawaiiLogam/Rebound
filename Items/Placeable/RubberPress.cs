using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;

namespace BounceBack.Items.Placeable
{
	public class RubberPress : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Used for making bouncy balls and other materials.");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 150;
			item.createTile = ModContent.TileType<Tiles.RubberPressTile>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient(ModContent.ItemType<RubberBand>(), 60);
			recipe.AddRecipeGroup("IronBar", 12);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}