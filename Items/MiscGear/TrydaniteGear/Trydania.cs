using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear.TrydaniteGear
{
	public class Trydania : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Trydania");
			Tooltip.SetDefault("Fires 1 to 3 bursts of Trydan Flame that arc towards the mouse cursor");
		}
		public override void SetDefaults()
		{
			item.damage = 48;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 33;
			item.useAnimation = 33;
			item.shoot = mod.ProjectileType("TrydanFlame");
			item.shootSpeed = 14;
			item.useStyle = 1;
			item.knockBack = 2;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = false;
        }	
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(null, "TrydaniteBar", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int index = 0; index < Main.rand.Next(1, 4); ++index)
            {
				Vector2 mousePos = Main.MouseWorld;
				if (Main.MouseWorld.X < player.Center.X)
				{
					mousePos.X = -mousePos.X;
				}
                int projectile1 = Projectile.NewProjectile(position.X, position.Y, (speedX * 2) + Main.rand.Next(-2, 3), speedY * 2f - Main.rand.Next(25, 28), type, damage - Main.rand.Next(3), knockBack, player.whoAmI, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
				Main.projectile[projectile1].penetrate = Main.rand.Next(1, 6);
            }
			return false;
        }
	}
}

