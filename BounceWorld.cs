using BounceBack.Items;
using BounceBack.NPCs;
using BounceBack.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace BounceBack
{
	public class BounceWorld : ModWorld
	{
		public static bool downedRebound;

		public override void Initialize() {
			downedRebound = false;
		}

		public override TagCompound Save() {
			var downed = new List<string>();
			if (downedRebound) {
				downed.Add("rebound");
			}

			//if (downedPuritySpirit) {
			//	downed.Add("puritySpirit");
			//}

			return new TagCompound {
				["downed"] = downed,
			//	["traveler"] = ExampleTravelingMerchant.Save()
			};
		}

		public override void Load(TagCompound tag) {
			var downed = tag.GetList<string>("downed");
			downedRebound = downed.Contains("rebound");
		//	downedPuritySpirit = downed.Contains("puritySpirit");
		//	ExampleTravelingMerchant.Load(tag.GetCompound("traveler"));
		}

		public override void LoadLegacy(BinaryReader reader) {
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0) {
				BitsByte flags = reader.ReadByte();
				downedRebound = flags[0];
			//	downedPuritySpirit = flags[1];
			}
			else {
				mod.Logger.WarnFormat("ExampleMod: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer) {
			var flags = new BitsByte();
			flags[0] = downedRebound;
		//	flags[1] = downedPuritySpirit;
			writer.Write(flags);

			/*
			Remember that Bytes/BitsByte only have 8 entries. If you have more than 8 flags you want to sync, use multiple BitsByte:

				This is wrong:
			flags[8] = downed9thBoss; // an index of 8 is nonsense. 

				This is correct:
			flags[7] = downed8thBoss;
			writer.Write(flags);
			BitsByte flags2 = new BitsByte(); // create another BitsByte
			flags2[0] = downed9thBoss; // start again from 0
			// up to 7 more flags here
			writer.Write(flags2); // write this byte
			*/

			//If you prefer, you can use the BitsByte constructor approach as well.
			//writer.Write(saveVersion);
			//BitsByte flags = new BitsByte(downedAbomination, downedPuritySpirit);
			//writer.Write(flags);

			// This is another way to do the same thing, but with bitmasks and the bitwise OR assignment operator (the |=)
			// Note that 1 and 2 here are bit masks. The next values in the pattern are 4,8,16,32,64,128. If you require more than 8 flags, make another byte.
			//writer.Write(saveVersion);
			//byte flags = 0;
			//if (downedAbomination)
			//{
			//	flags |= 1;
			//}
			//if (downedPuritySpirit)
			//{
			//	flags |= 2;
			//}
			//writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader) {
			BitsByte flags = reader.ReadByte();
			downedRebound = flags[0];
			//downedPuritySpirit = flags[1];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}
		
		// We use this hook to add 3 steps to world generation at various points. 
		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				// Next, we insert our step directly after the original "Shinies" step. 
				// ExampleModOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("BounceBackOres", BounceBackOres));
			}

			// This second step that we add will go after "Traps" and follows the same pattern.
			//int TrapsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Traps"));
			//if (TrapsIndex != -1) {
			//	tasks.Insert(TrapsIndex + 1, new PassLegacy("Example Mod Traps", ExampleModTraps));
			//}

			//int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
			//if (LivingTreesIndex != -1) {
			//	tasks.Insert(LivingTreesIndex + 1, new PassLegacy("Post Terrain", delegate (GenerationProgress progress) {
			//		// We can inline the world generation code like this, but if exceptions happen within this code 
					// the error messages are difficult to read, so making methods is better. This is called an anonymous method.
			//		progress.Message = "Adding Chic";
			//		MakeWells();
			//	}));
			//}
		}

		private void BounceBackOres(GenerationProgress progress) {
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Adding Chic";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<RoseGoldOreTile>());

				// Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
				// Tile tile = Framing.GetTileSafely(x, y);
				// if (tile.active() && tile.type == TileID.SnowBlock)
				// {
				// 	WorldGen.TileRunner(.....);
				// }
			}
		}

		/*private void ExampleModTraps(GenerationProgress progress) {
			progress.Message = "Example Mod Traps";

			// Computers are fast, so WorldGen code sometimes looks stupid.
			// Here, we want to place a bunch of tiles in the world, so we just repeat until success. It might be useful to keep track of attempts and check for attempts > maxattempts so you don't have infinite loops. 
			// The WorldGen.PlaceTile method returns a bool, but it is useless. Instead, we check the tile after calling it and if it is the desired tile, we know we succeeded.
			for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				bool placeSuccessful = false;
				Tile tile;
				int tileToPlace = ModContent.TileType<ExampleCutTileTile>();
				while (!placeSuccessful) {
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);
					int y = WorldGen.genRand.Next(0, Main.maxTilesY);
					WorldGen.PlaceTile(x, y, tileToPlace);
					tile = Main.tile[x, y];
					placeSuccessful = tile.active() && tile.type == tileToPlace;
				}
			}
		}

		private void MakeWells() {
			float widthScale = Main.maxTilesX / 4200f;
			int numberToGenerate = WorldGen.genRand.Next(1, (int)(2f * widthScale));
			for (int k = 0; k < numberToGenerate; k++) {
				bool success = false;
				int attempts = 0;
				while (!success) {
					attempts++;
					if (attempts > 1000) {
						success = true;
						continue;
					}
					int i = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
					if (i <= Main.maxTilesX / 2 - 50 || i >= Main.maxTilesX / 2 + 50) {
						int j = 0;
						while (!Main.tile[i, j].active() && (double)j < Main.worldSurface) {
							j++;
						}
						if (Main.tile[i, j].type == TileID.Dirt) {
							j--;
							if (j > 150) {
								bool placementOK = true;
								for (int l = i - 4; l < i + 4; l++) {
									for (int m = j - 6; m < j + 20; m++) {
										if (Main.tile[l, m].active()) {
											int type = (int)Main.tile[l, m].type;
											if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == TileID.Cloud || type == TileID.RainCloud) {
												placementOK = false;
											}
										}
									}
								}
								if (placementOK) {
									success = PlaceWell(i, j);
								}
							}
						}
					}
				}
			}
		}

		private readonly int[,] _wellshape = {
			{0,0,3,1,4,0,0 },
			{0,3,1,1,1,4,0 },
			{3,1,1,1,1,1,4 },
			{5,5,5,6,5,5,5 },
			{5,5,5,6,5,5,5 },
			{5,5,5,6,5,5,5 },
			{2,1,5,6,5,1,2 },
			{1,1,5,5,5,1,1 },
			{1,1,5,5,5,1,1 },
			{0,1,5,5,5,1,0 },
			{0,1,5,5,5,1,0 },
			{0,1,5,5,5,1,0 },
			{0,1,5,5,5,1,0 },
			{0,1,5,5,5,1,0 },
			{0,1,5,5,5,1,0 },
			{0,1,5,5,5,1,0 },
			{0,1,5,5,5,1,0 },
			{0,1,1,1,1,1,0 },
		};
		private readonly int[,] _wellshapeWall = {
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
		};
		private readonly int[,] _wellshapeWater = {
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,0,0,0,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,1,1,1,0,0 },
			{0,0,0,0,0,0,0 },
		};

		public bool PlaceWell(int i, int j) {
			if (!WorldGen.SolidTile(i, j + 1)) {
				return false;
			}
			if (Main.tile[i, j].active()) {
				return false;
			}
			if (j < 150) {
				return false;
			}

			for (int y = 0; y < _wellshape.GetLength(0); y++) {
				for (int x = 0; x < _wellshape.GetLength(1); x++) {
					int k = i - 3 + x;
					int l = j - 6 + y;
					if (WorldGen.InWorld(k, l, 30)) {
						Tile tile = Framing.GetTileSafely(k, l);
						switch (_wellshape[y, x]) {
							case 1:
								tile.type = TileID.RedBrick;
								tile.active(true);
								break;
							case 2:
								tile.type = TileID.RedBrick;
								tile.active(true);
								tile.halfBrick(true);
								break;
							case 3:
								tile.type = TileID.RedBrick;
								tile.active(true);
								tile.slope(2);
								break;
							case 4:
								tile.type = TileID.RedBrick;
								tile.active(true);
								tile.slope(1);
								break;
							case 5:
								tile.active(false);
								break;
							case 6:
								tile.type = TileID.Rope;
								tile.active(true);
								break;
						}
						switch (_wellshapeWall[y, x]) {
							case 1:
								tile.wall = WallID.RedBrick;
								break;
						}
						switch (_wellshapeWater[y, x]) {
							case 1:
								tile.liquid = 255;
								break;
						}
					}
				}
			}
			return true;
		}

		// We can use PostWorldGen for world generation tasks that don't need to happen between vanilla world generation steps.*/
		public override void PostWorldGen() {
			// This is simply generating a line of Chlorophyte halfway down the world.
			//for (int i = 0; i < Main.maxTilesX; i++)
			//{
			//	Main.tile[i, Main.maxTilesY / 2].type = TileID.Chlorophyte;
			//}

			// Here we spawn Example Person just like the Guide.

			// Place some items in Ice Chests
			int[] itemsToPlaceInIceChests = { ModContent.ItemType<Cure>()};
			int itemsToPlaceInIceChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36) {
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
						if (chest.item[inventoryIndex].type == ItemID.None) {
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInIceChests[itemsToPlaceInIceChestsChoice]);
							itemsToPlaceInIceChestsChoice = (itemsToPlaceInIceChestsChoice + 1) % itemsToPlaceInIceChests.Length;
							// Alternate approach: Random instead of cyclical: chest.item[inventoryIndex].SetDefaults(Main.rand.Next(itemsToPlaceInIceChests));
							break;
						}
					}
				}
			}
		}
		/*
		public override void ResetNearbyTileEffects() {
			ExamplePlayer modPlayer = Main.LocalPlayer.GetModPlayer<ExamplePlayer>();
			modPlayer.voidMonolith = false;
			exampleTiles = 0;
		}

		public override void TileCountsAvailable(int[] tileCounts) {
			// Here we count various tiles towards ZoneExample
			exampleTiles = tileCounts[ModContent.TileType<ExampleBlock>()] + tileCounts[ModContent.TileType<ExampleSand>()];

			// We can also add to vanilla biome counts if appropriate. Here we are adding to the ZoneDesert since we have a sand tile in the mod.
			Main.sandTiles += tileCounts[ModContent.TileType<ExampleSand>()];
		}

		public override void PreUpdate() {
			// Update everything about spawning the traveling merchant from the methods we have in the Traveling Merchant's class
			ExampleTravelingMerchant.UpdateTravelingMerchant();
		}

		public override void PostUpdate() {
			if (Main.dayTime && VolcanoCountdown == 0) {
				if (VolcanoCooldown > 0) {
					VolcanoCooldown--;
				}
				if (VolcanoCooldown <= 0 && Main.rand.NextBool(VolcanoChance) && !ModContent.GetInstance<ExampleConfigServer>().DisableVolcanoes) {
					string key = "Mods.ExampleMod.VolcanoWarning";
					Color messageColor = Color.Orange;
					if (Main.netMode == NetmodeID.Server) // Server
					{
						NetMessage.BroadcastChatMessage(NetworkText.FromKey(key), messageColor);
					}
					else if (Main.netMode == NetmodeID.SinglePlayer) // Single Player
					{
						Main.NewText(Language.GetTextValue(key), messageColor);
					}
					VolcanoCountdown = DefaultVolcanoCountdown;
					VolcanoCooldown = DefaultVolcanoCooldown;
				}
			}
			if (VolcanoCountdown > 0) {
				VolcanoCountdown--;
				if (VolcanoCountdown == 0) {
					VolcanoTremorTime = DefaultVolcanoTremorTime;
					// Since PostUpdate only happens in single and server, we need to inform the clients to shake if this is a server
					if (Main.netMode == NetmodeID.Server) {
						var netMessage = mod.GetPacket();
						netMessage.Write((byte)ExampleModMessageType.SetTremorTime);
						netMessage.Write(VolcanoTremorTime);
						netMessage.Send();
					}
					for (int playerIndex = 0; playerIndex < 255; playerIndex++) {
						if (Main.player[playerIndex].active) {
							Player player = Main.player[playerIndex];
							int speed = 12;
							float spawnX = Main.rand.Next(1000) - 500 + player.Center.X;
							float spawnY = -1000 + player.Center.Y;
							var baseSpawn = new Vector2(spawnX, spawnY);
							Vector2 baseVelocity = player.Center - baseSpawn;
							baseVelocity.Normalize();
							baseVelocity = baseVelocity * speed;
							var identities = new List<int>();
							for (int i = 0; i < VolcanoProjectiles; i++) {
								Vector2 spawn = baseSpawn;
								spawn.X = spawn.X + i * 30 - VolcanoProjectiles * 15;
								Vector2 velocity = baseVelocity;
								velocity = baseVelocity.RotatedBy(MathHelper.ToRadians(-VolcanoAngleSpread / 2 + VolcanoAngleSpread * i / (float)VolcanoProjectiles));
								velocity.X = velocity.X + 3 * Main.rand.NextFloat() - 1.5f;
								int projectile = Projectile.NewProjectile(spawn.X, spawn.Y, velocity.X, velocity.Y, Main.rand.Next(ProjectileID.MolotovFire, ProjectileID.MolotovFire3 + 1), 10, 10f, Main.myPlayer, 0f, 0f);
								Main.projectile[projectile].hostile = true;
								Main.projectile[projectile].Name = "Volcanic Rubble";
								identities.Add(Main.projectile[projectile].identity);
							}
							if (Main.netMode == NetmodeID.Server) {
								var netMessage = mod.GetPacket();
								netMessage.Write((byte)ExampleModMessageType.VolcanicRubbleMultiplayerFix);
								netMessage.Write(identities.Count);
								for (int i = 0; i < identities.Count; i++) {
									netMessage.Write(identities[i]);
								}
								netMessage.Send();
							}
						}
					}
				}
			}
		}

		// In ExampleMod, we use PostDrawTiles to draw the TEScoreBoard area. PostDrawTiles draws before players, npc, and projectiles, so it works well.
		public override void PostDrawTiles() {
			Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.instance.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
			var screenRect = new Rectangle((int)Main.screenPosition.X, (int)Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
			screenRect.Inflate(TEScoreBoard.drawBorderWidth, TEScoreBoard.drawBorderWidth);
			int scoreBoardType = ModContent.TileEntityType<TEScoreBoard>();
			foreach (var item in TileEntity.ByID) {
				if (item.Value.type == scoreBoardType) {
					var scoreBoard = item.Value as TEScoreBoard;
					Rectangle scoreBoardArea = scoreBoard.GetPlayArea();
					// We only want to draw while the area is visible. 
					if (screenRect.Intersects(scoreBoardArea)) {
						scoreBoardArea.Offset((int)-Main.screenPosition.X, (int)-Main.screenPosition.Y);
						DrawBorderedRect(Main.spriteBatch, Color.LightBlue * 0.1f, Color.Blue * 0.3f, scoreBoardArea.TopLeft(), scoreBoardArea.Size(), TEScoreBoard.drawBorderWidth);
					}
				}
			}
			Main.spriteBatch.End();
		}

		// A helper method that draws a bordered rectangle. 
		public static void DrawBorderedRect(SpriteBatch spriteBatch, Color color, Color borderColor, Vector2 position, Vector2 size, int borderWidth) {
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y), color);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y - borderWidth, (int)size.X + borderWidth * 2, borderWidth), borderColor);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y + (int)size.Y, (int)size.X + borderWidth * 2, borderWidth), borderColor);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X - borderWidth, (int)position.Y, (int)borderWidth, (int)size.Y), borderColor);
			spriteBatch.Draw(Main.magicPixel, new Rectangle((int)position.X + (int)size.X, (int)position.Y, (int)borderWidth, (int)size.Y), borderColor);
		*/
	}
}
