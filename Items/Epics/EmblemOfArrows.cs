using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod;
using AgheriumMod.Items;
using AgheriumMod.Items.AgheriumGear;

namespace AgheriumMod.Items.Epics
{
    public class EmblemOfArrows : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 48;
            item.height = 32;
            item.rare = -12;
			item.useStyle = 1;
			item.useTime = 20;
			item.useAnimation = 20;
			item.consumable = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Emblem of Arrows");
			Tooltip.SetDefault("(Tsuki's Epic) Makes the Agherium Shotbow scale with your world's progression. \n- This item is an Epic -");
        }
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			foreach (TooltipLine t in tooltips)
			{
				if (t.mod == "Terraria" && t.Name == "Tooltip1")
				{
					t.overrideColor = new Color(155, 97, 174);
				}
			}
		}
		public virtual bool UseItem(Player player)
		{
			AgheriumPlayer.ARROWS = true;
			return false;
        }
    }
}