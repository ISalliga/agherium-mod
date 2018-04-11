using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class PropelledSpider : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 14;
			projectile.damage = 1;
			projectile.aiStyle = 1;
            projectile.height = 38;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 1200;
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
		
		public override void AI()
		{
			projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
		}
		
		public override void Kill(int timeLeft)
		{
			NPC.NewNPC((int)projectile.Center.X, (int)projectile.Center.Y, mod.NPCType("RocketSpider"));
		}
    }
}