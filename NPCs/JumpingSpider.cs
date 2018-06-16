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

namespace AgheriumMod.NPCs
{
    public class JumpingSpider : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jumping Spider");
		}
		int queenCount;
		int jumpTimer = 51;
		bool jumped = false;
        public override void SetDefaults()
        {
			npc.scale = 1f;
            npc.width = 88;
            npc.height = 28;
            npc.damage = 58;
            npc.defense = 3;
            npc.lifeMax = 300;
            npc.value = Item.buyPrice(0, 0, 2, 50);
            npc.knockBackResist = 0f;
            npc.aiStyle = 0;
			Main.npcFrameCount[npc.type] = 2;
        }
        public override void AI()
        {
			Player player = Main.player[npc.target];
			if (jumpTimer <= 50)
			{
				jumpTimer++;
			}
			if (jumpTimer > 50 && jumped == false)
			{
				npc.velocity = npc.DirectionTo(player.Center) * 25;
				jumped = true;
			}
			if (npc.collideY)
			{
				if (npc.velocity.Y > 0 && jumped == true)
				{
					jumpTimer = 0;
					jumped = false;
				}
			}
			else
			{
				npc.velocity.Y += 0.2f;
			}
			queenCount = NPC.CountNPCS(mod.NPCType("SpiderQueen"));
			if (queenCount < 1)
			{
				npc.active = false;
			}
        }
        public override void FindFrame(int frameHeight)
        {
            if (!npc.collideY)
			{
				npc.frame.Y = 28;
			}
			else
			{
				npc.frame.Y = 0;
			}
        }
    }
}