using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Accessories;

namespace BounceBack.NPCs
{
	// Party Zombie is a pretty basic clone of a vanilla NPC. To learn how to further adapt vanilla NPC behaviors, see https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption#example-npc-npc-clone-with-modified-projectile-hoplite
	public class EyeBot : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eye Bot");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DemonEye];
		}

		public override void SetDefaults() {
			npc.width = 18;
			npc.height = 40;
			npc.damage = 18;
			npc.defense = 12;
			npc.lifeMax = 50;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 2;
			aiType = NPCID.DemonEye;
			animationType = NPCID.DemonEye;
			banner = Item.NPCtoBanner(NPCID.DemonEye);
			bannerItem = Item.BannerToItem(banner);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return SpawnCondition.OverworldNightMonster.Chance * 0.5f;
		}
		public override void NPCLoot()
		{
			NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, NPCID.DemonEye);
			if (Main.rand.Next(8) == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BallPolish>());
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