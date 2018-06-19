using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear
{
	public class INFERNO : ModItem
	{
		int shootThing = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("INFERNO");
			Tooltip.SetDefault("Welcome to doom metal, kid. \nCreates a circle of heavy-metal boomerangs that deal hellfire damage and explode upon hitting enemies every swing");
		}
		public override void SetDefaults()
		{
			item.damage = 230;
			item.melee = true;
			item.width = 60;
			item.height = 60;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.axe = 38;
			item.knockBack = 6;
			item.value = 200000;
			item.rare = 7;
			item.shoot = mod.ProjectileType("INFERNOProj");
			item.shootSpeed = 15f;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/INFERNO").WithVolume(.7f).WithPitchVariance(.15f);
			item.autoReuse = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 20);
			recipe.AddIngredient(ItemID.TheAxe, 1);
			recipe.AddIngredient(3522, 1);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Projectile.NewProjectile(player.Center.X, player.Center.Y, -16, 0, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, 16, 0, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, -16, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 16, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, 10, 10, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, -10, -10, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, -10, 10, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			Projectile.NewProjectile(player.Center.X, player.Center.Y, 10, -10, type, 230, 0f, Main.myPlayer, 0.0f, 0.0f);
			return false;
		}
	}
}
