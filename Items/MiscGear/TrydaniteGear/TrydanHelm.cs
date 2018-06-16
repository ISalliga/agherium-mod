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
	[AutoloadEquip(EquipType.Head)]
	public class TrydanHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("4% increased melee damage \n1% increased damage of all other types \n3% increased damage reduction");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 8;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType("TrydanPhaseplate") && legs.type == mod.ItemType("TrydanWarpGreaves");
		}
		
		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.04f;
			player.thrownDamage += 0.01f;
			player.rangedDamage += 0.01f;
			player.magicDamage += 0.01f;
			player.minionDamage += 0.01f;
			player.endurance += 0.3f;
		}
		
		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "All non-melee attacks have a chance to release bursts of Trydan Flame which deal 1 damage but ignore immunity frames\n5% increased damage \nDoubled run speed";
			player.GetModPlayer<AgheriumPlayer>().trydanSetBonus = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 9);
			recipe.AddIngredient(null, "TrydaniteBar", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}