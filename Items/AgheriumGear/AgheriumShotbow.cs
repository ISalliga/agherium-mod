using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.AgheriumGear
{
    public class AgheriumShotbow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 16;
            item.ranged = true;
            item.width = 26;
            item.height = 40;
            item.crit = 10; 
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4.25f;
            item.value = 9000;
            item.rare = 3;
			item.useAmmo = 40;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 15f;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Agherium Shotbow");
			Tooltip.SetDefault("Shoots six arrows at once! \nTsuki's weapon of choice. Might as well make this his dev item, even though he's not a developer.");
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num6 = Main.rand.Next(2, 5);
            for (int index = 0; index < num6; ++index)
            {
                float SpeedX = speedX + (float)Main.rand.Next(-10, 11) * 0.045f;
                float SpeedY = speedY + (float)Main.rand.Next(-10, 11) * 0.045f;
                int projectile1 = Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AgheriumBar", 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}