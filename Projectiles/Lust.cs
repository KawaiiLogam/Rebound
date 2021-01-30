using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;

namespace BounceBack.Projectiles
{
	public class LustProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lust");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 150;
			projectile.height = 24;
			projectile.width = 24;
			projectile.aiStyle = 5;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.damage = 2;
		}
		public override void Kill(int timeLeft)
		{
			//if (Main.rand.Next(0, 1) == 0)
			//Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, ModContent.ItemType<MaltBall>(), 1, false, 0, false, false);

			//for (int i = 0; i < 5; i++) {
			//	Dust.NewDust(projectile.position, projectile.width, projectile.height, 147);
			//}
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
		}
		public override void AI()
		{
			projectile.alpha += 0;
			if (projectile.alpha >= 200) {
				projectile.alpha = 200;
			}
			projectile.velocity = projectile.velocity.RotatedBy(0);
			projectile.rotation += 0f;
			projectile.velocity *= .975f;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Lovestruck, 90);
			target.AddBuff(BuffID.Poisoned, 190);
		}
		//public override bool OnTileCollide(Vector2 velocityChange)  
		//{
		//    if (projectile.velocity.X != velocityChange.X)
		//    {
		//        projectile.velocity.X = -velocityChange.X; //Goes in the opposite direction with half of its x velocity
		//    }
		//    if (projectile.velocity.Y != velocityChange.Y)
		//    {
		//        projectile.velocity.Y = -velocityChange.Y; //Goes in the opposite direction with half of its y velocity
		//    }
		//    return false;
		// }

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return false;
		}
    }
}
