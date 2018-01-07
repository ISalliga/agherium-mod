using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod.Items;

namespace AgheriumMod.Items.SpiderQueenGear
{
    public class SpiderRocketLauncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spider Rocket Launcher");
            Tooltip.SetDefault("Fires rocket-fueled spiders!");
        }

        public override void SetDefaults()
        {
            item.damage = 107;
            item.ranged = true;
            item.width = 58;
            item.height = 26;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 6.5f;
            item.value = 250000;
            item.rare = 7;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 18f;
            item.shoot = mod.ProjectileType("RocketSpiderProj");
            item.useAmmo = 771;
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float SpeedX = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
            float SpeedY = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, mod.ProjectileType("RocketSpiderProj"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SmoothSilk", 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}