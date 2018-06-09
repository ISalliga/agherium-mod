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
		bool hasMax = false;
		int dashTime = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Epic Slime");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 450;
            npc.aiStyle = 1;
            npc.damage = 10;
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
            int chanceDrop = Main.rand.Next(1,3);
			
			if (chanceDrop == 1)
			{
				Main.NewText("An Epic has dropped! (Emblem of Arrows)", 155, 97, 174);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EmblemOfArrows"), 1);
			}
			if (chanceDrop == 2)
			{
				Main.NewText("An Epic has dropped! (Furious Emblem)", 155, 97, 174);
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FuriousEmblem"), 1);
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
				npc.damage = 20;
				npc.defense = 2;
			}
			if (Main.hardMode == true && NPC.downedMechBoss1 != true && NPC.downedMechBoss2 != true && NPC.downedMechBoss3 != true)
			{
				npc.lifeMax = 1100;
				npc.damage = 30;
				npc.defense = 3;
			}
			if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true && NPC.downedGolemBoss != true)
			{
				npc.lifeMax = 1450;
				npc.damage = 40;
				npc.defense = 4;
			}
			if (NPC.downedGolemBoss == true && NPC.downedMoonlord != true)
			{
				npc.lifeMax = 1750;
				npc.damage = 50;
				npc.defense = 5;
			}
			if (NPC.downedMoonlord == true)
			{
				npc.lifeMax = 2500;
				npc.damage = 60;
				npc.defense = 6;
			}
			
			if (hasMax == false)
			{
				npc.life = npc.lifeMax;
				hasMax = true;
			}
			
			if (dashTime >= 250)
			{
				npc.velocity = npc.DirectionTo(player.Center) * 15;
				if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true)
				{
					{
						Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
						float spread = 25f * 0.0174f;
						double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y) - spread / 2;
						double deltaAngle = spread / 8f;
						double offsetAngle;
						int damage = npc.damage * (int)0.6f;
						int projectileShot = 100;
						int i;
						for (i = 0; i < 4; i++)
						{
							offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
							Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
							Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
						}
					}
				}
				dashTime = 0;
			}
		}
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;

        }
    }
}
//