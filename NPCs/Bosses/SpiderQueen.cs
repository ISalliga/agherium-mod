using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.NPCs.Bosses
{
    [AutoloadBossHead]
    public class SpiderQueen : ModNPC
    {
		int venomtime = 0;
		int fangtime = 0;
        int despawn = 0;
		int crosshairTime = 0;
		int webtime = 0;
        bool planteraalive = false;
        bool injungle = false;
        bool expert = false;
		int SpiderSpawn = 230;
        bool saidJungle = false;
        bool saidPlantera = false;
		bool invPhase1 = false;
		bool invPhase2 = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aarhac'n, the Spider Queen");
		}
        public override void SetDefaults()
        {
			npc.scale = 1.5f;
            npc.width = 120;
            npc.height = 136;
            npc.damage = 150;
            npc.defense = 9;
            npc.lifeMax = 44200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 11, 7, 44);
            npc.knockBackResist = 0f;
            npc.aiStyle = 10;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/bloodthirsty_inhumanity"); 
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
            Main.npcFrameCount[npc.type] = 1;
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
           if (!Main.expertMode)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SmoothSilk"), Main.rand.Next(29, 37));
                }
            }
            else
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiderBag"), 1);
            }
            potionType = ItemID.GreaterHealingPotion;
			AgheriumWorld.downedSpodermen = true;
        }
        public override void AI()
        {
			fangtime++;
			if (fangtime > 180)
			{
				Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
				float spread = 25f * 0.0174f;
				double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y) - spread / 2;
				double deltaAngle = spread / 8f;
				double offsetAngle;
				int damage = 32;
				int projectileShot = mod.ProjectileType("Fang");
				int i;
				for (i = 0; i < 4; i++)
				{
					offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
					Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
				}
				fangtime = 0;
			}
            if (Main.expertMode)
            {
                expert = true;
            }
            Player P = Main.player[npc.target];
            Player player = Main.player[npc.target];
            if (P.ZoneJungle)
            {
                injungle = true;
            }
            else
            {
                injungle = false;
            }
            if (Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
				npc.velocity = npc.DirectionTo(player.Center) * -despawn;
                despawn++;
            }
            venomtime++;
            if (venomtime >= 600)
            {
                venomtime = 0;
                npc.TargetClosest(true);
                if (Collision.CanHit(npc.position, npc.width, npc.height, player.position, player.width, player.height))
                {
                    float num179 = 0.1f;
                    Vector2 selfposition = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float num180 = player.position.X + (float)player.width * 0.5f - selfposition.X;
                    float num181 = Math.Abs(num180) * 0.1f;
                    float num182 = player.position.Y + (float)player.height * 0.5f - selfposition.Y - num181;
                    float num183 = (float)Math.Sqrt((double)(num180 * num180 + num182 * num182));
                    npc.netUpdate = true;
                    num183 = num179 / num183;
                    num180 *= num183;
                    num182 *= num183;
                    int num184 = 50;
                    int num185 = mod.ProjectileType("VenomOrb");
                    selfposition.X += num180;
                    selfposition.Y += num182;
                    for (int num186 = 0; num186 < 5; num186++)
                    {
                        num180 = player.position.X + (float)player.width * 0.5f - selfposition.X;
                        num182 = player.position.Y + (float)player.height * 0.5f - selfposition.Y;
                        num183 = (float)Math.Sqrt((double)(num180 * num180 + num182 * num182));
                        num183 = 12f / num183;
                        num180 += Main.rand.Next(-100, 100);
                        num182 += Main.rand.Next(-100, 100);
                        num180 *= num183;
                        num182 *= num183;
                        int venom = Projectile.NewProjectile(selfposition.X, selfposition.Y, num180, num182, num185, num184, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[venom].velocity.Y -= 3f;
                    }
                }
            }
            if (despawn >= 30)
            {
                npc.active = false;
            }
            if (!saidJungle && P.ZoneJungle)
            {
                saidJungle = true;
                Main.NewText("Get me away from this wretched jungle!", 168, 47, 47);
            }
            if (!saidPlantera && planteraalive)
            {
                saidPlantera = true;
                Main.NewText("GET THAT GMO-RIDDEN MONSTROSITY AWAY FROM ME!!", 204, 0, 0);
            }
            if (NPC.CountNPCS(NPCID.Plantera) >= 1)
            {
                planteraalive = true;
            }
            else
            {
                planteraalive = false;
            }
            {
                if (!injungle && !planteraalive)
                {
					venomtime += 1;
                }
                else if (injungle && !planteraalive)
                {
                    venomtime += 2;
                }
                else if (injungle && planteraalive)
                {
                    venomtime += 4;
                }
                if (webtime >= 360 && Main.expertMode)
                {
                    {
                        float Speed = 20f;  //projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 55;  //projectile damage
                        int type = 472;  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    }
                    webtime = 0;
                }
				if (!injungle && !planteraalive)
				{
					SpiderSpawn -= 1;
				}
				if (injungle && !planteraalive)
				{
					SpiderSpawn -= 2;
				}
				if (injungle && planteraalive)
				{
					SpiderSpawn -= 5;
				}
				if (SpiderSpawn <= 0)
				{
					SpiderSpawn += 230;
					{
						int spawnedSpider = Main.rand.Next(1,4);
						if (spawnedSpider == 1)
						{
							float Speed = 9f;  //projectile speed
							Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
							int damage = 18;  //projectile damage
							int type = mod.ProjectileType("PropelledSpider");  //put your projectile
							float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
							int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
						}
						else if (spawnedSpider == 2)
						{
							NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("JumpingSpider"));
						}
						else if (spawnedSpider == 3)
						{
							NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-50, 50), (int)npc.Center.Y + Main.rand.Next(-50, 50), mod.NPCType("WingedSpider"));
						}
					}
				}
				npc.ai[0]++;
				if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
				{
					npc.TargetClosest(true);
				}
			}
			if (npc.life < npc.lifeMax * 0.5)
			{
				crosshairTime++;
				if (crosshairTime > 230)
				{
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-600, 600), npc.Center.Y + Main.rand.Next(-600, 600), 0,  0, mod.ProjectileType("RocketCrosshair"), 0, 0f, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-600, 600), npc.Center.Y + Main.rand.Next(-600, 600), 0,  0, mod.ProjectileType("RocketCrosshair"), 0, 0f, Main.myPlayer);
					Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-600, 600), npc.Center.Y + Main.rand.Next(-600, 600), 0,  0, mod.ProjectileType("RocketCrosshair"), 0, 0f, Main.myPlayer);
					if (Main.expertMode)
					{
						Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-600, 600), npc.Center.Y + Main.rand.Next(-600, 600), 0,  0, mod.ProjectileType("RocketCrosshair"), 0, 0f, Main.myPlayer);
					}
					crosshairTime = 0;
				}
			}
			npc.spriteDirection = 0;
        }
    }
}