using System;
using Terraria.Graphics.Shaders;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod.Items;

namespace AgheriumMod.Items.MiscGear
{
    public class Fyrebyrd : ModItem
    {
		int shots = 0;
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fyrebyrd");
        }
        public override void SetDefaults()
        {
            item.damage = 54;
            item.ranged = true;
            item.width = 46;
            item.height = 20;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4.5f;
            item.value = 50000;
            item.rare = 7;
            item.UseSound = SoundID.Item11;
            item.autoReuse = false;
            item.shootSpeed = 18f;
			item.useAmmo = AmmoID.Bullet;
            item.shoot = 14;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ectoplasm, 20);
			recipe.AddIngredient(ItemID.PhoenixBlaster, 1);
			recipe.AddIngredient(3854, 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			shots++;
			if (shots >= 5)
			{
				shots = 0;
				int phoenix = Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, 706, 60, knockBack, player.whoAmI, 0.0f, 0.0f);
				Main.projectile[phoenix].penetrate = 1;

			}
            int num6 = Main.rand.Next(2, 5);
            for (int index = 0; index < num6; ++index)
            {
                float SpeedX = speedX + (float)Main.rand.Next(-30, 31) * 0.05f;
                float SpeedY = speedY + (float)Main.rand.Next(-30, 31) * 0.05f;
                int bullet = Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
				//Main.projectile[bullet].shader = GameShaders.Armor.GetSecondaryShader(112, Main.LocalPlayer);
            }
            return false;
        }
    }
}