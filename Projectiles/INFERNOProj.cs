using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace AgheriumMod.Projectiles
{
    public class INFERNOProj : ModProjectile
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Infernal Boomerang");
		}
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 34;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.melee = true;
			projectile.tileCollide = false;
			projectile.timeLeft = 660;
            projectile.penetrate = 99999;
            projectile.light = 0.5f;
        }
		public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 175, 0, 50);
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 612, 230, 0f, Main.myPlayer, 0f, 0f);
			target.AddBuff(24, 300);
		}
    }
}