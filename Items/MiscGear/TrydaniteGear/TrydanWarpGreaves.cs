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
	[AutoloadEquip(EquipType.Legs)]
	public class TrydanWarpGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("3% increased melee damage \n1% increased damage of all other types");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.03f;
			player.rangedDamage += 0.01f;
			player.magicDamage += 0.01f;
			player.minionDamage += 0.01f;
			player.thrownDamage += 0.01f;
			player.thrownDamage += 0.01f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(null, "TrydaniteBar", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}