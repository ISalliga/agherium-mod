using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class MegaArchorb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mega Archorb");
        }
        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 80; 
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 420;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.ai[1]++;
			if(projectile.ai[1] < 200)
            {
				int homingCooldown = 0;
				int homingDelay = 10;
				float homingSpeed = 4;
				float lerpTime = 60; // minimum of 1, please keep in full numbers even though it's a float!

				projectile.ai[homingCooldown]++;
				if(projectile.ai[homingCooldown] > homingDelay)
				{
					projectile.ai[homingCooldown] = homingDelay; //cap this value 

					int foundTarget = HomeOnTarget();
					if(foundTarget != -1)
					{
						Player p = Main.player[foundTarget];
						Vector2 desiredVelocity = projectile.DirectionTo(p.Center) * homingSpeed;
						projectile.velocity = Vector2.Lerp(projectile.velocity, desiredVelocity, 1f / lerpTime);
					}
				}
			}
        }
		int HomeOnTarget()
		{
			float maxDistance = 5000;
			int selectedTarget = -1;
			int selectedPlayer = (int)Player.FindClosest(projectile.Center, 0, 0);
			float distance = projectile.Distance(Main.player[selectedPlayer].Center);
			if(distance <= maxDistance && projectile.ai[1] < 200)
			{
				selectedTarget = selectedPlayer;
			}
			return selectedTarget;
		}
        
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 value9 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float spread = 45f * 0.0174f;
            double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - spread / 2;
            double deltaAngle = spread / 8f;
            double offsetAngle;
            int damage = 25;
            int projectileShot = 100;
            int i;
            for (i = 0; i < 5; i++)
            {
                offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
            }
        }
    }
}