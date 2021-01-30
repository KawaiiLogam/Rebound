using Terraria;
using Terraria.ModLoader;

namespace BounceBack.Buffs
{
	public class ChopsticksBuff : ModBuff
	{
		public override void SetDefaults() {
			// DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
			 DisplayName.SetDefault("Chopsticks");
			 Description.SetDefault("A cat in a bowl of ramen is following you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.buffTime[buffIndex] = 18000;
			player.GetModPlayer<BouncePlayer>().ramenCatPet = true;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.RamenCatPet>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer) {
				Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.RamenCatPet>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}