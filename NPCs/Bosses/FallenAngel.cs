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
    public class FallenAngel : ModNPC
    {
        public int phase = 0;
        int despawn = 10;
        bool saidPhase2 = false;
        int phasechangetime = 0;
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
            npc.defense = 14;
            npc.lifeMax = 19800;
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
            phasechangetime++;
            if (Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                despawn--;
            }
            if (despawn < 1)
            {
                npc.active = false;
            }
            if (phasechangetime >= 370)
            {
                phasechangetime = 0;
            }
            if (npc.life <= npc.lifeMax * 0.5f)
            {
                phase++;
                if (!saidPhase2)
                {
                    saidPhase2 = true;
                    {
                        
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
            if (phase <= 1)
            {
                if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
                {
                    npc.TargetClosest(true);
                }
                npc.netUpdate = true;
                if (phasechangetime == 120 || phasechangetime == 240 || phasechangetime == 360)
                {
                    if (Main.rand.Next(30) == 0)
                    {
                        
                    }
                    Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                    float spread = 45f * 0.0174f;
                    double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y) - spread / 2;
                    double deltaAngle = spread / 8f;
                    double offsetAngle;
                    int damage = 20;
                    int projectileShot = 100;
                    int i;
                    for (i = 0; i < 7; i++)
                    {
                        offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                        Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (phasechangetime == 150)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        float Speed = 3.5f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 20;
                        int type = mod.ProjectileType("MiniArchorb");
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                        Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                    }
                }
                if (phasechangetime == 155)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        float Speed = 3.5f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 20;
                        int type = mod.ProjectileType("MiniArchorb");
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                        Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                        Main.projectile[num54].netUpdate = true;
                    }
                }
                if (phasechangetime == 160)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        float Speed = 3.5f;
                        Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                        int damage = 20;
                        int type = mod.ProjectileType("MiniArchorb");
                        float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                        int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                        Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                        Main.projectile[num54].netUpdate = true;
                    }
                }
            }
            else
            {
                {
                    if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
                    {
                        npc.TargetClosest(true);
                    }
                    npc.netUpdate = true;
                    if (phasechangetime == 90 || phasechangetime == 180 || phasechangetime == 270 || phasechangetime == 360)
                    {
                        Vector2 value9 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float spread = 45f * 0.0174f;
                        double startAngle = Math.Atan2(npc.velocity.X, npc.velocity.Y) - spread / 2;
                        double deltaAngle = spread / 8f;
                        double offsetAngle;
                        int damage = 20;
                        int projectileShot = 100;
                        int i;
                        for (i = 0; i < 10; i++)
                        {
                            offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                            Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (phasechangetime == 80)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            float Speed = 9.25f;
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 28;
                            int type = mod.ProjectileType("MegaArchorb");
                            float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                            Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                            Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                            Main.projectile[num54].netUpdate = true;
                        }
                    }
                    if (phasechangetime == 160)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            float Speed = 9.25f;
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 28;
                            int type = mod.ProjectileType("MegaArchorb");
                            float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                            Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                            Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                            Main.projectile[num54].netUpdate = true;
                        }
                    }
                    if (phasechangetime == 240)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            float Speed = 9.25f;
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 28;
                            int type = mod.ProjectileType("MegaArchorb");
                            float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                            Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                            Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                            Main.projectile[num54].netUpdate = true;
                        }
                    }
                    if (phasechangetime >= 355)
                    {
                        if (Main.rand.Next(30) == 0)
                        {
                        }
                        {
                            float Speed = 1f + (Main.rand.Next(1, 8));
                            Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                            int damage = 20;
                            int type = 38;
                            float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                        }
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