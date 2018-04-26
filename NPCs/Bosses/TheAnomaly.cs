using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using AgheriumMod.NPCs.Bosses;
using AgheriumMod;
using Terraria.ModLoader;

namespace AgheriumMod.NPCs.Bosses
{
    [AutoloadBossHead]
    public class TheAnomaly : ModNPC
    {
		int start = 0;
		int start2 = 0;
		int proj1Time = 0;
		int projt = 0;
		int npct = 0;
		int tpTime = 0;
		int fireTime1 = 0;
		int npcSpawn = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Anomaly");
		}
        public override void SetDefaults()
        {
			npc.scale = 3f;
            npc.width = 60;
            npc.height = 96;
            npc.damage = 43;
            npc.defense = 6;
            npc.lifeMax = 40000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 3, 0, 0);
            npc.knockBackResist = 0f;
            npc.aiStyle = 22;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/error_404");
            npc.noGravity = true;
			npc.noTileCollide = true; 
			npc.buffImmune[BuffID.Poisoned] = true;
			npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.ShadowFlame] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Frostburn] = true;
			npc.buffImmune[BuffID.Daybreak] = true;
			npc.lavaImmune = true;
            Main.npcFrameCount[npc.type] = 12;
        }
		
		public virtual void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.defense = 7;
			npc.lifeMax = 60000;
		}
        public override void BossLoot(ref string name, ref int potionType)
        {
           if (!Main.expertMode)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UnloadedItem2"), Main.rand.Next(24, 36));
                }
            }
            else
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AnomalyBag"), 1);
            }
			AgheriumWorld.downedAnomaly = true;
			potionType = ItemID.GreaterHealingPotion;
        }
        public override void AI()
        {
			if (start == 0)
			{
				Main.NewText("O|-h, a -n-ew fr|en]]2d!", 0, 255, 0);
			}
			start++;
			Player player = Main.player[npc.target];
			tpTime++;
			if (Main.player[npc.target].dead || !Main.player[npc.target].active)
			{
				npc.active = false;
			}
			if (tpTime >= 240)
			{
				npc.position.X = Main.player[npc.target].position.X + Main.rand.Next(-350, 350);
				npc.position.Y = Main.player[npc.target].position.Y + Main.rand.Next(-350, 350);
			}
			if (tpTime >= 243)
			{
				tpTime = 0;
			}
			if (Main.expertMode)
			{
				fireTime1++;
				if (fireTime1 >= 75)
				{
					{
						float Speed = 9f;  //projectile speed
						Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
						int damage = 35;  //projectile damage
						int type = mod.ProjectileType("GlitchProj");  //put your projectile
						float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
						int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
						fireTime1 = 0;
					}
				}
			}
			if (!Main.expertMode)
			{
				if (npc.life <= npc.lifeMax * 0.3)
				{
					fireTime1++;
					if (fireTime1 >= 75)
					{
						{
							float Speed = 9f;  //projectile speed
							Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
							int damage = 35;  //projectile damage
							int type = mod.ProjectileType("GlitchProj");  //put your projectile
							float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
							int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
							fireTime1 = 0;
						}
					}
				}
			}
			if (npc.life <= npc.lifeMax * 0.8)
			{
				npcSpawn++;
				int npcType = Main.rand.Next(1, 11);
				if (npcType == 1)
				{
					npct = 140;
				}
				if (npcType == 2)
				{
					npct = 141;
				}
				if (npcType == 3)
				{
					npct = 153;
				}
				if (npcType == 4)
				{
					npct = 174;
				}
				if (npcType == 5)
				{
					npct = 251;
				}
				if (npcType == 6)
				{
					npct = 257;
				}
				if (npcType == 7)
				{
					npct = 156;
				}
				if (npcType == 8)
				{
					npct = 316;
				}
				if (npcType == 9)
				{
					npct = 163;
				}
				if (npcType == 10)
				{
					npct = 172;
				}
				if (npcType == 11)
				{
					npct = 182;
				}
				if (npcSpawn >= 260)
				{
					int num394 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, npct);
					Main.npc[num394].lifeMax = 3000;
					Main.npc[num394].defense = 4;
					npcSpawn = 0;
				}
			}
			if (npc.life <= npc.lifeMax * 0.6)
			{
				proj1Time++;
				int projType1 = Main.rand.Next(1, 5);
				if (projType1 == 1)
				{
					projt = 185;
				}
				if (projType1 == 2)
				{
					projt = 184;
				}
				if (projType1 == 3)
				{
					projt = 288;
				}
				if (projType1 == 4)
				{
					projt = 291;
				}
				if (projType1 == 5)
				{
					projt = 240;
				}
				if (proj1Time >= 120)
				{
					Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float spread = 45f * 0.0174f;
                    double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y) - spread / 2;
                    double deltaAngle = spread / 5f;
                    double offsetAngle;
					int damage = 76;
                    int projectileShot = 100;
                    int i;
                    for (i = 0; i < 5; i++)
					{
						offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
						Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projt, damage, 0f, Main.myPlayer, 0f, 0f);
					}
					proj1Time = 0;
				}
			}
			if (npc.life <= npc.lifeMax * 0.5)
			{
				tpTime++;
			}
		}
		public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
			npc.frameCounter++;
			if (npc.frameCounter >= 6) // ticks per frame
			{
				npc.frame.Y = (npc.frame.Y / frameHeight + 1) % Main.npcFrameCount[npc.type] * frameHeight;
				npc.frameCounter = 0;
			}
        }
    }
}