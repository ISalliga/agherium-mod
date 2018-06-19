using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using AgheriumMod.NPCs.Bosses;
using AgheriumMod;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class ForbiddenFrostProj : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(118);
        }
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Empowered Frost Shard");
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 8;
			ProjectileID.Sets.TrailingMode[projectile.type] = 0; 
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		public override void AI()
		{
			for (int lel = 0; lel <= 6; lel++)
			{
				if (Main.rand.NextFloat() < 1f)
				{
					Dust dust;
					// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
					Vector2 position = projectile.Center;
					dust = Main.dust[Terraria.Dust.NewDust(position, 0, 0, 67, 0f, 0f, 0, new Color(0,255,242), 2f)];
					dust.noGravity = true;
					dust.shader = GameShaders.Armor.GetSecondaryShader(88, Main.LocalPlayer);
				}
			}
		}
		public override void Kill(int timeLeft)
		{
			Vector2 value9 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			float spread = 25f * 0.0174f;
			double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - spread / 2;
			double deltaAngle = spread / 8f;
			double offsetAngle;
			int damage = projectile.damage * (int)0.6f;
			int projectileShot = 118;
			int i;
			for (i = 0; i < 4; i++)
			{
				offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
				int proj1 = Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, 32, 0f, Main.myPlayer, 0f, 0f);
				int proj2 = Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, 32, 0f, Main.myPlayer, 0f, 0f);
				Main.projectile[proj1].penetrate = 1;
				Main.projectile[proj2].penetrate = 1;
				
			}
		}
    }
}