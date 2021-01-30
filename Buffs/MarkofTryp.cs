using Terraria;
using Terraria.ModLoader;
using BounceBack;
using Microsoft.Xna.Framework;

namespace BounceBack.Buffs
{
	public class MarkofTryp : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Mark of Tryp");
			Description.SetDefault("||||||||||||");
			Main.buffNoTimeDisplay[Type] = true;
			Main.debuff[Type] = true; //Add this so the nurse doesn't remove the buff when healing
			canBeCleared = false;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.statDefense += -23;
		}
	}
}