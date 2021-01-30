using Terraria.ModLoader;
using Terraria.ID;
using BounceBack;

namespace BounceBack.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PacifierCandyPop : ModItem
	{
		public override void SetDefaults() {
			item.width = 28;
			item.height = 28;
			item.rare = ItemRarityID.Blue;
			item.vanity = true;
			item.value = 500;
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
			drawAltHair = true;
		}

	}
}