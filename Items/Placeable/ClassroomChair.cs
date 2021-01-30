using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Placeable
{
	public class ClassroomChair : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("For use in classrooms");
		}

		public override void SetDefaults() {
			item.width = 16;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.value = 1000;
			item.createTile = ModContent.TileType<Tiles.ClassroomChairTile>();
		}
	}
}