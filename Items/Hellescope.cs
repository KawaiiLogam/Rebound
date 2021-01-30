using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BounceBack.NPCs.Rebound;

namespace BounceBack.Items
{
	public class Hellescope : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hellescope");
			Tooltip.SetDefault("Summons the pale green dot");
            ItemID.Sets.SortingPriorityBossSpawns[item.type] = 12;
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Orange;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 30;
		}
        

        // We use the CanUseItem hook to prevent a player from using this item while the boss is present in the world.
    public override bool CanUseItem(Player player) {
            // "player.ZoneUnderworldHeight" could also be written as "player.position.Y / 16f > Main.maxTilesY - 200"
            return !NPC.AnyNPCs(ModContent.NPCType<Rebound>()) && !NPC.AnyNPCs(ModContent.NPCType<ReboundVolcanic>());
        }

    public override bool UseItem(Player player) {
            NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<Rebound>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }


        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HellstoneBar,12);
            recipe.AddIngredient(ItemID.Lens);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
