using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.NPCs.Rebound;
using BounceBack.Items;

namespace BounceBack.NPCs.Rebound
{
	public class ReboundMeteorite : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rebound Meteorite");
		}

		public override void SetDefaults()
		{
			npc.aiStyle = 14;
			npc.lifeMax = 25;
			npc.damage = 20;
			npc.defense = 2;
			npc.knockBackResist = 0f;
			npc.width = 24;
			npc.height = 24;
			npc.npcSlots = 15f;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
		}
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.Blackout, 60);
		}

		// public override bool PreNPCLoot() {
		//	return false;
		//}
		public override void NPCLoot() {
        //    			int choice = Main.rand.Next(10);
		//	if (Main.expertMode) {
		//		npc.DropBossBags();
            if (Main.rand.Next(9) == 0) {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<BoundiumOre>(), 1);
			}
		}
		 //public override bool OnTileCollide(Vector2 velocityChange)  
        //{
         //   if (NPC.velocity.X != velocityChange.X)
         //   {
        //        NPC.velocity.X = -velocityChange.X; //Goes in the opposite direction with half of its x velocity
         //   }
         //   if (NPC.velocity.Y != velocityChange.Y)
          //  {
         //       NPC.velocity.Y = -velocityChange.Y; //Goes in the opposite direction with half of its y velocity
         //   }
        //    return false;
       // }
    }
}
