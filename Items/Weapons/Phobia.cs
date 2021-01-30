using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class Phobia : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Phobia");
			Tooltip.SetDefault("It's full power is locked away");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
			item.damage = 4;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 20;
			item.useAnimation = 20;
			item.knockBack = 12;
			item.rare = ItemRarityID.Gray;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.crit = 6;
			item.useStyle = ItemUseStyleID.SwingThrow;
		}

		public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
		{
			if (player.GetModPlayer<BouncePlayer>().markOfTryp) {
				flat += 54;
			}
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			player.AddBuff(BuffID.Darkness, 60);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			// ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
			recipe.AddIngredient(ItemID.Bone);
			recipe.AddTile(TileID.Anvils);
			// You can use recipe.AddIngredient(ItemID.TheItemYouWantToUse, the amount of items needed); for a vanilla item.
			//recipe.AddTile(ModContent.TileType<ExampleWorkbench>()); // Set the crafting tile to ExampleWorkbench
			recipe.SetResult(this); // Set the result to this item (ExampleSword)
			recipe.AddRecipe(); // When your done, add the recipe
		}
	}
}