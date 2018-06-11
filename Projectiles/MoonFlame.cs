using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
	public class MoonFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spectrum Flame");     
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.timeLeft = 20;
			projectile.aiStyle = 1;
			projectile.width = 20;
			projectile.height = 20;
			projectile.ignoreWater = true;
			projectile.alpha = 50;
		}
		public override void AI()
		{
			if (Main.hardMode != true)
			{
				projectile.damage = 24;
			}
			if (NPC.downedBoss3 == true && Main.hardMode != true)
			{
				projectile.damage = 37;
			}
			if (Main.hardMode == true && NPC.downedMechBoss1 != true && NPC.downedMechBoss2 != true && NPC.downedMechBoss3 != true)
			{
				projectile.damage = 52;
			}
			if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true && NPC.downedGolemBoss != true)
			{
				projectile.damage = 69;
			}
			if (NPC.downedGolemBoss == true && NPC.downedMoonlord != true)
			{
				projectile.damage = 97;
			}
			if (NPC.downedMoonlord == true)
			{
				projectile.damage = 117;
			}
			if (projectile.velocity.Y < 0)
			{
				projectile.velocity.Y -= 0.45f;	
			}
			else
			{
				projectile.velocity.Y += 0.45f;	
			}
			
			for (int index = 0; index < 7; ++index)
			{
				if (Main.rand.NextFloat() < 1f)
				{
					Dust dust;
					Vector2 position = projectile.Center;
					dust = Main.dust[Terraria.Dust.NewDust(position, 31, 30, 16, 0f, 0f, 80, new Color(255,0,25), 3.421053f)];
					dust.noGravity = true;
				}
			}
		}
		public virtual void OnHitNPC(NPC target, int damage, bool crit)
		{
			target.AddBuff(mod.BuffType("Moonburnt"), 480);
		}
	}
}