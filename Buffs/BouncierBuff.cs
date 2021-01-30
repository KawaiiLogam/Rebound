using Terraria;
using Terraria.ModLoader;
using BounceBack;

namespace BounceBack.Buffs
{
	public class BouncierBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Bouncier Buff");
			Description.SetDefault("Increases bouncy ball damage by 5");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false; //Add this so the nurse doesn't remove the buff when healing
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.GetModPlayer<BouncePlayer>().bouncierBuff = true;
		}
	}
}