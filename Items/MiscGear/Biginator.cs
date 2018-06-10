using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod.Items;

namespace AgheriumMod.Items.MiscGear
{
    public class Biginator : ModItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bigifier");
            Tooltip.SetDefault("Makes enemies larger and deals good amounts of damage");
        }
        public override void SetDefaults()
        {
            item.damage = 75;
            item.ranged = true;
            item.width = 60;
            item.height = 40;
            item.useTime = 34;
            item.useAnimation = 34;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 115);
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 7f;
            item.value = 0;
            item.rare = 10;
            item.autoReuse = true;
            item.shootSpeed = 25f;
            item.shoot = mod.ProjectileType("BigThing");
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BigThing"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }
    }
}