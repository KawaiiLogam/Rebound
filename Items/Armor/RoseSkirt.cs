using Terraria.ModLoader;
using Terraria.ID;
using BounceBack;

namespace BounceBack.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RoseSkirt : ModItem
	{
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 14;
			item.rare = ItemRarityID.Green;
			item.vanity = true;
			item.value = 2000;
		}
		public override bool DrawBody()
		{
			return false;
		}
	}
}