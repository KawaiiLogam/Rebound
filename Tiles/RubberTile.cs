using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace BounceBack.Tiles
{
	public class RubberTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			drop = ModContent.ItemType<Items.Placeable.Rubber>();
			AddMapEntry(new Color(200, 200, 200));
		}
	}
}