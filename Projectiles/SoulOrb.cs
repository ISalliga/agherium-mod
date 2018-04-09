using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class SoulOrb : ModProjectile
    {
        int bounce = 0;
		int justBounced = 0;
    	public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Orb");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
        public override void SetDefaults()
        {
			projectile.damage = 1;
            projectile.width = 20;
            projectile.height = 20;
            projectile.hostile = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 300;
        }
		
		public override void AI()
		{
			if (justBounced >= 0)
			{
				justBounced--;
			}
			
			if (justBounced > 0)
			{
				projectile.velocity.Y++;
			}
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -5f, 0f, mod.ProjectileType("SoulBeam"), 20, 0f, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 5f, 0f, mod.ProjectileType("SoulBeam"), 20, 0f, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 5f, mod.ProjectileType("SoulBeam"), 20, 0f, Main.myPlayer);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, -5f, mod.ProjectileType("SoulBeam"), 20, 0f, Main.myPlayer);
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
			justBounced = 240;
            return false;
        }
    }
}