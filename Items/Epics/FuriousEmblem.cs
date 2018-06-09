using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod;
using AgheriumMod.Items;
using AgheriumMod.Items.Epics;

namespace AgheriumMod.Items.Epics
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
            Tooltip.SetDefault("7% increased damage \nGetting hit releases a furious flame jet \n'Fury is being forged' \nThis item is an Epic");
        }
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			foreach (TooltipLine t in tooltips)
			{
				if (t.mod == "Terraria" && t.Name == "Tooltip3")
				{
					t.overrideColor = new Color(155, 97, 174);
				}
			}
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage *= (int)1.07f;
            player.meleeDamage *= (int)1.07f;
            player.rangedDamage *= (int)1.07f;
            player.minionDamage *= (int)1.07f;
			AgheriumPlayer.isFuryBeingForged = true;
        }
    }
}