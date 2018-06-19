using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear
{
	public class ForbiddenFrost : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forbidden Frost");
			Tooltip.SetDefault("Fires empowered ice shards");
		}
		public override void SetDefaults()
		{
			item.damage = 69;
			item.melee = true;
			item.width = 72;
			item.height = 80;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.shoot = mod.ProjectileType("ForbiddenFrostProj");
			item.shootSpeed = 15f;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 30);
			recipe.AddIngredient(ItemID.IceBlade, 1);
			recipe.AddIngredient(ItemID.CobaltBar, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Ectoplasm, 30);
			recipe2.AddIngredient(ItemID.IceBlade, 1);
			recipe2.AddIngredient(ItemID.PalladiumBar, 18);
			recipe2.AddTile(TileID.MythrilAnvil);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}
