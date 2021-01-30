using BounceBack.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Weapons
{
	public class Pencil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("#2 Pencil");
			Tooltip.SetDefault("When in doubt, fill in (C).");
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
			item.damage = 9;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 0, 0, 3);
			item.value = Item.buyPrice(0, 0, 0, 20);
			item.rare = ItemRarityID.Blue;
			item.autoReuse = false;
			item.consumable = true;
			item.shoot = ModContent.ProjectileType<PencilProj>();
        }
	}
}

