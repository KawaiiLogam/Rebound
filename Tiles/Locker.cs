using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Placeable
{
	public class Locker : ModItem
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 72;
			item.maxStack = 99;
			item.value = 1000;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.LockerTile>();
			item.placeStyle = 0;
		}
	}
}