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

namespace AgheriumMod.NPCs.Minibosses
{
    public class OrbyClone : ModNPC
    {
        int duplicatetime = 0;
        bool immortal = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orby Clone");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 25;
            npc.aiStyle = 14;
            npc.damage = 32;
            Main.npcFrameCount[npc.type] = 3;
            npc.defense = 1;
            animationType = 94;
            npc.knockBackResist = 0f;
            npc.width = 60;
            npc.height = 88;
            npc.value = Item.buyPrice(0, 0, 0, 0);
            npc.npcSlots = 0.5f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.scale = 1f;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit19;
            npc.DeathSound = SoundID.NPCDeath23;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 32;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
        public override void AI()
        {
            if (NPC.CountNPCS(mod.NPCType("OrbyClone")) >= 25)
            {
                npc.active = false;
            }
        }
    }
}