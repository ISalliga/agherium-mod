using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear
{
	public class TheAtomizer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Atomizer");
			Tooltip.SetDefault("Fires a large spread of atomic lasers");
		}
		public override void SetDefaults()
		{
			item.damage = 39;
			item.noMelee = true;
			item.ranged = true;
			item.width = 58;
			item.height = 22;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("Atomizer");
			item.shootSpeed = 20;
			item.useStyle = 5;
			item.knockBack = 2;
			item.rare = 4;
			item.autoReuse = false;
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num6 = 4;
            for (int index = 0; index < num6; ++index)
            {
                float SpeedX = speedX + (float)Main.rand.Next(-50, 51) * 0.045f;
                float SpeedY = speedY + (float)Main.rand.Next(-50, 51) * 0.045f;
                int projectile1 = Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
            }
            return false;
        }
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofMight, 15);
			recipe.AddIngredient(ItemID.HallowedBar, 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

