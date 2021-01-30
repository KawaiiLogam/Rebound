using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BounceBack.Tiles
{
	public class OryxPosterTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileShine[Type] = 800;
			Main.tileSolid[Type] = false;
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
		}
		public override bool Drop(int i, int j)
		{
			Tile t = Main.tile[i, j];
			int style = t.frameX / 18;
			if (style == 0) // It can be useful to share a single tile with multiple styles. This code will let you drop the appropriate bar if you had multiple.
			{
				Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeable.OryxPoster>());
			}
			return base.Drop(i, j);
		}
	}
}