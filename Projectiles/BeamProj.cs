using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using AgheriumMod.NPCs.Bosses;
using AgheriumMod;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class BeamProj : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.scale = 1.5f;
            projectile.width = 14;
            projectile.height = 14;
			projectile.alpha = 255;
			projectile.damage = 17;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trydan Flame");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0; 
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(155, 155, 255, projectile.alpha);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
			projectile.alpha -= 16;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			for (int dusterino = 0; dusterino <= 10; dusterino++)
			{
				Dust dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 1, 1, 226, Main.rand.Next(-6, 7), Main.rand.Next(-6, 7), 0, new Color(255,255,255), 0.5f)];
				dust.noGravity = true;
			}
			for (int projerino = 0; projerino <= 5; projerino++)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-8, 8), Main.rand.Next(-7, 8), mod.ProjectileType("MiniBeamProj"), 4, 0, Main.myPlayer, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			}
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 15, 0, mod.ProjectileType("MiniBeamProj"), 6, 0, Main.myPlayer, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, -15, 0, mod.ProjectileType("MiniBeamProj"), 6, 0, Main.myPlayer, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 15, mod.ProjectileType("MiniBeamProj"), 6, 0, Main.myPlayer, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -15, mod.ProjectileType("MiniBeamProj"), 6, 0, Main.myPlayer, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
		}
    }
}