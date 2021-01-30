using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Placeable
{
	public class ClassroomDesk : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Full of pencils and dyed glue");
		}

		public override void SetDefaults() {
			item.width = 36;
			item.height = 20;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 1000;
			item.createTile = ModContent.TileType<Tiles.ClassroomDeskTile>();
		}
	}
}