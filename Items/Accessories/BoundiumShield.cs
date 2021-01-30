using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using BounceBack;

namespace BounceBack.Items.Accessories
{
	[AutoloadEquip(EquipType.Shield)]
	public class BoundiumShield : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Enemies spawn less");
			//	+ "\n" + Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 1900)
		}

		public override void SetDefaults() {
			item.width = 30;
			item.height = 30;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Orange;
			item.accessory = true;
			item.defense = 4;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			//if (player.name == "bluemagic123") {
            //    Player.jump
				//player.allDamage += 19f; // increase all damage by 1900%
				/* Here are the individual weapon class bonuses.
				player.meleeDamage += 19f;
				player.thrownDamage += 19f;
				player.rangedDamage += 19f;
				player.magicDamage += 19f;
				player.minionDamage += 19f;
				*/
				//player.GetModPlayer<BoundiumPlayer>().BoundiumShield = true;
				player.AddBuff(BuffID.Calm,1);
			
		}
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<BoundiumBar>(), 9);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}