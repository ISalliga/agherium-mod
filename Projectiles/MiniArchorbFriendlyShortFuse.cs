using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class MiniArchorbFriendlyShortFuse : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mini Archorb");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
			projectile.friendly = true;
            projectile.height = 20; 
            projectile.penetrate = 1;
            projectile.timeLeft = 100;
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.ai[1]++;
        }
        public override void Kill(int timeLeft)
        {
            Vector2 value9 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
            float spread = 45f * 0.0174f;
            double startAngle = Math.Atan2(projectile.velocity.X, projectile.velocity.Y) - spread / 2;
            double deltaAngle = spread / 8f;
            double offsetAngle;
            int damage = 30;
            int projectileShot = 88;
            int i;
            for (i = 0; i < 3; i++)
            {
                offsetAngle = (startAngle + deltaAngle * (i + i * i) / 2f) + 32f * i;
                Projectile.NewProjectile(value9.X, value9.Y, (float)(Math.Sin(offsetAngle) * 5f), (float)(Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(value9.X, value9.Y, (float)(-Math.Sin(offsetAngle) * 5f), (float)(-Math.Cos(offsetAngle) * 5f), projectileShot, damage, 0f, Main.myPlayer, 0f, 0f);
            }
        }
    }
}