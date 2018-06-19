using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AgheriumMod.Items;

namespace AgheriumMod.Items.MiscGear
{
    public class ERW : ModItem
    {
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("E.R.W.");
			Tooltip.SetDefault("Fires an extremely eratically-moving projectile \n'Eratically Resplendent Wing - E.R.W.'");
        }
        public override void SetDefaults()
        {
            item.damage = 250;
            item.ranged = true;
            item.width = 46;
            item.height = 20;
            item.useTime = 39;
            item.useAnimation = 39;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 4.5f;
            item.value = 50000;
            item.rare = 7;
            item.UseSound = SoundID.Item99;
            item.autoReuse = true;
            item.shootSpeed = 18f;
			item.useAmmo = AmmoID.Bullet;
            item.shoot = mod.ProjectileType("ERWProj");
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SoulofFlight, 10);
			recipe.AddIngredient(ItemID.SoulofMight, 7);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 14);
			recipe.AddIngredient(ItemID.Ectoplasm, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("ERWProj"), 250, knockBack, player.whoAmI, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("ERWProj"), 250, knockBack, player.whoAmI, 0.0f, 0.5f + (float)Main.rand.NextDouble() * 0.9f);
			return false;
        }
    }
}