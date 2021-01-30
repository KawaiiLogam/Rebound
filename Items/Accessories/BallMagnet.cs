using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace BounceBack.Items.Accessories
{
	public class BallMagnet : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ball Magnet");
			Tooltip.SetDefault("Bouncy Balls will return to you after being thrown");
		}
		public override void SetDefaults() {
			item.width = 48;
			item.height = 48;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
		player.GetModPlayer<BouncePlayer>().ballMagnet = true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MetalBallBearing>(), 1);
			recipe.AddIngredient(ItemID.Meteorite, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}