using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AgheriumMod;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
	public class PulsyThing : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pulsy Thing");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.magic = true;
			projectile.timeLeft = 45;
			projectile.aiStyle = -1;
			projectile.width = 50;
			projectile.height = 50;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.knockBack = 0;
		}
		public override void AI()
		{
			projectile.position.X -= 10;
			projectile.position.Y -= 10;
			projectile.width += 20;
			projectile.height += 20;
			for (int i = 0; i < projectile.width / 3; i++)
			{
				int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 20, 0f, 0f, 100, Color.Red, 3f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 2f;
			}
		}
	}
}