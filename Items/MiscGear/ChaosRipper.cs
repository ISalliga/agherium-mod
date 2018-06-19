using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace AgheriumMod.Items.MiscGear
{
	public class ChaosRipper : ModItem
	{
		private Player player;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chaos Ripper");
			Tooltip.SetDefault("'Ha, you thought this was a melee weapon? SIKE, SUCKER!' \nExplodes into diabolic flame");
		}
		public override void SetDefaults()
		{
			item.consumable = false;
			item.width = 44;
			item.height = 56;
			item.thrown = true;
			item.value = 50000;
			item.damage = 46;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = 5;
			item.useTime = 20;
			item.shoot = mod.ProjectileType("ChaosRipperProj");
			item.shootSpeed = 12;
			item.useAnimation = 20;
			item.autoReuse = true;
			item.maxStack = 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 7);
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddIngredient(ItemID.Ectoplasm, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 mousePos = Main.MouseWorld;
			if (Main.MouseWorld.X < player.Center.X)
			{
				mousePos.X = -mousePos.X;
			}
			int projectile1 = Projectile.NewProjectile(position.X, position.Y, speedX, speedY - Main.rand.Next(25, 28), type, damage, knockBack, player.whoAmI, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			Main.projectile[projectile1].penetrate = Main.rand.Next(1, 6);
			return false;
        }
	}
}
