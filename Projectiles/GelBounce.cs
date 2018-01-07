using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class GelBounce : ModProjectile
    {
        int bounce = 0;
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bouncy Gel");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.hostile = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 300;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (bounce < 0)
            {
                bounce = 0;
            }
            bounce--;
            if (bounce == 1)
            {
                projectile.ai[0] += 0.1f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {
                bounce += 31;
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.1f;
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }
    }
}