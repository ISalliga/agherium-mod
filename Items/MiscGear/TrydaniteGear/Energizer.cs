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

namespace AgheriumMod.Items.MiscGear.TrydaniteGear
{
	public class Energizer : ModItem
	{
		private Player player;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energizer");
			Tooltip.SetDefault("Each dagger has a chance to explode into a cloud of sparks");
		}
		public override void SetDefaults()
		{
			item.consumable = true;
			item.width = 42;
			item.height = 54;
			item.thrown = true;
			item.value = 50000;
			item.damage = 30;
			item.useStyle = 1;
			item.UseSound = SoundID.Item1;
			item.noUseGraphic = true;
			item.rare = 5;
			item.useTime = 20;
			item.shoot = mod.ProjectileType("EnergizerProj");
			item.shootSpeed = 12;
			item.useAnimation = 20;
			item.autoReuse = true;
			item.maxStack = 9999;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 1);
			recipe.AddIngredient(null, "TrydaniteBar", 4);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}
