using Terraria.ModLoader;
using Terraria.ID;
using BounceBack;

namespace BounceBack.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RoseComb : ModItem
	{
		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.rare = ItemRarityID.Green;
			item.vanity = true;
			item.value = 2000;
		}
	}
}