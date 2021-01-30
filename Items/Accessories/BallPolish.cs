using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace BounceBack.Items.Accessories
{
	public class BallPolish : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ball Polish");
			Tooltip.SetDefault("Increases resilience damage by 8%");
		}
		public override void SetDefaults() {
			item.width = 48;
			item.height = 48;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 30);
			item.rare = ItemRarityID.Green;
		}

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
		player.GetModPlayer<BouncePlayer>().ballPolish = true;
        }
	}
}