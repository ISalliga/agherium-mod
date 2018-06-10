using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace AgheriumMod.Items.Epics
{
	public class BrewOfColors : ModItem
	{
		private Player player;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brew of Colors");
			Tooltip.SetDefault("(Turquoise's Epic) Explodes into Spectrum Flame \nWhen drank, heals you fully but has a 2 minute cooldown \n- This item is an Epic -");
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			foreach (TooltipLine t in tooltips)
			{
				if (t.mod == "Terraria" && t.Name == "Tooltip2")
				{
					t.overrideColor = new Color(155, 97, 174);
				}
			}
		}
		public override void SetDefaults()
		{
			item.consumable = false;
			item.width = 24;
			item.height = 30;
			item.value = 50000;
			item.damage = 20;
			item.useStyle = 1;
			item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 106);
			item.noUseGraphic = true;
			item.rare = 2;
			item.useTime = 25;
			item.shoot = mod.ProjectileType("SpectrumFlask");
			item.shootSpeed = 10;
			item.useAnimation = 25;
			item.autoReuse = true;
			item.maxStack = 1;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 5);
			recipe.AddIngredient(ItemID.StoneBlock, 5);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.hardMode != true)
			{
				item.damage = 35;
			}
			if (NPC.downedBoss3 == true && Main.hardMode != true)
			{
				item.damage = 45;
			}
			if (Main.hardMode == true && NPC.downedMechBoss1 != true && NPC.downedMechBoss2 != true && NPC.downedMechBoss3 != true)
			{
				item.damage = 56;
			}
			if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true && NPC.downedGolemBoss != true)
			{
				item.damage = 67;
			}
			if (NPC.downedGolemBoss == true && NPC.downedMoonlord != true)
			{
				item.damage = 79;
			}
			if (NPC.downedMoonlord == true)
			{
				item.damage = 92;
			}
            return true;
        }
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.shoot = 0;
				if (!player.HasBuff(BuffID.PotionSickness))
				{
				player.statLife = player.statLifeMax2;
				player.AddBuff(BuffID.PotionSickness, 7200);
				}
				else {}
			}
			else
			{
				item.consumable = false;
				item.width = 24;
				item.height = 30;
				item.value = 50000;
				item.damage = 20;
				item.useStyle = 1;
				item.noUseGraphic = true;
				item.rare = 2;
				item.useTime = 25;
				item.shoot = mod.ProjectileType("SpectrumFlask");
				item.shootSpeed = 10;
				item.useAnimation = 25;
				item.autoReuse = true;
				item.maxStack = 1;
				return base.CanUseItem(player);
			}
			return false;
		}
	}
}
