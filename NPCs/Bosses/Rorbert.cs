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
	[AutoloadBossHead]
    public class Rorbert : ModNPC
    {
        int spawn = 0;
        bool firstphasealive = true;
        bool secondphasealive = true;
        bool thirdphasealive = true;
        bool fourthphasealive = true;
        bool immortal = false;
        bool phase1 = false;
        bool phase2 = false;
        bool phase3 = false;
        bool phase4 = false;
        bool phase5 = false;
        int laser = 0;
        int gelshoot = 0;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rorbert");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 4600;
            npc.aiStyle = 2;
            npc.damage = 45;
            Main.npcFrameCount[npc.type] = 1;
            npc.defense = 5;
            npc.knockBackResist = 0f;
            npc.width = 158;
            npc.height = 158;
            npc.value = Item.buyPrice(0, 2, 0, 11);
            npc.npcSlots = 1.2f;
            npc.lavaImmune = true;
			npc.boss = true;
            npc.noGravity = false;
            npc.scale = 2f;
            npc.noTileCollide = false;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/meiosis_at_its_finest");
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            for (int k = 0; k < npc.buffImmune.Length; k++)
            {
                npc.buffImmune[k] = true;
            }
            aiType = 171;
        }
		public override void BossLoot(ref string name, ref int potionType)
        {
           if (!Main.expertMode)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MaterialBlob"), Main.rand.Next(26, 34));
                }
            }
            else
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RorbertBag"), 1);
            }
            potionType = ItemID.GreaterHealingPotion;
			AgheriumMod.downedRorbert = true;
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = 5100;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        public override void AI()
        {
			if (npc.timeLeft <= 1)
			{
				npc.active = false;
			}
			Player P = Main.player[npc.target];
            laser++;
            gelshoot++;
            if (NPC.CountNPCS(mod.NPCType("Orby2")) >= 1)
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
            if (firstphasealive)
            {
                firstphasealive = false;
                for (int I = 0; I < 5; I++)
                {
                    //cos = y, sin = x
                    if (spawn < 5)
                    {
                        spawn += 1;
                        int Orby = NPC.NewNPC((int)(npc.Center.X + (Math.Sin(I * 72) * 150)), (int)(npc.Center.Y + (Math.Cos(I * 72) * 150)), mod.NPCType("Orby2"), npc.whoAmI, 0, 0, 0, -1);
                        NPC Orby1 = Main.npc[Orby];
                        Orby1.ai[0] = I * 72;
                        Orby1.ai[3] = I * 72;
                    }
                }
            }
            if (secondphasealive && npc.life <= 4000)
            {
                secondphasealive = false;
                for (int I = 0; I < 5; I++)
                {
                    //cos = y, sin = x
                    if (spawn < 10)
                    {
                        spawn += 1;
                        int Orby = NPC.NewNPC((int)(npc.Center.X + (Math.Sin(I * 72) * 150)), (int)(npc.Center.Y + (Math.Cos(I * 72) * 150)), mod.NPCType("Orby2"), npc.whoAmI, 0, 0, 0, -1);
                        NPC Orby1 = Main.npc[Orby];
                        Orby1.ai[0] = I * 72;
                        Orby1.ai[3] = I * 72;
                    }
                }
            }
            if (thirdphasealive && npc.life <= 2700)
            {
                thirdphasealive = false;
                for (int I = 0; I < 5; I++)
                {
                    //cos = y, sin = x
                    if (spawn < 15)
                    {
                        spawn += 1;
                        int Orby = NPC.NewNPC((int)(npc.Center.X + (Math.Sin(I * 72) * 150)), (int)(npc.Center.Y + (Math.Cos(I * 72) * 150)), mod.NPCType("Orby2"), npc.whoAmI, 0, 0, 0, -1);
                        NPC Orby1 = Main.npc[Orby];
                        Orby1.ai[0] = I * 72;
                        Orby1.ai[3] = I * 72;
                    }
                }
            }
            if (fourthphasealive && npc.life <= 900)
            {
                fourthphasealive = false;
                for (int I = 0; I < 5; I++)
                {
                    //cos = y, sin = x
                    if (spawn < 20)
                    {
                        spawn += 1;
                        int Orby = NPC.NewNPC((int)(npc.Center.X + (Math.Sin(I * 72) * 150)), (int)(npc.Center.Y + (Math.Cos(I * 72) * 150)), mod.NPCType("Orby2"), npc.whoAmI, 0, 0, 0, -1);
                        NPC Orby1 = Main.npc[Orby];
                        Orby1.ai[0] = I * 72;
                        Orby1.ai[3] = I * 72;
                    }
                }
            }
            if (npc.life <= 3950)
            {
                phase1 = true;
            }
            if (npc.life <= 3075)
            {
                phase2 = true;
            }
            if (npc.life <= 2325)
            {
                phase3 = true;
            }
            if (npc.life <= 1700)
            {
                phase4 = true;
            }
            if (npc.life <= 925)
            {
                phase5 = true;
            }
            if (phase1)
            {
                if (laser >= 160)
                {
                    float Speed = 11.5f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 17;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    laser = 0;
                }
            }
            else if (phase2)
            {
                if (laser >= 115)
                {
                    float Speed = 11.5f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 19;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    laser = 0;
                }
                if (gelshoot >= 60)
                {
                    gelshoot = 0;
                    float Speed = 6f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 20;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 117);
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                }
            }
            else if (phase3)
            {
                if (laser >= 82)
                {
                    float Speed = 11.5f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 20;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    laser = 0;
                }
                if (gelshoot >= 40)
                {
                    gelshoot = 0;
                    float Speed = 6f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 21;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 117);
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                }
            }
            else if (phase4)
            {
                if (laser >= 50)
                {
                    float Speed = 11.5f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 21;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    laser = 0;
                }
                if (gelshoot >= 30)
                {
                    gelshoot = 0;
                    float Speed = 6f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 20;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 117);
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                }
            }
            else if (phase5)
            {
                if (laser >= 20)
                {
                    float Speed = 11.5f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 22;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    laser = 0;
                }
                if (gelshoot >= 15)
                {
                    gelshoot = 0;
                    float Speed = 6f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 20;  //projectile damage
                    int type = mod.ProjectileType("GelBounce");  //put your projectile
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 117);
                    float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                }
            }
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
    }
}