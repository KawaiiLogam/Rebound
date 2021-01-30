using BounceBack.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class RubberBand : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rubber Band");
			Tooltip.SetDefault("Fling it!");
		}
		
		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.width = 14;
			item.height = 50;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.thrown = false;
			item.ranged = true;
			item.channel = true;
			item.noMelee = true;
			item.useAnimation = 24;
			item.consumable = true;
			item.maxStack = 999;
			item.useTime = 24;
			item.shootSpeed = 15f;
			item.damage = 5;
			item.knockBack = 3.7f;
			item.value = Item.sellPrice(0, 0, 0, 5);
			item.value = Item.buyPrice(0, 0, 0, 60);
			item.rare = ItemRarityID.White;
			item.autoReuse = false;
			item.maxStack = 999;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<RubberBandProj>();
		}

	}
}