using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace BounceBack.Tiles
{
	public class RoseGoldOreTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSpelunker[Type] = true; // The tile will be affected by spelunker highlighting
			Main.tileValue[Type] = 450; // Metal Detector value, see https://terraria.gamepedia.com/Metal_Detector
			Main.tileShine2[Type] = true; // Modifies the draw color slightly.
			Main.tileShine[Type] = 975; // How often tiny dust appear off this tile. Larger is less frequently
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			drop = ModContent.ItemType<Items.Placeable.RoseGoldOre>();
			AddMapEntry(new Color(179, 107, 118));
			mineResist = 2f;
			minPick = 65;
		}
		public override bool CanExplode(int i, int j)
		{
			return false;
		}

	}
}