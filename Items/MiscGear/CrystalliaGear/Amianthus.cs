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

namespace AgheriumMod.Items.MiscGear.CrystalliaGear
{
	public class Amianthus : ModItem
	{
		private Player player;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amianthus");
			Tooltip.SetDefault("Breaks crystal shards and some ores");
		}
		public override void SetDefaults()
		{
			item.consumable = false;
			item.width = 42;
			item.height = 54;
			item.thrown = true;
			item.value = 50000;
			item.damage = 50;
			item.useStyle = 1;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 71);
			item.noUseGraphic = true;
			item.rare = 5;
			item.useTime = 20;
			item.shoot = mod.ProjectileType("AmianthusProj");
			item.shootSpeed = 12;
			item.useAnimation = 20;
			item.autoReuse = true;
			item.maxStack = 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 75);
			recipe.AddIngredient(null, "CrystallineIngot", 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}