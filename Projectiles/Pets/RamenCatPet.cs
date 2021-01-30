using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Projectiles.Pets
{
	public class RamenCatPet : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ramen Cat Pet"); // Automatic from .lang files
			Main.projFrames[projectile.type] = 4;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI() {
			Player player = Main.player[projectile.owner];
			BouncePlayer modPlayer = player.GetModPlayer<BouncePlayer>();
			if (player.dead) {
				modPlayer.ramenCatPet = false;
			}
			if (modPlayer.ramenCatPet) {
				projectile.timeLeft = 2;
			}
		}
	}
}