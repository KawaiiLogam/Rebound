using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.NPCs.Rebound;
using BounceBack.Items;
using BounceBack.Items.Weapons;
using BounceBack.Projectiles.Minions;

namespace BounceBack.NPCs.Rebound
{
	// Rebound is a multi-stage boss.
	[AutoloadBossHead]
	public class ReboundVolcanic : ModNPC
	{
		//private static int hellLayer => Main.maxTilesY - 200;
		private float attackCool {
			get => npc.ai[0];
			set => npc.ai[0] = value;
		}

		//private float moveCool {
		//	get => npc.ai[1];
		//	set => npc.ai[1] = value;
		//}

		//private float rotationSpeed {
		//	get => npc.ai[2];
		//	set => npc.ai[2] = value;
		//}

		//private float captiveRotation {
		//	get => npc.ai[3];
		//	set => npc.ai[3] = value;
		//}

		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rebound");
		}

		public override void SetDefaults() {
			npc.aiStyle = 23;
			npc.lifeMax = 1000;
			npc.damage = 100;
			npc.defense = 50;
			npc.knockBackResist = 0f;
			npc.width = 200;
			npc.height = 200;
			npc.value = Item.buyPrice(0, 20, 0, 0);
			npc.npcSlots = 15f;
			npc.boss = true;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[24] = true;
			music = MusicID.Plantera;
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.lifeMax = (int)(npc.lifeMax * 0.5f * bossLifeScale);
			npc.damage = (int)(npc.damage * 0.8f);
		}


		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) {
			scale = 1.5f;
			return null;
		}
        public override void HitEffect(int hitDirection, double damage) {
			Player player = Main.player[npc.target];
            Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
            NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<ReboundC>());
		}
		public override void AI(){
			Player player = Main.player[npc.target];
			if (!player.active || player.dead) {
				npc.TargetClosest(false);
				player = Main.player[npc.target];
				if (!player.active || player.dead) {
					npc.velocity = new Vector2(0f, 10f);
					if (npc.timeLeft > 10) {
						npc.timeLeft = 10;
					}
					return;
				}
			}
		}
        public override void NPCLoot() {
        //    			int choice = Main.rand.Next(10);
		//	if (Main.expertMode) {
		//		npc.DropBossBags();
			if (Main.rand.Next(2) == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BurningLove>());
			}
			if (Main.rand.Next(2) == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<DragonbugStaff>());
			}
			if (Main.rand.Next(2) == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 2423);
			}
            if (Main.rand.Next(1) == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BoundiumOre>(), 90);
			}
		
			//int[] lootTable = {
			//	ModContent.ItemType<ProtectorateBody>(),
			//	ModContent.ItemType<ProtectorateLegs>()
			//};
			//if (Main.rand.Next(30) == 0) {
			//	int loot = Main.rand.Next(lootTable.Length);
			//	{
			//		npc.DropItem(lootTable[loot]);
			//	}
			//};
			if (!BounceWorld.downedRebound) {
				BounceWorld.downedRebound = true;
				if (Main.netMode == NetmodeID.Server) {
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}
		}
		
            //int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ModContent.ProjectileType<ReboundB>(), npc.damage / 2, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
			//attackDelay = 1;
			//if (Math.Abs(npc.Center.X - player.Center.X) < 16f * 30f && Math.Abs(npc.Center.Y - player.Center.Y) < 16f * 20f) {
				//if (!player.buffImmune[BuffID.Cursed] && ai >= 120f) {
				//	ai = -60f;
				//	npc.netUpdate = true;
				//}
				//else if (ai >= 180f) {
				//	ai = -120f;
				//	if (Main.netMode != NetmodeID.MultiplayerClient) {
				//		int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, ModContent.ProjectileType<ReboundsHornProj>(), npc.damage / 2, 0f, Main.myPlayer, player.Center.X, player.Center.Y);
				//	}
				//	npc.netUpdate = true;

	}
}