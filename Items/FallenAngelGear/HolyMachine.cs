using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace AgheriumMod.Items.FallenAngelGear
{
	public class HolyMachine : ModItem
	{
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("The Holy Machine");
            Tooltip.SetDefault("Shoots a laser that splits into two smaller lasers");
        }

        public override void SetDefaults()
        {
            item.damage = 35;
            item.noMelee = true;
            item.ranged = true;
            item.autoReuse = true;                            
            item.rare = 5;
            item.width = 30;
            item.height = 24;
			item.useAmmo = AmmoID.Bullet;
            item.useTime = 8;
            item.UseSound = SoundID.Item33;
            item.useStyle = 8;
            item.shootSpeed = 6f;               
            item.useAnimation = 2;
            item.shoot = mod.ProjectileType("LaserSplit");
            item.value = Item.sellPrice(0, 4, 0, 0);
        }
		public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float SpeedX = speedX + (float) Main.rand.Next(-10, 11) * 0.05f;
			float SpeedY = speedY + (float) Main.rand.Next(-10, 11) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, mod.ProjectileType("LaserSplit"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
			return false;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarklightEssence", 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}