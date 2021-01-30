using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Tiles;

namespace BounceBack.Items.Placeable
{
	public class RoseGoldOre : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rose Gold Ore");
			Tooltip.SetDefault("Extremely chic");
		}

		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.maxStack = 999;
			item.value = 50;
			item.rare = ItemRarityID.Blue;
			item.createTile = ModContent.TileType<RoseGoldOreTile>();
		}
	}
}
