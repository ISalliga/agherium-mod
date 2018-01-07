using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AgheriumMod.Projectiles
{
	public class Blorb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blorb");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.melee = true;
			projectile.timeLeft = 10000;
			projectile.aiStyle = 8;
			projectile.width = 18;
			projectile.height = 18;
			projectile.ignoreWater = true;
			projectile.knockBack = 0.5f;
			projectile.penetrate = -1;
		}
	}
}