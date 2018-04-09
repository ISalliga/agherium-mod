using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class SoulBeam : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lesser Soul Orb");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}
        public override void SetDefaults()
        {
            projectile.width = 10;
			projectile.damage = 1;
            projectile.height = 10;
            projectile.hostile = true;
			projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
        }
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
    }
}