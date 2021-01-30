using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack;

namespace BounceBack.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RoseGoldLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Rose Gold Leggings");
			//Tooltip.SetDefault("This is a modded body armor."
			//	+ "\nImmunity to 'On Fire!'"
			//	+ "\n+20 max mana and +1 max minions");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(silver: 10);
			item.rare = ItemRarityID.Blue;
			item.defense = 3;
		}

		//public override void UpdateEquip(Player player) {
		//	player.buffImmune[BuffID.OnFire] = true;
		//	player.statManaMax2 += 20;
		//	player.maxMinions++;
		//}
        //public override void UpdateEquip(Player player) {
		//	player.GetModPlayer<BouncePlayer>().boundLegs = true;
        //}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RoseGoldBar>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}