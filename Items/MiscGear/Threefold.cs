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
    public class Threefold : ModItem
    {
		int shots = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Threefold");
        }
        public override void SetDefaults()
        {
            item.damage = 54;
            item.magic = true;
            item.width = 46;
            item.height = 20;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4.5f;
            item.value = 50000;
            item.rare = 7;
            item.UseSound = SoundID.Item95;
            item.autoReuse = true;
            item.shootSpeed = 18f;
            item.shoot = 14;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 20);
			recipe.AddIngredient(ItemID.Xenopopper);
			recipe.AddIngredient(2860, 30);
			recipe.AddIngredient(3457, 20);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX + Main.rand.Next(-3, 4), speedY + Main.rand.Next(-3, 4), mod.ProjectileType("ThreefoldProj"), 45, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX * 2f + Main.rand.Next(-3, 4), speedY * 2f + Main.rand.Next(-3, 4), mod.ProjectileType("ThreefoldProj"), 45, 0f, Main.myPlayer, 0f, 0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, speedX * 3f + Main.rand.Next(-3, 4), speedY * 3f + Main.rand.Next(-3, 4), mod.ProjectileType("ThreefoldProj"), 45, 0f, Main.myPlayer, 0f, 0f);
			return false;
        }
    }
}