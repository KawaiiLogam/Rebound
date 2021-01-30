using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;

namespace BounceBack.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class LittleHero : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Little Hero");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
		}

		public override void SetDefaults() {
			npc.width = 14;
			npc.height = 18;
			npc.damage = 25;
			npc.defense = 7;
			npc.lifeMax = 300;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 1f;
			npc.aiStyle = 3;
			aiType = 25;
			animationType = NPCID.Zombie;
			//banner = Item.NPCtoBanner(NPCID.Zombie);
			//bannerItem = Item.BannerToItem(banner);
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.OnFire, 30);
			Player player = Main.player[npc.target];
			Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
			NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y-100, NPCID.Firefly);
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (NPC.downedBoss3) {
				return SpawnCondition.Cavern.Chance * 0.5f;
			}
			else {
				return SpawnCondition.Cavern.Chance * 0f;
			}
			
		}
		
		public override void NPCLoot()
		{
			if (Main.rand.Next(5) == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<Overused>());
			}
		}

		//public override void HitEffect(int hitDirection, double damage) {
		//for (int i = 0; i < 10; i++) {
		//	int dustType = Main.rand.Next(139, 143);
		//	int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
		//	Dust dust = Main.dust[dustIndex];
		//	dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
		//	dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
		//	dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
		//}
		//}
	}
}