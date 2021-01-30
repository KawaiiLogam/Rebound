using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Placeable
{
	public class SchoolGirlPoster : ModItem
	{
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			item.width = 36;
			item.height = 44;
			item.maxStack = 99;
			item.value = 300;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = ModContent.TileType<Tiles.SchoolGirlPosterTile>();
			item.placeStyle = 0;
		}
	}
}