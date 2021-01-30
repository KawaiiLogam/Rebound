using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BounceBack.Projectiles.Minions
{
public class DragonbugStaff : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Dragonbug Staff");
			Tooltip.SetDefault("Summons a Dragonbug from another planet to fight for you");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 19;
			item.knockBack = 3f;
			item.mana = 2;
			item.width = 44;
			item.height = 44;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item30;

			// These below are needed for a minion weapon
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<DragonbugBuff>();
			// No buffTime because otherwise the item tooltip would say something like "1 minute duration"
			item.shoot = ModContent.ProjectileType<DragonbugMinion>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			// This is needed so the buff that keeps your minion alive and allows you to despawn it properly applies
			player.AddBuff(item.buffType, 2);

			// Here you can change where the minion is spawned. Most vanilla minions spawn at the cursor position.
			position = Main.MouseWorld;
			return true;
		}
	}
}