using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace BounceBack.Tiles
{
	public class LockerTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileSolidTop[Type] = true;
			Main.tileFrameImportant[Type] = true;
			//Main.tileNoAttach[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			//TileObjectData.newTile.Height = 4; // because the template is for 1x2 not 1x3
			//								   //TileObjectData.newTile.Width = 4; // because height changed
			//TileObjectData.newTile.CoordinateHeights = new int[] { 24, 24, 24, 24 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(Type);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeable.Locker>());
		}
	}
}