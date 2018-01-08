using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace AgheriumMod.Items.MiscGear
{
	public class ViableAgainstEverything : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Very Overpowered Launcher");
			Tooltip.SetDefault("This is obviously viable against every single boss in the game and you should craft it immediately.");
        }
        public override void SetDefaults()
		{
			item.damage = 999999;
			item.noMelee = true;
			item.ranged = true;
			item.autoReuse = true;                            //Channel so that you can held the weapon [Important]
			item.rare = 7;
			item.width = 20;
			item.height = 60;
			item.useStyle = 5;
            item.useTime = 8;
            item.shootSpeed = 6f;				//Speed is not important here
			item.useAnimation = 8;                         
			item.shoot = 282;
			item.value = Item.sellPrice(0, 5, 0, 0);
		}
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
            float num117 = 0.314159274f;
            int num118 = 1;
            Vector2 vector7 = new Vector2(speedX, speedY);
            vector7.Normalize();
            vector7 *= 80f;
            bool flag11 = Collision.CanHit(vector2, 0, 0, vector2 + vector7, 0, 0);
            for (int num119 = 0; num119 < num118; num119++)
            {
                float num120 = (float)num119 - ((float)num118 - 1f) / 2f;
                Vector2 value9 = vector7.RotatedBy((double)(num117 * num120), default(Vector2));
                if (!flag11)
                {
                    value9 -= vector7;
                }
                int laser = Projectile.NewProjectile(vector2.X + value9.X, vector2.Y + value9.Y, speedX, speedY, 371, 0, knockBack, player.whoAmI, 0.0f, 0.0f);
                Main.projectile[laser].penetrate = 10;
            }
            return false;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 45);
			recipe.AddIngredient(ItemID.FragmentVortex, 50);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}
