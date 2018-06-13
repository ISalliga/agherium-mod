using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class CrystalArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
			projectile.damage = 30;
            projectile.height = 14;
            projectile.friendly = true;
			projectile.aiStyle = 1;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.velocity.Y += 0.53f;
		}
		
		public override void Kill(int timeLeft)
		{
            Vector2 value9 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float spread = 45f * 0.0174f;
            double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - spread / 2;
            double deltaAngle = spread / 8f;
            double offsetAngle;
            int damage = 12;
            int projectileShot = mod.ProjectileType("ArrowShard");
            int i;
            for (i = 0; i < 2; i++)
            {
                offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
            }
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 110);
			for (int num623 = 0; num623 < 70; num623++)
			{
				if (Main.rand.NextFloat() < 1f)
				{
					Dust dust;
					Vector2 position = projectile.Center;
					dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 15, 0f, 0f, 218, new Color(255,0,201), 1.447368f)];
					dust.noGravity = true;
				}
			}
		}
    }
}