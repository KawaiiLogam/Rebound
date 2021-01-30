using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;
using BounceBack.Items.Armor;
using BounceBack.Items.Placeable;

namespace BounceBack.Items
{
	public class GachaponStar : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Gachapon Capsule");
			Tooltip.SetDefault("<right> to gacha");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 28;
			item.rare = ItemRarityID.Blue;
            item.maxStack = 30;
            item.value = Item.buyPrice(gold: 4);
		}

		public override bool CanRightClick() {
			return true;
		}

		public override void RightClick(Player player) {
			int randomChoice = (Main.rand.Next(9));
			
            if (randomChoice == 0) {
				player.QuickSpawnItem(ItemID.LifeCrystal, 1);
			}
			if (randomChoice == 1) {
			player.QuickSpawnItem(ItemID.FallenStar, 1);
			}
			if (randomChoice == 2) {
			player.QuickSpawnItem(ItemID.ManaCrystal, 1);
			}
            if (randomChoice == 3) {
			player.QuickSpawnItem(ModContent.ItemType<CroquetMallet>());
            }
            if (randomChoice == 4) {
			player.QuickSpawnItem(ModContent.ItemType<Chopsticks>());
            }
            if (randomChoice == 5) {
			player.QuickSpawnItem(ModContent.ItemType<PacifierCandyPop>());
            }
			if (randomChoice == 6) {
				player.QuickSpawnItem(ModContent.ItemType<SchoolGirlPoster>());
			}
			if (randomChoice == 7) {
				player.QuickSpawnItem(ItemID.TinCan, 1);
			}
			if (randomChoice == 8) {
				player.QuickSpawnItem(ModContent.ItemType<RoseComb>());
			}
		}
	}
}