using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace AgheriumMod.Projectiles
{
    public class FuryJet : ModProjectile
    {
		int FrameCountMeter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Furious Jet");
		}
        public override void SetDefaults()
        {
            projectile.width = 81;
            projectile.height = 104;
            projectile.friendly = true;
            projectile.timeLeft = 120;
			projectile.penetrate = 50;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
        }
        public override void AI()
        {
			if (Main.rand.NextFloat() < 0.94)
			{
				Dust dust;
				Vector2 position;
				position.X = projectile.Center.X;
				position.Y = projectile.Center.Y + projectile.height / 2;
				dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 182, 0f, -10f, 255, new Color(255,255,255), 1f)];
				dust.noGravity = true;
				dust.fadeIn = 3f;
			}
        }
    }
}