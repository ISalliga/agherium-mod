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

namespace AgheriumMod.NPCs.Bosses
{
    public class SpiderGuard : ModNPC
    {
        int spiderSpawn = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider Guardian");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 8000;
            npc.aiStyle = 17;
            npc.damage = 85;
            Main.npcFrameCount[npc.type] = 2;
            npc.defense = 10;
            animationType = 62;
            npc.knockBackResist = 0f;
            npc.width = 84;
            npc.height = 124;
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
            npc.lifeMax = 10000;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
    }
}