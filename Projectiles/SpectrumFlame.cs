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
	public class SpectrumFlame : ModProjectile
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
			projectile.melee = true;
			projectile.timeLeft = 2000;
			projectile.aiStyle = 23;
			projectile.width = 14;
			projectile.height = 28;
			projectile.ignoreWater = true;
			projectile.alpha = 50;
		}
		public override void AI()
		{
			if (Main.hardMode != true)
			{
				projectile.damage = 20;
			}
			if (NPC.downedBoss3 == true && Main.hardMode != true)
			{
				projectile.damage = 31;
			}
			if (Main.hardMode == true && NPC.downedMechBoss1 != true && NPC.downedMechBoss2 != true && NPC.downedMechBoss3 != true)
			{
				projectile.damage = 42;
			}
			if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true && NPC.downedGolemBoss != true)
			{
				projectile.damage = 58;
			}
			if (NPC.downedGolemBoss == true && NPC.downedMoonlord != true)
			{
				projectile.damage = 69;
			}
			if (NPC.downedMoonlord == true)
			{
				projectile.damage = 91;
			}
			projectile.velocity.Y += 0.35f;
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				Vector2 position = projectile.Center;
				dust = Terraria.Dust.NewDustPerfect(position, 6, new Vector2(0f, -3.157895f), 0, new Color(255,255,255), 3.684211f);
				dust.noGravity = true;
				dust.shader = GameShaders.Armor.GetSecondaryShader(77, Main.LocalPlayer);
			}
		}
		public override void Kill(int timeLeft)
        {
			for (int num623 = 0; num623 < 35; num623++)
			if (Main.rand.NextFloat() < 1f)
			{
				Dust dust;
				Vector2 position;
				position.X = projectile.Center.X - projectile.width / 2;
				position.Y = projectile.Center.Y - projectile.height / 2;
				dust = Main.dust[Terraria.Dust.NewDust(position, 78, 78, 6, 0f, 0f, 0, new Color(255,255,255), 3.486842f)];
				dust.noGravity = true;
				dust.shader = GameShaders.Armor.GetSecondaryShader(77, Main.LocalPlayer);
			}

		}
	}
}