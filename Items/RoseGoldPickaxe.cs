using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items;

namespace BounceBack.Items
{
	public class RoseGoldPickaxe : ModItem
	{
		public override void SetStaticDefaults() {
		//	Tooltip.SetDefault("");
		}

		public override void SetDefaults() {
			item.damage = 7;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 25;
			item.useAnimation = 10;
			item.pick = 65;
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