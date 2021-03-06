using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace AgheriumMod.Items.SoulOfTheGuideGear
{
    public class Soulbinder : ModItem
    {
		float damageBonus = 0.01f;
		int damageBonusTime = 0;
        public override void SetDefaults()
        {

            item.width = 28;
            item.alpha = 0;
            item.height = 26;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 30, 0, 0);
            item.rare = 5;
            item.expert = true;
            item.accessory = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soulbinder");
            Tooltip.SetDefault("1% extra damage to start off \nAs you use the accessory the value gets higher, resetting at 1% after 25%");
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			damageBonusTime++;
			if (damageBonusTime > 59)
			{
				damageBonus += 0.01f;
				damageBonusTime = 0;
			}
			if (damageBonus >= 0.26f)
			{
				damageBonus = 0.01f;
			}
            player.magicDamage += damageBonus;
            player.meleeDamage += damageBonus;
            player.rangedDamage += damageBonus;
            player.minionDamage += damageBonus;
        }
    }
}