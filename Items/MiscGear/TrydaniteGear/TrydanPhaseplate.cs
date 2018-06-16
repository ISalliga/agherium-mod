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
	[AutoloadEquip(EquipType.Body)]
	public class TrydanPhaseplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Trydan Phaseplate");
			Tooltip.SetDefault("4% increased melee damage \n2% increased damage of all other types \n2% increased damage reduction");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 10;
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.04f;
			player.rangedDamage += 0.02f;
			player.magicDamage += 0.02f;
			player.minionDamage += 0.02f;
			player.thrownDamage += 0.02f;
			player.thrownDamage += 0.02f;
			player.endurance += 0.2f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 11);
			recipe.AddIngredient(null, "TrydaniteBar", 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}