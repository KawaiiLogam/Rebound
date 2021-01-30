using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Placeable;

namespace BounceBack.Items
{
	public class RoseGoldBar : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rose Gold Bar");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 24;
			item.maxStack = 999;
			item.value = 2000;
			item.rare = ItemRarityID.Blue;
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RoseGoldOre>(), 4);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
