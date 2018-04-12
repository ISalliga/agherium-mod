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
    public class SoulOfTheGuide : ModNPC
    {
		public int bowCount = 0;
		public int fragCount = 0;
		
		public bool invPhase = false;
		public bool invPhaseBegin = false; 
		public bool bowActive = false;
		
		public bool phase2Entered = false;
		public bool phase3Entered = false;
		
		public int orbTime = 0;
		public int fragTime = 0;
		
		public float targetX = 0;
		public float targetY = 0;
		
		public int vMax = 0;
		public float vAccel = 0;
		public float tVel = 0;
		public float vMag = 0;
		
        public int phase = 0;
        int despawn = 10;
        bool saidPhase2 = false;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul of the Guide");
		}
        public override void SetDefaults()
        {
			invPhaseBegin = true;
			vMax = 6;
			vAccel = 0.35f;
			npc.scale = 1f;
            npc.width = 50;
            npc.height = 60;
            npc.damage = 15;
            npc.defense = 2;
            npc.lifeMax = 2500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 3, 0, 0);
            npc.knockBackResist = 0f;
            npc.aiStyle = 22;
            npc.boss = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/sanity_at_stake");
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
			animationType = 94;
        }
		public virtual void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.defense = 3;
			npc.lifeMax = 4000;
			vAccel = 0.45f;
			vMax = 8;
		}
        public override void BossLoot(ref string name, ref int potionType)
        {
           if (!Main.expertMode)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulShard"), Main.rand.Next(4, 6));
                }
            }
            else
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulBag"), 1);
            }
			AgheriumWorld.downedSoul = true;
        }
        public override void AI()
        {
			//Basics
			bowCount = NPC.CountNPCS(mod.NPCType("GuidesBow"));
			
			Player player = Main.player[npc.target];
            targetX = player.Center.X;
			targetY = player.Center.Y - 100;
			
			float dist = ((float)(Math.Sqrt((targetX - npc.Center.X) * (targetX - npc.Center.X) + (targetY - npc.Center.Y) * (targetY - npc.Center.Y))));
			tVel = dist / 20;
			if (vMag < vMax && vMag < tVel)
			{
				vMag += vAccel;
			}
			if (vMag > tVel)
			{
				vMag -= vAccel;
			}
			
			if (dist != 0)
			{
				Vector2 tPos;
				tPos.X = targetX;
				tPos.Y = targetY;
				npc.velocity = npc.DirectionTo(tPos) * vMag;
			}
			
			// Invincibility Phases
			if (bowCount == 0 && invPhaseBegin == true)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GuidesBow"));
				invPhaseBegin = false;
			}
			
			if (npc.life <= npc.lifeMax * 0.6 && phase2Entered == false)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GuidesBow"));
				phase2Entered = true;
			}
			
			if (npc.life <= npc.lifeMax * 0.3 && phase3Entered == false)
			{
				NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("GuidesBow"));
				phase3Entered = true;
			}
			
			if (bowCount > 0)
			{
				npc.dontTakeDamage = true;
			}
			else
			{
				npc.dontTakeDamage = false;
			}
			
			// Attacking and Stuff
			fragCount = NPC.CountNPCS(mod.NPCType("SoulFragment"));
			if (bowCount < 1)
			{
				fragTime++;
				if (fragTime >= 240 && fragCount < 3)
				{
					NPC.NewNPC((int)npc.Center.X + 50, (int)npc.Center.Y, mod.NPCType("SoulFragment"));
					NPC.NewNPC((int)npc.Center.X - 50, (int)npc.Center.Y, mod.NPCType("SoulFragment"));
					if (Main.expertMode && Main.rand.Next(1, 2) == 1)
					{
						NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 50, mod.NPCType("SoulFragment"));
					}
					fragTime = 0;
				}
				if (fragCount > 2)
				{
					fragTime = 0;
				}
			}
			
			if (npc.life < npc.lifeMax * 0.3)
			{
				orbTime++;
				if (orbTime >= 85)
				{
					float Speed = 9f;  //projectile speed
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
                    int damage = 18;  //projectile damage
                    int type = mod.ProjectileType("SoulOrb");  //put your projectile
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    orbTime = 0;
				}
			}
        }
        public override void FindFrame(int frameHeight)
        {
            npc.spriteDirection = npc.direction;
        }
    }
}