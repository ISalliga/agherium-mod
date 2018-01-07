using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class EnergyStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 361;
            projectile.alpha = 60;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, projectile.alpha);
        }
        public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] >= 35)
            {
                projectile.Kill();
                {
                    int numProj = 12;
                    float rotation = MathHelper.ToRadians(20);
                    for (int i = 0; i < numProj + 1; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numProj - 1)));
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("MiniArchorbNonsplit"), 40, projectile.knockBack, projectile.owner, 0f, 0f);
                    }
                }
            }
        }
    }
}