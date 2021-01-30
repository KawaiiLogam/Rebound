using BounceBack.Projectiles;
using BounceBack.Items.BouncierDamage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BounceBack.Items.Weapons
{
	public class PikoPikoMk1 : ResilienceDamage
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Piko Piko-MK1");
			Tooltip.SetDefault("Thwack a mini pink ball at your enemies!");
		}
		public override void SafeSetDefaults() {
			item.damage = 38; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
			item.width = 44; // hitbox width of the item
			item.height = 44; // hitbox height of the item
			item.useTime = 60; // The item's use time in ticks (60 ticks == 1 second.)
			item.useAnimation = 60; // The length of the item's use animation in ticks (60 ticks == 1 second.)
			item.useStyle = ItemUseStyleID.SwingThrow; // how you use the item (swinging, holding out, etc)
			item.noMelee = false; //so the item's animation doesn't do damage
			item.knockBack = 4; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
			item.value = 2000; // how much the item sells for (measured in copper)
			item.rare = ItemRarityID.Green; // the color that the item's name will be in-game
			item.UseSound = SoundID.Item14; // The sound that this item plays when used.
			item.autoReuse = true; // if you can hold click to automatically use it again
			item.shoot = ModContent.ProjectileType<MiniPinkBallProj>(); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 16f; // the speed of the projectile (measured in pixels per frame)
		}
		// How can I choose between several projectiles randomly?
		//public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		//{
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
		//	type = Main.rand.Next(new int[] {ModContent.ProjectileType<BurningLoveProj>(), ModContent.ProjectileType<RBBallProj>(), ModContent.ProjectileType<GelBallProj>(), ModContent.ProjectileType<PinkGelBallProj>(),
		//	ModContent.ProjectileType<CthulusTearProj>(), ModContent.ProjectileType<Overused>(), ModContent.ProjectileType<MaltBallProj>()});
		//	return true;
		//}
	}
}