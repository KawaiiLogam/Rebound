using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack;

namespace BounceBack.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BoundiumChestplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Boundium Chestplate");
			Tooltip.SetDefault("Increases resilience damage by 4%");
			//Tooltip.SetDefault("This is a modded body armor."
			//	+ "\nImmunity to 'On Fire!'"
			//	+ "\n+20 max mana and +1 max minions");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Orange;
			item.defense = 9;
		}

		public override void UpdateEquip(Player player) {
			player.GetModPlayer<BouncePlayer>().boundChest = true;
		//	player.buffImmune[BuffID.OnFire] = true;
		//	player.statManaMax2 += 20;
		//	player.maxMinions++;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BoundiumBar>(), 25);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}