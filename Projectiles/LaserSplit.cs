using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles 
{
    public class LaserSplit : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Laser");
        }
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 66;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 36;
            projectile.alpha = 60;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, projectile.alpha);
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] >= 35)
            {
                {
                    int numProj = 3;
                    float rotation = MathHelper.ToRadians(20);
                    for (int i = 0; i < numProj + 1; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, 440, (int)((double)projectile.damage), projectile.knockBack, projectile.owner, 0f, 0f);
                    }
                    projectile.Kill();
                }
            }
        }
    }
}