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
    public class EpicSlime : ModNPC
    {
		int dashTime = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Epic Slime");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 450;
            npc.aiStyle = 1;
            npc.damage = 35;
            npc.defense = 1;
            npc.knockBackResist = 0f;
            npc.width = 38;
            npc.height = 26;
            npc.value = Item.buyPrice(0, 4, 0, 0);
            npc.npcSlots = 0.5f;
            npc.lavaImmune = true;
            npc.noGravity = false;
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
            int chanceDrop = Main.rand.Next(1,2);
			
			if (chanceDrop == 1)
			{
				Main.NewText("An Epic has dropped! (Emblem of Arrows)", 155, 97, 174);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmblemOfArrows"), 1);
			}
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.000006f;
        }
        public override void AI()
        {
			dashTime += 2;
			Player player = Main.player[npc.target];
			if (NPC.downedBoss3 == true && Main.hardMode != true)
			{
				npc.lifeMax = 750;
				npc.damage = 50;
				npc.defense = 2;
			}
			if (Main.hardMode == true && NPC.downedMechBoss1 != true && NPC.downedMechBoss2 != true && NPC.downedMechBoss3 != true)
			{
				npc.lifeMax = 1100;
				npc.damage = 65;
				npc.defense = 3;
			}
			if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true && NPC.downedGolemBoss != true)
			{
				npc.lifeMax = 1450;
				npc.damage = 90;
				npc.defense = 4;
			}
			if (NPC.downedGolemBoss == true && NPC.downedMoonlord != true)
			{
				npc.lifeMax = 1750;
				npc.damage = 105;
				npc.defense = 5;
			}
			if (NPC.downedMoonlord == true)
			{
				npc.lifeMax = 2500;
				npc.damage = 175;
				npc.defense = 6;
			}
			
			if (dashTime > 250)
			{
				npc.velocity = npc.DirectionTo(player.Center) * 15;
				dashTime = 0;
			}
		}
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
    }
}