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
    public class AngelClone : ModNPC
    {
        public int despawn = 10;
		public int teleportTime = 0;
		public int laserSpreadTime = 0;
		public int laserSpreadChance = 0;
		public int teleportChance = 0;
		public int laserOrbTime = 0;
		public int teleportType = 0;
        public bool saidPhase2 = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Fallen Angel");
		}
        public override void SetDefaults()
        {
			npc.scale = 1f;
            npc.width = 24;
            npc.height = 48;
            npc.damage = 24;
            npc.defense = 3;
			Main.npcFrameCount[npc.type] = 5;
            npc.lifeMax = 7000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 3, 0, 0);
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
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
        public override void AI()
        {
			int angelCount = NPC.CountNPCS(mod.NPCType("FallenAngel"));
            if (Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                despawn--;
            }
            if (despawn < 1)
            {
                npc.active = false;
            }
            npc.ai[0]++;
            Player P = Main.player[npc.target];
            float maxSpeed;
            {
                maxSpeed = 3.1f;
            }
            Vector2 toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y - 100);
            toTarget = new Vector2(P.Center.X - npc.Center.X, P.Center.Y - npc.Center.Y);
            toTarget.Normalize();
            npc.velocity = toTarget * maxSpeed;
            npc.velocity = toTarget * maxSpeed;
			
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
                int damage = 15;
                int projectileShot = 100;
                int i;
                for (i = 0; i < 7; i++)
				{
					offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
					Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
					Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
				}
				}
			}
			laserSpreadTime = 0;
			
			{
				teleportTime++;
				if (teleportTime >= 200)
				{
					{
					teleportType = Main.rand.Next(1, 4);
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
			}
			
			laserOrbTime++;
				if (laserOrbTime >= 180)
				{
					for (int k = 0; k < 3; k++)
                    {
						float Speed = 6.001f;  //projectile speed
						Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
						int damage = 17;  //projectile damage
						int type = mod.ProjectileType("MiniArchorb");  //put your projectile
						float rotation = (float)Math.Atan2(vector8.Y - (P.position.Y + (P.height * 0.5f)), vector8.X - (P.position.X + (P.width * 0.5f)));
						int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
						laserOrbTime = 0;
                    }
				}
			if (angelCount == 0)
			{
				npc.active = false;
			}
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
			npc.frameCounter++;
			if (npc.frameCounter >= 5) // ticks per frame
			{
				npc.frame.Y = (npc.frame.Y / frameHeight + 1) % Main.npcFrameCount[npc.type] * frameHeight;
				npc.frameCounter = 0;
			}
        }
    }
}