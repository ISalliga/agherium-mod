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

namespace AgheriumMod.Projectiles
{
	public class SpectrumFlask : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brew of Colors");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()	
		{
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.timeLeft = 2000;
			projectile.width = 24;
			projectile.height = 30;
			projectile.ignoreWater = true;
			projectile.alpha = 50;
		}
		public override void AI()
		{
			projectile.rotation += 0.4f;
			projectile.velocity.Y += 0.25f;
		}
		public override void Kill(int timeLeft)
        {
            Main.PlaySound(new Terraria.Audio.LegacySoundStyle(2, 107), projectile.Center);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-10, 0), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 56, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-10, 0), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 56, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(0, 11), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 32, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(0, 11), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 32, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-10, 0), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 56, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-10, 0), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 56, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(0, 11), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 32, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(0, 11), Main.rand.Next(-10, 0), mod.ProjectileType("SpectrumFlame"), 32, 0f, Main.myPlayer, 0f, 0f);
        }
	}
}