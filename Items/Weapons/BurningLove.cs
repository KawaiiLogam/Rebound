using BounceBack.Projectiles;
using BounceBack.Items.BouncierDamage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class BurningLove : ResilienceDamage
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Love");
			Tooltip.SetDefault("Love hurts");
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
			item.damage = 31;
			item.knockBack = 3.7f;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.autoReuse = false;
			item.maxStack = 1;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<BurningLoveProj>();
        }
	}
}