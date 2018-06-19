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
	public class TrueAngelsplosion : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True AngelSPLOSION");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.magic = true;
			projectile.timeLeft = 20;
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
			projectile.position.X -= 5;
			projectile.position.Y -= 5;
			projectile.width += 10;
			projectile.height += 10;
			for (int i = 0; i < projectile.width / 4; i++)
			{
				int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 74, 0f, 0f, 100, new Color(255, 255, 255, 150), 3f);
				Main.dust[num624].noGravity = true;
				Main.dust[num624].velocity *= 2f;
			}
		}
	}
}