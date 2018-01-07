using System.Collections.Generic;
using Terraria.DataStructures;
using AgheriumMod.Items;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.RorbertGear
{
    public class StaffofPropulsion : ModItem
    {

        public override void SetDefaults()
        {
            item.damage = 35;
            item.magic = true;
            item.mana = 11;
            item.width = 50;
            item.height = 50;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 3.75f;
            item.value = 10000;
            item.rare = 3;
            item.autoReuse = true;
            item.shootSpeed = 4f;
            item.shoot = mod.ProjectileType("Blorb");
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MaterialBlob", 16);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff of Propulsion");
			Tooltip.SetDefault("Creates a ball of overheated gel at the cursor's position");
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int i = Main.myPlayer;
            float num72 = item.shootSpeed;
            int num73 = damage;
            float num74 = knockBack;
            num74 = player.GetWeaponKnockback(item, num74);
            player.itemTime = item.useTime;
            Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter, true);
            float num78 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
            float num79 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
            if (player.gravDir == -1f)
            {
                num79 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector2.Y;
            }
            float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
            float num81 = num80;
            if ((float.IsNaN(num78) && float.IsNaN(num79)) || (num78 == 0f && num79 == 0f))
            {
                num78 = (float)player.direction;
                num79 = 0f;
                num80 = num72;
            }
            else
            {
                num80 = num72 / num80;
            }
            num78 = 0f;
            num79 = 0f;
            vector2.X = (float)Main.mouseX + Main.screenPosition.X;
            vector2.Y = (float)Main.mouseY + Main.screenPosition.Y;
            Projectile.NewProjectile(vector2.X, vector2.Y, num78, num79, mod.ProjectileType("Blorb"), num73, num74, i, 0f, 0f);
            return false;
        }
    }
}