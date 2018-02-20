using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AgheriumMod;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.NPCs.Bosses
{
    [AutoloadBossHead]
    public class FallenAngel : ModNPC
    {
        public int phase = 1;
        public int despawn = 10;
		public int teleportTime = 0;
		public int laserSpreadTime = 0;
		public int laserSpreadChance = 0;
		public int laserOrbTime = 0;
		public int laserOrbTime2 = 0;
		public int teleportType = 0;
        public bool saidPhase2 = false;
		public bool saidPhase3 = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Fallen Angel");
		}
        public override void SetDefaults()
        {
			npc.scale = 1f;
            npc.width = 24;
            npc.height = 48;
            npc.damage = 37;
            npc.defense = 3;
            npc.lifeMax = 10500;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 3, 0, 0);
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/angelic_modernization");
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
        }
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
		    npc.lifeMax = (int)(npc.lifeMax + (npc.lifeMax * 0.625f) * bossLifeScale);
			npc.damage += (int)(npc.damage * 0.6f);
			npc.defense = (int)(npc.defense + numPlayers);
		}
        public override void BossLoot(ref string name, ref int potionType)
        {
           if (!Main.expertMode)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarklightEssence"), Main.rand.Next(26, 34));
                }
            }
            else
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AngelBag"), 1);
            }
            potionType = ItemID.GreaterHealingPotion;
        }
        public override void AI()
        {
            if (Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                despawn--;
            }
            if (despawn < 1)
            {
                npc.active = false;
            }
            if (npc.life <= npc.lifeMax * 0.75f)
            {
                phase = 2;
                if (!saidPhase2)
                {
                    saidPhase2 = true;
                    {
                        Main.NewText("Oh, but we're just getting started!", 255, 0, 0);
                    }
                }
            }
			if (npc.life <= npc.lifeMax * 0.35f)
            {
                phase = 3;
                if (!saidPhase3)
                {
                    saidPhase3 = true;
                    {
                        Main.NewText("Think you've got me all figured out, eh? Well say hi to my robot clones for me!", 255, 0, 0);
						NPC.NewNPC((int)npc.Center.X - Main.rand.Next(-250, 250), (int)npc.Center.Y - Main.rand.Next(-250, 250), mod.NPCType("AngelClone"));
						NPC.NewNPC((int)npc.Center.X - Main.rand.Next(-250, 250), (int)npc.Center.Y - Main.rand.Next(-250, 250), mod.NPCType("AngelClone2"));
                    }
                }
            }
            npc.ai[0]++;
            Player P = Main.player[npc.target];
            float maxSpeed;
            {
                maxSpeed = 5.1f;
            }
            Vector2 toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y - 100);
            toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
            toTarget.Normalize();
            npc.velocity = toTarget * maxSpeed;
            npc.velocity = toTarget * maxSpeed;
			
			if (phase == 1)
			{
				laserSpreadTime++;
				laserSpreadChance = Main.rand.Next(0, 4);
				if (laserSpreadTime >= 70)
				{
					if (laserSpreadChance == 1)
					{
						Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float spread = 45f * 0.0174f;
                    double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y) - spread / 2;
                    double deltaAngle = spread / 8f;
                    double offsetAngle;
					int damage = 32;
                    int projectileShot = 100;
                    int i;
                    for (i = 0; i < 7; i++)
						{
							offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
							Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
							Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
						}
					}
					laserSpreadTime = 0;
				}
			}
			
			if (phase >= 2)
			{
				teleportTime++;
				if (teleportTime >= 240)
				{
					teleportType = Main.rand.Next(1, 4);
					Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float spread = 45f * 0.0174f;
                    double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y) - spread / 2;
                    double deltaAngle = spread / 8f;
                    double offsetAngle;
					int damage = 31;
                    int projectileShot = 100;
                    int i;
                    for (i = 0; i < 7; i++)
					{
						offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
						Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
						Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
					}
					if (teleportType == 1)
					{
					npc.position.X = Main.player[npc.target].position.X - Main.rand.Next(-350, -250);
					npc.position.Y = Main.player[npc.target].position.Y;
					}
					if (teleportType == 2)
					{
					npc.position.X = Main.player[npc.target].position.X - Main.rand.Next(250, 350);
					npc.position.Y = Main.player[npc.target].position.Y;
					}
					if (teleportType == 3)
					{
					npc.position.X = Main.player[npc.target].position.X;
					npc.position.Y = Main.player[npc.target].position.Y - Main.rand.Next(250, 350);
					}
					if (teleportType == 4)
					{
					npc.position.X = Main.player[npc.target].position.X;
					npc.position.Y = Main.player[npc.target].position.Y - Main.rand.Next(-350, -250);
					}
					teleportTime = 0;
				}
			}
			
			laserOrbTime++;
				if (laserOrbTime >= 180)
				{
					for (int k = 0; k < 3; k++)
                    {
                        float Speed = 6.5f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
						int damage = 29;
                        int type = mod.ProjectileType("MiniArchorb");
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                        Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                        Main.projectile[num54].netUpdate = true;
                    }
					laserOrbTime = 0;
				}
			if (Main.expertMode)
			{
				if (phase >= 2)
				{
					laserOrbTime2++;
					if (laserOrbTime2 >= 320)
					{
						for (int k = 0; k < 3; k++)
						{
							float Speed = 6.001f;  //projectile speed
							Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
							int damage = 27;
							int type = mod.ProjectileType("MegaArchorb");  //put your projectile
							float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
							int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
							laserOrbTime2 = 0;
						}
						laserOrbTime2 = 0;
					}
				}
			}
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
    }
}