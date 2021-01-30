using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;
using BounceBack.Items.Accessories;
using BounceBack.Items.Placeable;

namespace BounceBack.Items
{
	public class GachaponMoon : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gachapon Capsule");
			Tooltip.SetDefault("<right> to gacha");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 28;
			item.rare = ItemRarityID.Green;
            item.maxStack = 30;
            item.value = Item.sellPrice(silver: 50);
            item.value = Item.buyPrice(gold: 8);
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			int randomChoice = (Main.rand.Next(11));
			
            if (randomChoice == 0) {
				player.QuickSpawnItem(ItemID.GoldMouse);
			}
			if (randomChoice == 1) {
			player.QuickSpawnItem(ItemID.PinkGel, 25);
			}
			if (randomChoice == 2) {
			player.QuickSpawnItem(ItemID.MoneyTrough);
			}
            if (randomChoice == 3) {
			player.QuickSpawnItem(ModContent.ItemType<PikoPikoMk1>());
            }
            if (randomChoice == 4) {
			player.QuickSpawnItem(ModContent.ItemType<Supuringu>());
            }
            if (randomChoice == 5) {
			player.QuickSpawnItem(ModContent.ItemType<AmysSneakers>());
            }
			if (randomChoice == 6) {
				player.QuickSpawnItem(ModContent.ItemType<OryxPoster>());
			}
			if (randomChoice == 7) {
				player.QuickSpawnItem(ItemID.OldShoe);
			}
			if (randomChoice == 8) {
				player.QuickSpawnItem(ModContent.ItemType<GachaponHeart>());
			}
			if (randomChoice == 9) {
				player.QuickSpawnItem(ModContent.ItemType<BouncierPotion>()); 
				player.QuickSpawnItem(ModContent.ItemType<BouncierPotion>()); 
				player.QuickSpawnItem(ModContent.ItemType<BouncierPotion>());
			}
			//player.QuickSpawnItem(ItemID.LavaWaders);
			//player.QuickSpawnItem(ItemID.CellPhone);
			//player.QuickSpawnItem(ItemID.SuspiciousLookingTentacle);
		}
	}
}