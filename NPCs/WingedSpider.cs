using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using Microsoft.Xna.Framework.Graphics;

namespace AgheriumMod.NPCs
{
    public class WingedSpider : ModNPC
    {
		int queenCount;
        int dashTime = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Winged Spider");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 450;
            npc.aiStyle = 14;
            npc.damage = 36;
            Main.npcFrameCount[npc.type] = 4;
            npc.defense = 3;
            animationType = 62;
            npc.knockBackResist = 0f;
            npc.width = 50;
            npc.height = 66;
            npc.npcSlots = 0.5f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.scale = 1f;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }
		public override void AI()
		{
			queenCount = NPC.CountNPCS(mod.NPCType("SpiderQueen"));
			if (queenCount < 1)
			{
				npc.active = false;
			}
			Player player = Main.player[npc.target];
			dashTime++;
			if (dashTime > 240)
			{
				npc.velocity = npc.DirectionTo(player.Center) * 11;
			}
			if (dashTime > 300)
			{
				npc.velocity = npc.DirectionTo(player.Center) * 3;
				dashTime = 0;
			}
		}
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
    }
}