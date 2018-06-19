using System;
using Terraria.Graphics.Shaders;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod.Items;

namespace AgheriumMod.Items.MiscGear
{
	public class AngelsSorrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Angel's Sorrow");
			Tooltip.SetDefault("'They say rainforests get the most rain because the saddest angels live above them. \nHowever I think that's silly. Everyone knows it's just because of high amounts of humidity.' \nGenerates anywhere from one to four beams that explode and linger for a small amount of time");
		}
		public override void SetDefaults()
		{
			item.damage = 85;
			item.melee = true;
			item.width = 72;
			item.height = 80;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.shoot = mod.ProjectileType("AngelsSorrowProj");
			item.shootSpeed = 15f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.maxStack = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 20);
			recipe.AddIngredient(ItemID.Seedler);
			recipe.AddIngredient(ItemID.TerraBlade);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int num6 = Main.rand.Next(1, 5);
            for (int index = 0; index < num6; ++index)
            {
                float SpeedX = speedX + (float)Main.rand.Next(-30, 31) * 0.05f;
                float SpeedY = speedY + (float)Main.rand.Next(-30, 31) * 0.05f;
                Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            }
            return false;
        }
	}
}
