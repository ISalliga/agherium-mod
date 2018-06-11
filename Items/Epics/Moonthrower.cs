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
	public class Moonthrower : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonthrower");
			Tooltip.SetDefault("(Moonburn's Epic) Fires bursts of moon flame! \n- This item is an Epic -");
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
		public override void SetDefaults()
		{
			item.damage = 23;
			item.noMelee = true;
			item.ranged = true;
			item.width = 54;
			item.height = 16;
			item.useTime = 30;
			item.useAnimation = 30;
			item.shoot = mod.ProjectileType("MoonFlame");
			item.autoReuse = true;
			item.knockBack = 2;
			item.shootSpeed = 13;
			item.useStyle = 5;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
		}
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (AgheriumPlayer.ARROWS = true)
			{
				if (Main.hardMode != true)
				{
					item.damage = 24;
				}
				if (NPC.downedBoss3 == true && Main.hardMode != true)
				{
					item.damage = 37;
				}
				if (Main.hardMode == true && NPC.downedMechBoss1 != true && NPC.downedMechBoss2 != true && NPC.downedMechBoss3 != true)
				{
					item.damage = 52;
				}
				if (NPC.downedMechBoss1 == true && NPC.downedMechBoss2 == true && NPC.downedMechBoss3 == true && NPC.downedGolemBoss != true)
				{
					item.damage = 69;
				}
				if (NPC.downedGolemBoss == true && NPC.downedMoonlord != true)
				{
					item.damage = 97;
				}
				if (NPC.downedMoonlord == true)
				{
					item.damage = 117;
				}
			}
            
            for (int index = 0; index < 8; ++index)
            {
                float SpeedX = speedX + (float)Main.rand.Next(-60, 61) * 0.045f;
                float SpeedY = speedY + (float)Main.rand.Next(-60, 61) * 0.045f;
                int projectile1 = Projectile.NewProjectile(position.X, position.Y, SpeedX * 2, SpeedY * 2, mod.ProjectileType("MoonFlame"), damage, knockBack, player.whoAmI, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
            }
            return false;
        }
		public override void AddRecipes()
		{       
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AgheriumBar", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}
	}
}
