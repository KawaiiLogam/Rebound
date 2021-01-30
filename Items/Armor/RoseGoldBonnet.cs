using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using BounceBack;

namespace BounceBack.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RoseGoldBonnet : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Increases resilience damage by 1");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ModContent.ItemType<RoseGoldChestplate>() && legs.type == ModContent.ItemType<RoseGoldLeggings>();
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "Increases resilience damage by 2";
            player.GetModPlayer<BouncePlayer>().roseSet = true;
            //player.allDamage -= 0.2f;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}
        public override void UpdateEquip(Player player) {
			player.GetModPlayer<BouncePlayer>().roseHead = true;
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RoseGoldBar>(), 17);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}