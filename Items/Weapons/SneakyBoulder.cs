using BounceBack.Projectiles;
using BounceBack.Items.BouncierDamage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class SneakyBoulder : ResilienceDamage
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sneaky Boulder");
			Tooltip.SetDefault("Not very bouncy");
		}

		public override void SafeSetDefaults() 
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.width = 14;
			item.height = 50;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.channel = true;
			item.noMelee = true;
			item.useAnimation = 24;
			item.consumable = true;
			item.maxStack = 1;
			item.useTime = 24;
			item.shootSpeed = 15f;
			item.damage = 7;
			item.knockBack = 3f;
			item.value = Item.sellPrice(0, 0, 0, 10);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = false;
			item.maxStack = 1;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<SneakyBoulderProj>();
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			// ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
			recipe.AddIngredient(ItemID.StoneBlock,8);
			recipe.AddTile(TileID.WorkBenches);
			// You can use recipe.AddIngredient(ItemID.TheItemYouWantToUse, the amount of items needed); for a vanilla item.
			//recipe.AddTile(ModContent.TileType<ExampleWorkbench>()); // Set the crafting tile to ExampleWorkbench
			recipe.SetResult(this); // Set the result to this item (ExampleSword)
			recipe.AddRecipe(); // When your done, add the recipe
		}
	}
}
