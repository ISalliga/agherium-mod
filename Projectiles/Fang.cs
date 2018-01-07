using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class Fang : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Poison Fang");
        }
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 10;
            Main.projFrames[projectile.type] = 1;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.extraUpdates = 1;
        }
        public override void AI()
        {
            projectile.rotation += 0.145f;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Slow, 240);
            target.AddBuff(BuffID.Poisoned, 240);
        }
    }
}