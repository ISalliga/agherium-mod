using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear
{
	public class TrueAngelsSorrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Angel's Sorrow");
			Tooltip.SetDefault("Generates anywhere from 1 to 5 beams that explode as well as one extremely powerful beam at a 50% chance");
		}
		public override void SetDefaults()
		{
			item.damage = 155;
			item.melee = true;
			item.width = 72;
			item.height = 80;
			item.useTime = 14;
			item.useAnimation = 14;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.shoot = mod.ProjectileType("AngelsSorrowProj");
			item.shootSpeed = 15f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AngelsSorrow");
			recipe.AddIngredient(3473, 1);
			recipe.AddIngredient(3458, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num6 = Main.rand.Next(1, 6);
            for (int index = 0; index < num6; ++index)
            {
                float SpeedX = speedX + (float)Main.rand.Next(-30, 31) * 0.05f;
                float SpeedY = speedY + (float)Main.rand.Next(-30, 31) * 0.05f;
                int beam = Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
				Main.projectile[beam].damage = item.damage;
            }
			if (Main.rand.Next(1, 3) == 2)
			{
				Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, mod.ProjectileType("TrueAngelsSorrowProj"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
			}
            return false;
        }
	}
}
