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
    public class Orby : ModNPC
    {
        int duplicatetime = 0;
        bool immortal = false;
        int spawned = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orby");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 450;
            npc.aiStyle = 17;
            npc.damage = 45;
            Main.npcFrameCount[npc.type] = 3;
            npc.defense = 1;
            animationType = 94;
            npc.knockBackResist = 0f;
            npc.width = 60;
            npc.height = 88;
            npc.value = Item.buyPrice(0, 0, 1, 0);
            npc.npcSlots = 0.5f;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.scale = 2f;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit19;
            npc.DeathSound = SoundID.NPCDeath23;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
        }
		public override void NPCLoot()
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StrangeMachine"), 1);
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 450;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.003f;
        }
        public override void AI()
        {
            if (spawned < 1)
            {
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("OrbyClone"));
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("OrbyClone"));
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("OrbyClone"));
                spawned++;
            }
            if (NPC.CountNPCS(mod.NPCType("OrbyClone")) >= 1)
            {
                immortal = true;
            }
            else
            {
                immortal = false;
            }
            if (immortal)
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.dontTakeDamage = false;
            }
            duplicatetime++;
            if (duplicatetime >= 120)
            {
                duplicatetime -= 120;
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("OrbyClone"));
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("OrbyClone"));
                NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("OrbyClone"));
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            AgheriumWorld.downedOrb = true;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
    }
}