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

namespace AgheriumMod.Items.MiscGear.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class TaxonMask : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("4% decreased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 27;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("TaxonChestguard") && legs.type == mod.ItemType("TaxonGreaves");
		}
		
		public override void UpdateEquip(Player player)
		{
			player.moveSpeed *= 0.96f;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Upon critically hitting an enemy, your damage reduction is boosted by 8% for four seconds";
			player.GetModPlayer<AgheriumPlayer>().taxonSetBonus2 = true;
			Player.jumpHeight += 10;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(502, 15);
			recipe.AddIngredient(3, 75);
			recipe.AddIngredient(null, "CrystallineIngot", 15);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}