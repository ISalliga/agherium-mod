using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Projectiles
{
    public class VenomScytheProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venom Scythe");
        }
        public override void SetDefaults()
        {
            projectile.width = 52;
            projectile.height = 44;
            projectile.aiStyle = 18;
            Main.projFrames[projectile.type] = 1;
            projectile.friendly = true;
			projectile.timeLeft = 750;
            projectile.ignoreWater = true;
            projectile.penetrate = 1;
            projectile.extraUpdates = 1;
            projectile.melee = true;
            aiType = 263;
            projectile.tileCollide = true;
        }
        public override Color? GetAlpha(Color drawColor)
        {
            return Color.Green;
        }
    }
}