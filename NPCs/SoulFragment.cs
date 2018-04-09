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

namespace AgheriumMod.NPCs
{
    public class SoulFragment : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Fragment");
		}
        public override void SetDefaults()
        {
			npc.alpha = 255;
            npc.width = 16;
            npc.height = 20;
            npc.damage = 14;
            npc.defense = 2;
            npc.lifeMax = 55;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = Item.buyPrice(0, 0, 2, 50);
            npc.knockBackResist = 0f;
            npc.aiStyle = 56;
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
		public override void AI()
		{
			npc.alpha -= 10;
		}
	}
}