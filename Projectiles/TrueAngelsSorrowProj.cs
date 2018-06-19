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
    public class TrueAngelsSorrowProj : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.scale = 1f;
            projectile.width = 50;
            projectile.height = 50;
		    projectile.damage = 4;
			projectile.melee = true;
            projectile.friendly = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Angel's Sorrow");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 50);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		public override void AI()
		{
			projectile.rotation += 0.4f;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 89);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3), mod.ProjectileType("TrueAngelsplosion"), 45, 0f, Main.myPlayer, 0f, 0f);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 100);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 89);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-2, 3), Main.rand.Next(-2, 3), mod.ProjectileType("TrueAngelsplosion"), 45, 0f, Main.myPlayer, 0f, 0f);
		}
    }
}