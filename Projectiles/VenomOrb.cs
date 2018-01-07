using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class VenomOrb : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.hostile = true;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.timeLeft = 255;
        }

        public override void AI()
        {
            for (int num457 = 0; num457 < 10; num457++)
			{
				int num458 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 249, 0f, 0f, 100, default(Color), 1.2f);
				Main.dust[num458].noGravity = true;
				Main.dust[num458].velocity *= 0.5f;
				Main.dust[num458].velocity += projectile.velocity * 0.1f;
			}
			return;
        }
    }
}