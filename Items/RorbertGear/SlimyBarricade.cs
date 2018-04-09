using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod.Items;

namespace AgheriumMod.Items.RorbertGear
{
    public class SlimyBarricade : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 42;
			item.defense = 4;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = -12;
            item.accessory = true;
			item.expert = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Barricade");
            Tooltip.SetDefault("Makes acceleration sattic and increases jump height /n10% increased damage reduction /n'It's like you're wielding a castle made of superballs!'");
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.endurance += 0.1f;
			player.runAcceleration = 1.3f;
			player.runSlowdown = 1f;
			Player.jumpHeight = 23;
		}
    }
}