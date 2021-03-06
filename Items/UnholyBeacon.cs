using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items 
{
    public class UnholyBeacon : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholy Beacon"); 
            Tooltip.SetDefault("Summons the Fallen Angel"); 
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 42; 
            item.maxStack = 20; 
            item.value = 0; 
            item.rare = 11; 
            item.useAnimation = 30; 
            item.useTime = 30; 
            item.useStyle = 4; 
            item.consumable = true; 
        }

        public override bool UseItem(Player player)
        {
           NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("FallenAngel"));
           Main.PlaySound(SoundID.Roar, player.position, 0);
           return true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofNight, 3);
			recipe.AddIngredient(ItemID.SoulofLight, 3);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddIngredient(ItemID.Feather, 5);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.SoulofNight, 3);
			recipe1.AddIngredient(ItemID.SoulofLight, 3);
			recipe1.AddIngredient(ItemID.LeadBar, 5);
			recipe1.AddIngredient(ItemID.Feather, 5);
			recipe1.AddTile(TileID.MythrilAnvil);
			recipe1.SetResult(this, 1);
			recipe1.AddRecipe();
		}
    }
}