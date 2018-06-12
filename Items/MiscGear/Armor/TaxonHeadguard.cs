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
	public class TaxonHeadguard : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("8% increased damage and 4% increased critical strike chance \n4% decreased movement speed");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 19;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("TaxonChestguard") && legs.type == mod.ItemType("TaxonGreaves");
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage *= 1.08f;
			player.thrownDamage *= 1.08f;
			player.rangedDamage *= 1.08f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.meleeCrit += 4;
			player.thrownCrit += 4;
			player.magicCrit += 4;
			player.rangedCrit += 4;
			player.moveSpeed *= 0.96f;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Upon critically hitting an enemy, your damage is boosted by 10% for four seconds";
			player.GetModPlayer<AgheriumPlayer>().taxonSetBonus = true;
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