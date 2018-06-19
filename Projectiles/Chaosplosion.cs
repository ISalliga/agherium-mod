using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
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
	public class Chaosplosion : ModProjectile
	{
		int FrameCountMeter = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("ChaoSPLOSION");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			Main.projFrames[projectile.type] = 7;
		}
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 75, 0, 0);
        }
		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.magic = true;
			projectile.timeLeft = 21;
			projectile.aiStyle = -1;
			projectile.width = 98;
			projectile.height = 98;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.knockBack = 0;
		}
		public override void AI()
		{
			FrameCountMeter++;
			if (FrameCountMeter >= 3)
			{
				projectile.frame++;
				FrameCountMeter = 0;
			}
		}
	}
}
