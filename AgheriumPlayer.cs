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

namespace AgheriumMod
{
	public class AgheriumPlayer : ModPlayer
	{
		public int furyTimer = 20;
		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (Main.LocalPlayer.armor.Any(item => item.type == mod.ItemType("FuriousEmblem")))
			{
				Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("FuryJet"), 35, 0.5f, player.whoAmI, 0.0f, 0.0f);
			}
		}
	}
}