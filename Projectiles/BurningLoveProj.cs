using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.Items.Weapons;

namespace BounceBack.Projectiles
{
	public class BurningLoveProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Love");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 180;
			projectile.height = 24;
			projectile.width = 24;
			projectile.aiStyle = 2;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
		}
        public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(0, 1) == 0)
			Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, ModContent.ItemType<BurningLove>(), 1, false, 0, false, false);
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
			projectile.velocity *= .995f;

			for (int i = 0; i < 2; i++)
                {
                    Vector2 newPos = projectile.Center;
                    newPos -= projectile.velocity * ((float)i * 0.25f);
                    int dust = Dust.NewDust(newPos, 1, 1, 72, 1f, 0f, 150, default(Color), 3f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = newPos;
                    Dust dust3 = Main.dust[dust];
                    dust3.velocity *= 0.2f;
                }
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 90);      
        }
		 public override bool OnTileCollide(Vector2 velocityChange)  
        {
            if (projectile.velocity.X != velocityChange.X)
            {
                projectile.velocity.X = -velocityChange.X; //Goes in the opposite direction with half of its x velocity
            }
            if (projectile.velocity.Y != velocityChange.Y)
            {
                projectile.velocity.Y = -velocityChange.Y; //Goes in the opposite direction with half of its y velocity
            }
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
			return false;
        }
		public void OnHitNPC(Player player, NPC target, float knockback, bool crit, int damage) {
			if (player.GetModPlayer<BouncePlayer>().boundSet)
			{
				target.AddBuff(BuffID.Frostburn, 200);
			}
        }
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
