using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items;
using BounceBack.Projectiles;
using BounceBack.Items.BouncierDamage;

namespace BounceBack.Items
{
	public class RoseGoldHamlet : ResilienceDamage
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The combined power of a hammer and a mallet. Its not very effective on walls but it has a funny name");
		}

		public override void SafeSetDefaults() {
			item.damage = 19;
			item.ranged = true;
			item.noMelee = false;
			item.width = 40;
			item.height = 40;
			item.useTime = 75;
			item.useAnimation = 75;
			item.hammer = 70;      //How much hammer power the weapon has
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 1000;
			item.rare = ItemRarityID.Blue;
			item.UseSound = SoundID.Item14;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<RoseGoldOreProj>();
			item.shootSpeed = 16f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RoseGoldBar>(), 11);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}