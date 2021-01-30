using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;
using BounceBack.Items.Armor;
using BounceBack.Items.Placeable;

namespace BounceBack.Items
{
	public class GachaponHeart : ModItem
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
            item.value = Item.sellPrice(silver: 25);
            item.value = Item.buyPrice(gold: 6);
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			int randomChoice = (Main.rand.Next(10));
			
            if (randomChoice == 0) {
				player.QuickSpawnItem(ItemID.RegenerationPotion, 5);
			}
			if (randomChoice == 1) {
			player.QuickSpawnItem(ItemID.IronskinPotion, 5);
			}
			if (randomChoice == 2) {
			player.QuickSpawnItem(ItemID.HealingPotion, 3);
			}
            if (randomChoice == 3) {
			player.QuickSpawnItem(ModContent.ItemType<Cosmo>());
            }
            if (randomChoice == 4) {
			player.QuickSpawnItem(ModContent.ItemType<MaltBall>());
            }
            if (randomChoice == 5) {
			player.QuickSpawnItem(ModContent.ItemType<RoseSkirt>());
            }
			if (randomChoice == 6) {
				player.QuickSpawnItem(ModContent.ItemType<AmyRosePoster>());
			}
			if (randomChoice == 7) {
				player.QuickSpawnItem(ItemID.GoldenKey);
			}
			if (randomChoice == 8) {
				player.QuickSpawnItem(ItemID.FishingSeaweed);
			}
			if (randomChoice == 9) {
				player.QuickSpawnItem(ModContent.ItemType<GachaponStar>());
			}
			//player.QuickSpawnItem(ItemID.LavaWaders);
			//player.QuickSpawnItem(ItemID.CellPhone);
			//player.QuickSpawnItem(ItemID.SuspiciousLookingTentacle);
		}
	}
}