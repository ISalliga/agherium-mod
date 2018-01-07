using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AgheriumMod.Items.FallenAngelGear
{
	public class DarklightBlade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Darklight Blade");
			Tooltip.SetDefault("Harnesses the power of dark and light to create an afterimage of itself which floats in place until an enemy hits it");
		}
		public override void SetDefaults()
		{
			item.damage = 66;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 2;
			item.shoot = mod.ProjectileType("DarklightSwordBeam");
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "DarklightEssence", 17);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
