using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items
{
    public class StrangeMachine : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Strange Machine"); 
            Tooltip.SetDefault("'Press the red button to gain immense riches!'" + "\nWell, that's at least what it says on the front. You sometimes can't trust a strange device though..." + "\n(Summons Rorbert, the king of Gelatinians)"); 
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
           NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Rorbert"));
           Main.PlaySound(SoundID.Roar, player.position, 0);
           return true;
        }
    }
}