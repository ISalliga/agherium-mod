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
using Terraria.ModLoader;

namespace AgheriumMod.NPCs.Bosses
{
    public class GuidesBow : ModNPC
	{
		public NPC parent;
		
		public int arrowTime = 0;
		
		public int SotG = 0;
		
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
			DisplayName.SetDefault("True Wooden Bow");
		}
        public override void SetDefaults()
        {
			vMax = 6;
			vAccel = 0.2f;
			npc.alpha = 50;
            npc.width = 60;
            npc.height = 60;
            npc.damage = 0;
            npc.defense = 9999;
            npc.lifeMax = 20;
            npc.knockBackResist = 0f;
            npc.aiStyle = 10;
            npc.noGravity = true;
			npc.noTileCollide = true;
			npc.lavaImmune = true;
        }
		public override bool PreAI()
		{
			parent = Main.npc[NPC.FindFirstNPC(mod.NPCType("SoulOfTheGuide"))];
			SotG = NPC.CountNPCS(mod.NPCType("SoulOfTheGuide"));
			if (SotG > 0)
			{
				npc.position.X = parent.Center.X - 25;
				npc.position.Y = parent.Center.Y - 30;
			}
			else
			{
				npc.active = false;
			}
			return true;
		}
        public override void AI()
        {
			Player player = Main.player[npc.target];
			{
				Vector2 playerPos;
				playerPos.X = player.Center.X;
				playerPos.Y = player.Center.Y;
				npc.rotation = npc.AngleTo(playerPos);
			}
			
			arrowTime++;
				if (arrowTime >= 80)
				{
                    float Speed = 10f;
                    Vector2 vector8 = new Vector2(npc.position.X + (npc.width / 2), npc.position.Y + (npc.height / 2));
					int damage = 18;
                    int type = mod.ProjectileType("SoulboundArrow");
                    float rotation = (float)Math.Atan2(vector8.Y - (player.position.Y + (player.height * 0.5f)), vector8.X - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, Main.myPlayer);
                    Main.projectile[num54].velocity.X += (float)Main.rand.Next(-20, 21) * 0.05f;
                    Main.projectile[num54].velocity.Y += (float)Main.rand.Next(-20, 21) * 0.05f;
                    Main.projectile[num54].netUpdate = true;
					arrowTime = 0;
				}
        }
		public override void FindFrame(int frameHeight)
		{
			npc.spriteDirection = 1;
		}
    }
}