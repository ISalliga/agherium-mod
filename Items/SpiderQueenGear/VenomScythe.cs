using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.SpiderQueenGear
{
    public class VenomScythe : ModItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venom Scythe");
        }
        public override void SetDefaults()
        {
            item.width = 50;  //The width of the .png file in pixels divided by 2.
            item.damage = 112;  //Keep this reasonable please.
            item.melee = true;  //Dictates whether this is a melee-class weapon.
            item.useAnimation = 25;
            item.useTime = 25;  //Ranges from 1 to 55. 
            item.useTurn = true;
            item.useStyle = 1;
            item.knockBack = 4.75f;  //Ranges from 1 to 9.
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;  //Dictates whether the weapon can be "auto-fired".
            item.height = 50;  //The height of the .png file in pixels divided by 2.
            item.maxStack = 1;
            item.value = 500000;  //Value is calculated in copper coins.
            item.rare = 7;  //Ranges from 1 to 11.
            item.shoot = mod.ProjectileType("VenomScytheProj");
            item.shootSpeed = 12f;
        }
		public override void AddRecipes()
		{
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(null, "SmoothSilk", 14);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
		}
	}
}
