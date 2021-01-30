using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.NPCs.Rebound;

namespace BounceBack.NPCs.Rebound
{
	public class ReboundB : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rebound B");
		}

		public override void SetDefaults()
		{
			npc.aiStyle = 5;
			npc.lifeMax = 50;
			npc.damage = 40;
			npc.defense = 2;
			npc.knockBackResist = 0f;
			npc.width = 64;
			npc.height = 64;
			npc.npcSlots = 15f;
			npc.lavaImmune = true;
			npc.noGravity = true;
			npc.noTileCollide = false;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
		}
		//public override void HitEffect(int hitDirection, double damage) {
		//	Player player = Main.player[npc.target];
        //    Vector2 spawnAt = npc.Center + new Vector2(0f, (float)npc.height / 2f);
        //    NPC.NewNPC((int)spawnAt.X, (int)spawnAt.Y, ModContent.NPCType<ReboundMeteorite>());
		//}
		public override bool PreNPCLoot() {
			return false;
        }
        //public override void Kill(int timeLeft)
		//{
		//	if (Main.rand.Next(0, 1) == 0)
		//	//Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<Reboundb>(), 1, false, 0, false, false);
		//	Main.PlaySound(SoundID.Dig, (int)NPC.position.X, (int)NPC.position.Y);
		//}
			//for (int i = 0; i < 2; i++)
             //   {
            //        Vector2 newPos = NPC.Center;
             //       newPos -= NPC.velocity * ((float)i * 0.25f);
           //         int dust = Dust.NewDust(newPos, 1, 1, 72, 1f, 0f, 150, default(Color), 3f);
             //       Main.dust[dust].noGravity = true;
              //      Main.dust[dust].position = newPos;
             //       Dust dust3 = Main.dust[dust];
             //       dust3.velocity *= 0.2f;
              //  }
		
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
