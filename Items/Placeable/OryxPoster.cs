using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Placeable
{
	public class OryxPoster : ModItem
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 42;
			item.maxStack = 99;
			item.value = 600;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.OryxPosterTile>();
			item.placeStyle = 0;
		}
	}
}