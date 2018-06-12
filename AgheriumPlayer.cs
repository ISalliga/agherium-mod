using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using AgheriumMod;
using AgheriumMod.Items;
using AgheriumMod.Items.MiscGear;

namespace AgheriumMod
{
	public class AgheriumPlayer : ModPlayer
	{
		int dmgValue = 0;
		public bool taxonGreaves = false;
		public bool taxonSetBonus = false;
		public bool taxonSetBonus2 = false;
		public bool ARROWS = false;
		public bool isFuryBeingForged = false;
		public override void ResetEffects()
		{
			isFuryBeingForged = false;
			taxonGreaves = false;
			taxonSetBonus = false;
			taxonSetBonus2 = false;
		}
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (isFuryBeingForged == true)
			{
				if (Main.hardMode != true)
				{
					dmgValue = 15;
				}
				if (NPC.downedBoss3 == true && Main.hardMode != true)
				{
					dmgValue = 30;
				}
				if (Main.hardMode == true && NPC.downedMechBoss1 != true && NPC.downedMechBoss2 != true && NPC.downedMechBoss3 != true)
				{
					dmgValue = 50;
				}
				if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true && NPC.downedGolemBoss != true)
				{
					dmgValue = 70;
				}
				if (NPC.downedGolemBoss == true && NPC.downedMoonlord != true)
				{
					dmgValue = 90;
				}
				if (NPC.downedMoonlord == true)
				{
					dmgValue = 120;
				}
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("FuryJet"), dmgValue, 0.5f, player.whoAmI, 0.0f, 0.0f);
			}
			if (taxonGreaves == true)
			{
				player.AddBuff(mod.BuffType("TaxonBoost"), 180);
			}
		}
		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			if (taxonSetBonus == true)
			{
				if (crit == true)
				{
					player.AddBuff(mod.BuffType("TaxonDamageBoost"), 240);
				}
			}
			if (taxonSetBonus2 == true)
			{
				if (crit == true)
				{
					player.AddBuff(mod.BuffType("TaxonDefenseBoost"), 240);
				}
			}
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (taxonSetBonus == true)
			{
				if (crit == true)
				{
					player.AddBuff(mod.BuffType("TaxonDamageBoost"), 240);
				}
			}
			if (taxonSetBonus2 == true)
			{
				if (crit == true)
				{
					player.AddBuff(mod.BuffType("TaxonDefenseBoost"), 240);
				}
			}
		}
	}
}