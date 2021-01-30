using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack;
using BounceBack.Buffs;

namespace BounceBack.Items
{
	public class Cure : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			 DisplayName.SetDefault("Cure");
			 Tooltip.SetDefault("'This tome contains an ancient cure.'");	
		}
		public override void SetDefaults()
		{
			item.buffType = ModContent.BuffType<Buffs.MarkofTryp>();
		}
		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.ClearBuff(ModContent.BuffType<Buffs.MarkofTryp>());
			player.GetModPlayer<BouncePlayer>().markOfTryp = false;
			player.QuickSpawnItem(ModContent.ItemType<Cure>());
		}
	}
}