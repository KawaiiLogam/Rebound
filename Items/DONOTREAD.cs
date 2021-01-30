using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack;

namespace BounceBack.Items
{
	public class DONOTREAD : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			 DisplayName.SetDefault("DO NOT READ");
			 Tooltip.SetDefault("'This tome contains an ancient curse trapped. By even reading the first word you risk everything.'");	
		}

		public override void SetDefaults() {
			item.buffType = ModContent.BuffType<Buffs.MarkofTryp>();
		}
		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.AddBuff(item.buffType, 99999999, true);
			player.QuickSpawnItem(ModContent.ItemType<DONOTREAD>());
			player.GetModPlayer<BouncePlayer>().markOfTryp = true;
		}
	}
}