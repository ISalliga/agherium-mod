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
	public class ERWProj : ModProjectile
	{
		int timeAlive = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eratically Resplendent Wing");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()	
		{
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.timeLeft = 2000;
			projectile.width = 14;
			projectile.height = 14;
			projectile.aiStyle = 1;
			projectile.ignoreWater = true;
			projectile.alpha = 50;
			projectile.penetrate = 1;
		}
		public override void AI()
		{
			timeAlive++;
			if (timeAlive >= 12)
			{
				projectile.velocity.Y += (float)Main.rand.Next(-9, 10);
				projectile.velocity.X += (float)Main.rand.Next(-9, 10);
				timeAlive = 9;
			}
		}
	}
}