using BounceBack.Projectiles;
using BounceBack.Items.BouncierDamage;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class Overused : ResilienceDamage
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Overused");
			Tooltip.SetDefault("Well-worn. It served its bouncier well");
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
			item.damage = 26;
			item.knockBack = 3.7f;
			item.value = Item.sellPrice(0, 1, 20, 0);
			item.rare = ItemRarityID.Green;
			item.autoReuse = false;
			item.maxStack = 1;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<OverusedProj>();
        }
	}
}

