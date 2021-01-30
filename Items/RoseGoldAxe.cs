using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items
{
	public class RoseGoldAxe : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("If it's going down, yell timber");
		}

		public override void SetDefaults() {
			item.damage = 9;
			item.melee = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 15;
			item.useAnimation = 15;
			item.axe = 30;          //How much axe power the weapon has, note that the axe power displayed in-game is this value multiplied by 5
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 1000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RoseGoldBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}