using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack;

namespace BounceBack.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RoseGoldChestplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Rose Gold Chestplate");
			Tooltip.SetDefault("Increases resilience damage by 1");
			//Tooltip.SetDefault("This is a modded body armor."
			//	+ "\nImmunity to 'On Fire!'"
			//	+ "\n+20 max mana and +1 max minions");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(silver: 15);
			item.rare = ItemRarityID.Blue;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player) {
			player.GetModPlayer<BouncePlayer>().roseChest = true;
		//	player.buffImmune[BuffID.OnFire] = true;
		//	player.statManaMax2 += 20;
		//	player.maxMinions++;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RoseGoldBar>(), 23);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}