using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AgheriumMod.Items.RorbertGear
{
	public class GelatiniansBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gelatinians' Blade");
			Tooltip.SetDefault("Fires bouncy balls of gelatin!");
		}
		public override void SetDefaults()
		{
			item.damage = 32;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 2;
			item.shoot = mod.ProjectileType("GelBounceFriendly");
			item.shootSpeed = 15;
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "MaterialBlob", 16);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
