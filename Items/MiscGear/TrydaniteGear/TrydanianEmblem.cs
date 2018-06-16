using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using AgheriumMod;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.MiscGear.TrydaniteGear
{
    public class TrydanianEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 42;
			item.rare = 2;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.accessory = true;
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trydanian Emblem");
            Tooltip.SetDefault("Adds up to 4 to all damage");
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AgheriumPlayer>().trydanEmblem = true;
		}
    }
}