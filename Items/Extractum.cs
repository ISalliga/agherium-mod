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

namespace AgheriumMod.Items
{
	public class Extractum : ModItem
	{
		private Player player;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Extractum");
			Tooltip.SetDefault("This fine material is an alloy of dirt, stone and wood. \nIt can contain small samples of Agherium, Etherum, or Zemmelite.");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 16;
			item.value = 0;
			item.useStyle = 1;
			item.rare = 2;
			item.useTime = 5;
			item.useAnimation = 5;
			item.autoReuse = true;
			item.createTile = mod.TileType("ExtractumTile");
			item.maxStack = 999;
		}
		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			int type = Main.rand.Next(4);
			if (type == 1)
			{
				resultType = mod.ItemType("ZemmeliteShard");
			}
			if (type == 2)
			{
				resultType = mod.ItemType("AgheriumChunk");
			}
			if (type == 3)
			{
				resultType = mod.ItemType("EtherumOre");
			}
			resultStack = Main.rand.Next(7);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 5);
			recipe.AddIngredient(ItemID.StoneBlock, 5);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
