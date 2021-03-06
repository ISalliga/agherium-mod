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
    public class RocketSpider : ModNPC
    {
		int queenCount;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rocket Spider");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 300;
            npc.aiStyle = 74;
            npc.damage = 69;
            Main.npcFrameCount[npc.type] = 4;
            npc.defense = 3;
            npc.knockBackResist = 0f;
            npc.width = 50;
            npc.height = 66;
            npc.value = Item.buyPrice(0, 0, 0, 0);
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
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 420;
        }
		public override void AI()
		{
			queenCount = NPC.CountNPCS(mod.NPCType("SpiderQueen"));
			if (queenCount < 1)
			{
				npc.active = false;
			}
		}
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
			npc.frameCounter++;
			if (npc.frameCounter >= 4) // ticks per frame
			{
				npc.frame.Y = (npc.frame.Y / frameHeight + 1) % Main.npcFrameCount[npc.type] * frameHeight;
				npc.frameCounter = 0;
			}
        }
    }
}