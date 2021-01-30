using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items
{
	public class BoundiumBar : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Boundium Bar");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 24;
			item.maxStack = 999;
			item.value = 20000;
			item.rare = ItemRarityID.Orange;
		}
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<BoundiumOre>(), 3);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
