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
        int despawn = 0;
        public int SpiderSpawn = 230;
        public int WebTime = 0;
        public int FangTime = 0;
        bool planteraalive = false;
        bool injungle = false;
        bool expert = false;
        bool saidJungle = false;
        bool saidPlantera = false;
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
            npc.defense = 12;
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
            Main.npcFrameCount[npc.type] = 3;
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
        }
        public override void AI()
        {
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
            if (despawn >= 120)
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
                    WebTime += 1;
                    FangTime += 1;
                }
                else if (injungle && !planteraalive)
                {
                    WebTime += 2;
                    FangTime += 2;
                }
                else if (injungle && planteraalive)
                {
                    WebTime += 4;
                    FangTime += 4;
                }
                if (WebTime >= 360 && Main.expertMode)
                {
                    {
                        float Speed = 20f;  //projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 55;  //projectile damage
                        int type = 472;  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    }
                    WebTime = 0;
                }
                if (FangTime >= 150)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        float Speed = 15f + Main.rand.Next(-10, 10);  //projectile speed
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 55;  //projectile damage
                        int type = mod.ProjectileType("Fang");  //put your projectile
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                    }
                    FangTime = 0;
                }
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
                NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("RocketSpider"));
            }
            npc.ai[0]++;
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(true);
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
            npc.spriteDirection = npc.direction;
        }
    }
}