using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear
{
    public class FuriousEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 32;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = -12;
            item.accessory = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Furious Emblem");
            Tooltip.SetDefault("7% increased damage \nGetting hit releases a furious flame jet");
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage *= (int)1.07f;
            player.meleeDamage += (int)1.07f;
            player.rangedDamage += (int)1.07f;
            player.minionDamage += (int)1.07f;
        }
		public override void AddRecipes()
		{       
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Soulbinder", 1);
			recipe.AddIngredient(null, "ZemmeliteBar", 5);
			recipe.AddIngredient(null, "AgheriumBar", 5);
			recipe.AddIngredient(null, "EtherumBar", 5);
			recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
    }
}