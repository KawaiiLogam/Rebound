using BounceBack.Projectiles;
using BounceBack.Items.BouncierDamage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class RBBall : ResilienceDamage
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rubber Band Ball");
			Tooltip.SetDefault("You bound it, now bounce it!");
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
			item.damage = 9;
			item.knockBack = 3.7f;
			item.value = Item.sellPrice(0, 0, 5, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = false;
			item.maxStack = 1;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<RBBallProj>();
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			// ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
			recipe.AddIngredient(ModContent.ItemType<RubberBand>(), 40);
			// You can use recipe.AddIngredient(ItemID.TheItemYouWantToUse, the amount of items needed); for a vanilla item.
			//recipe.AddTile(ModContent.TileType<ExampleWorkbench>()); // Set the crafting tile to ExampleWorkbench
			recipe.SetResult(this); // Set the result to this item (ExampleSword)
			recipe.AddRecipe(); // When your done, add the recipe
		}
	}
}
