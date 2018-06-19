using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;

namespace AgheriumMod.Projectiles
{
	public class ThreefoldProj : ModProjectile
	{
		int timeAlive = 0;
		int bounce = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Threefold Bubble");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()	
		{
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.timeLeft = 120;
			projectile.width = 30;
			projectile.height = 30;
			projectile.ignoreWater = true;
			projectile.penetrate = 999;
			projectile.alpha = 75;
		}
		public override void AI()
		{
			{
				projectile.velocity.Y = projectile.velocity.Y / 1.3f;
				projectile.velocity.X = projectile.velocity.X / 1.3f;
			}
			timeAlive++;
			if (timeAlive > 60)
			{
				projectile.Kill();
			}
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255,0,100,150);
        }
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 96);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-20, 21), Main.rand.Next(-20, 21), 14, 58, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-20, 21), Main.rand.Next(-20, 21), 14, 58, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-20, 21), Main.rand.Next(-20, 21), 14, 58, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-20, 21), Main.rand.Next(-20, 21), 14, 58, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-20, 21), Main.rand.Next(-20, 21), 14, 58, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-20, 21), Main.rand.Next(-20, 21), 14, 58, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-20, 21), Main.rand.Next(-20, 21), 14, 58, 0f, Main.myPlayer, 0.0f, 0.0f);
			for (int i = 0; i <= 20; i++)
			{
				Dust dust;
				Vector2 position = projectile.Center;
				dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 174, 0f, 0f, 77, new Color(255,0,100), 1f)];
				dust.noGravity = true;
				dust.shader = GameShaders.Armor.GetSecondaryShader(35, Main.LocalPlayer);
			}
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