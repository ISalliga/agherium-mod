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
    public class ChaosRipperProj : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.scale = 0.8f;
            projectile.width = 44;
            projectile.height = 44;
		    projectile.damage = 4;
            projectile.friendly = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Ripper");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;    //The length of old position to be recorded
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;        //The recording mode
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 75, 0, 0);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		public override void AI()
		{
			projectile.rotation += 0.4f;
			projectile.velocity.Y += 2f;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("Chaosplosion"), 35, 0f, Main.myPlayer, 0f, 0f);
		}
    }
}