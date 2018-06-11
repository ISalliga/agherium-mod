using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
    public class GelatinCaller : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gelatin Caller"); 
            Tooltip.SetDefault("Calls forth Orby"); 
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20; 
            item.maxStack = 1; 
            item.value = 0; 
            item.rare = 11; 
            item.useAnimation = 30; 
            item.useTime = 30; 
            item.useStyle = 4; 
            item.consumable = false; 
        }

        public override bool UseItem(Player player)
        {
           NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Orby"));
           Main.PlaySound(SoundID.Roar, player.position, 0);
           return true;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 50);
			recipe.AddIngredient(ItemID.Bone, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}