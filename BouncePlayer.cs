using BounceBack.Dusts;
using BounceBack.Items;
using BounceBack.NPCs;
using BounceBack.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace BounceBack
{
	public class BouncePlayer : ModPlayer
	{
		public bool ramenCatPet;
		public bool ballMagnet;
		public bool ballPolish;
		public bool boundChest;
		public bool boundLegs;
		public bool boundHead;
		public bool boundSet;
		public bool roseHead;
		public bool roseChest;
		public bool roseSet;
		public bool bouncierBuff;
		public bool markOfTryp;

		public override void ResetEffects() {
			ramenCatPet = false;
			ballPolish = false;
			ballMagnet = false;
			boundChest = false;
			boundHead = false;
			boundLegs = false;
			boundSet = false;
			roseHead = false;
			roseChest = false;
			roseSet = false;
			bouncierBuff = false;
	}
		// In MP, other clients need accurate information about your player or else bugs happen.
		// clientClone, SyncPlayer, and SendClientChanges, ensure that information is correct.
		// We only need to do this for data that is changed by code not executed by all clients, 
		// or data that needs to be shared while joining a world.
		// For example, examplePet doesn't need to be synced because all clients know that the player is wearing the ExamplePet item in an equipment slot. 
		// The examplePet bool is set for that player on every clients computer independently (via the Buff.Update), keeping that data in sync.
		// ExampleLifeFruits, however might be out of sync. For example, when joining a server, we need to share the exampleLifeFruits variable with all other clients.
		// In addition, in ExampleUI we have a button that toggles "Non-Stop Party". We need to sync this whenever it changes.
		public override void clientClone(ModPlayer clientClone) {
			BouncePlayer clone = clientClone as BouncePlayer;
		}

		//public override void SyncPlayer(int toWho, int fromWho, bool newPlayer) {
		//	ModPacket packet = mod.GetPacket();
		//	packet.Write((byte)BounceBackMessageType.BouncePlayerSyncPlayer);
		//	packet.Write((byte)player.whoAmI);
		//	packet.Send(toWho, fromWho);
		//}
		public override void UpdateDead() {

		}
		//public override void UpdateBiomes() {
		//	ZoneExample = ExampleWorld.exampleTiles > 50;
		//}

		//public override bool CustomBiomesMatch(Player other) {
		//	BouncePlayer modOther = other.GetModPlayer<BouncePlayer>();
		//	return ZoneExample == modOther.ZoneExample;
			// If you have several Zones, you might find the &= operator or other logic operators useful:
			// bool allMatch = true;
			// allMatch &= ZoneExample == modOther.ZoneExample;
			// allMatch &= ZoneModel == modOther.ZoneModel;
			// return allMatch;
			// Here is an example just using && chained together in one statemeny 
			// return ZoneExample == modOther.ZoneExample && ZoneModel == modOther.ZoneModel;
		//}

		//public override void CopyCustomBiomesTo(Player other) {
		//	BouncePlayer modOther = other.GetModPlayer<BouncePlayer>();
		//	modOther.ZoneExample = ZoneExample;
		//}

		//public override void SendCustomBiomes(BinaryWriter writer) {
		//	BitsByte flags = new BitsByte();
		//	flags[0] = ZoneExample;
		//	writer.Write(flags);
		//}

		//public override void ReceiveCustomBiomes(BinaryReader reader) {
		//	BitsByte flags = reader.ReadByte();
		//	ZoneExample = flags[0];
		//}

		//public override void UpdateBiomeVisuals() {
		//	bool usePurity = NPC.AnyNPCs(ModContent.NPCType<PuritySpirit>());
		//	player.ManageSpecialBiomeVisuals("ExampleMod:PuritySpirit", usePurity);
		//	bool useVoidMonolith = voidMonolith && !usePurity && !NPC.AnyNPCs(NPCID.MoonLordCore);
		//	player.ManageSpecialBiomeVisuals("ExampleMod:MonolithVoid", useVoidMonolith, player.Center);
		//}

		//public override Texture2D GetMapBackgroundImage() {
		//	if (ZoneExample) {
		//		return mod.GetTexture("ExampleBiomeMapBackground");
		//	}
		//	return null;
		//}
	}
}
