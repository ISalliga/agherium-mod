using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class FightNFlightProj : ModProjectile
    {
		int dustBurstTime = 0;
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 60;
            projectile.ranged = true;
        }

        public override void AI()
        {
            for (int num134 = 0; num134 < 5; num134++)
			{
				float x = projectile.position.X - projectile.velocity.X / 10f * (float)num134;
				float y = projectile.position.Y - projectile.velocity.Y / 10f * (float)num134;
				int num135 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), 1, 1, 15, 0f, 0f, 0, Color.LightBlue, 2f);
				Main.dust[num135].alpha = projectile.alpha;
				Main.dust[num135].position.X = x;
				Main.dust[num135].position.Y = y;
				Main.dust[num135].velocity *= 0f;
				Main.dust[num135].noGravity = true;
			}
			dustBurstTime++;
			
			if (dustBurstTime >= 10)
			{
				int num20 = 36;
				for (int i = 0; i < num20; i++)
				{
					Vector2 spinningpoint = Vector2.Normalize(projectile.velocity) * new Vector2((float)projectile.width / 2f, (float)projectile.height) * 0.75f * 0.5f;
					spinningpoint = spinningpoint.RotatedBy((double)((float)(i - (num20 / 2 - 1)) * 6.28318548f / (float)num20), default(Vector2)) + projectile.Center;
					Vector2 vector = spinningpoint - projectile.Center;
					int num21 = Dust.NewDust(spinningpoint + vector, 0, 0, 15, vector.X * 2f, vector.Y * 2f, 0, Color.LightBlue, 1.6f);
					Main.dust[num21].noGravity = true;
					Main.dust[num21].noLight = true;
					Main.dust[num21].velocity = Vector2.Normalize(vector) * 3f;
				}
				dustBurstTime = 0;
			}
        }
    }
}