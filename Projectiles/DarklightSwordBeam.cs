using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AgheriumMod.Projectiles
{
	public class DarklightSwordBeam : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darklight Afterimage");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.melee = true;
			projectile.timeLeft = 2000;
			projectile.aiStyle = -1;
			projectile.width = 44;
			projectile.height = 44;
			projectile.ignoreWater = true;
			projectile.maxPenetrate = 2;
		}
		public override void AI()
		{
			projectile.rotation += 0.25f;
			projectile.alpha = 50;
		}
	}
}