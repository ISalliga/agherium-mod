using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.World.Generation;
using Terraria.GameContent.Generation;
using System.IO;
using Terraria.GameContent.Events;
using Terraria.Localization;
using AgheriumMod;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace AgheriumMod.NPCs
{
    public class GlobalNPCThing : GlobalNPC
    {
		public bool moonburnt = false;
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
		public override void ResetEffects(NPC npc)
		{
			moonburnt = false;
		}
		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (moonburnt)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 16;
			}
		}
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == 439)
            {
				if (Main.rand.Next(1, 3) == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Smallinator"), 1);
				}
				else
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Biginator"), 1);
				}
            }
        }
    }
}