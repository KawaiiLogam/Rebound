using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items
{
	public class BoundiumOre : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Boundium Ore");
			Tooltip.SetDefault("Chunks of raw metal from another world");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.maxStack = 999;
			item.value = 500;
			item.rare = ItemRarityID.Orange;
		}
	}
}
