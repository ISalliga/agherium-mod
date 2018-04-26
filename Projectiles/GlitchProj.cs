using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AgheriumMod.Projectiles
{
	public class GlitchProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("null");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.hostile = true;
			projectile.magic = true;
			projectile.timeLeft = 70;
			projectile.aiStyle = 0;
			projectile.width = 22;
			projectile.height = 22;
			projectile.ignoreWater = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.knockBack = 0;
		}
		public virtual void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.endurance = target.endurance + Main.rand.Next((int)-0.5f, (int)0.1f);
		}
	}
}