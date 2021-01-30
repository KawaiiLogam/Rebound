using BounceBack.Tiles;
using BounceBack.Projectiles;
using BounceBack.Items.Placeable;
using BounceBack.Items.BouncierDamage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class Starling : ResilienceDamage
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starling");
			Tooltip.SetDefault("Boomerang bouncy ball");
		}

		public override void SafeSetDefaults() 
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.width = 24;
			item.height = 24;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.channel = true;
			item.noMelee = true;
			item.useAnimation = 24;
			item.consumable = true;
			item.maxStack = 1;
			item.useTime = 24;
			item.shootSpeed = 15f;
			item.damage = 18;
			item.knockBack = 3.7f;
			item.value = Item.sellPrice(0, 1, 10, 0);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = false;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<StarlingProj>();
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			// ItemType<ExampleItem>() is how to get the ExampleItem item, 10 is the amount of that item you need to craft the recipe
			recipe.AddIngredient(ModContent.ItemType<MetalBallBearing>(), 1);
			recipe.AddIngredient(ItemID.FallenStar);
			recipe.AddIngredient(ItemID.Sapphire);
			recipe.AddIngredient(ItemID.MeteoriteBar);
			recipe.AddIngredient(ModContent.ItemType<Rubber>(), 4);
			recipe.AddTile(ModContent.TileType<RubberPressTile>());
			// You can use recipe.AddIngredient(ItemID.TheItemYouWantToUse, the amount of items needed); for a vanilla item.
			//recipe.AddTile(ModContent.TileType<ExampleWorkbench>()); // Set the crafting tile to ExampleWorkbench
			recipe.SetResult(this); // Set the result to this item (ExampleSword)
			recipe.AddRecipe(); // When your done, add the recipe
		}
	}
}
