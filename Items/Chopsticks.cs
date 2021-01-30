using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items
{
	public class Chopsticks : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
			 DisplayName.SetDefault("Chopsticks");
			 Tooltip.SetDefault("Summons a cat in a bowl of ramen");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ItemID.ZephyrFish);
			item.shoot = ModContent.ProjectileType<Projectiles.Pets.RamenCatPet>();
			item.buffType = ModContent.BuffType<Buffs.ChopsticksBuff>();
		}
		public override void UseStyle(Player player) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}