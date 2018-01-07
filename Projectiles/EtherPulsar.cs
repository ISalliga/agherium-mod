using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AgheriumMod.Projectiles
{
	public class EtherPulsar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stabby Thing");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.magic = true;
			projectile.timeLeft = 70;
			projectile.aiStyle = -1;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.knockBack = 0;
		}
		public override void AI()
		{
			projectile.rotation += 0.47f;
		}
	}
}