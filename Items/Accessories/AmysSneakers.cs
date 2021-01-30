using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Items.Accessories
{
	[AutoloadEquip(EquipType.Shoes)]
	public class AmysSneakers : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amy's Sneakers");
			Tooltip.SetDefault("Faster than the lightning boots but can't fly");
		//		"\nDouble tap in any cardinal direction to do a dash!");
		}

		public override void SetDefaults()
		{
			item.accessory = true;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(gold: 1);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxRunSpeed = 7f;
		}
	}
}