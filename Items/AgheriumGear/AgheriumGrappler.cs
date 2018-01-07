using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace AgheriumMod.Items.AgheriumGear
{
	public class AgheriumGrappler : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Agherium Grappler");
			Tooltip.SetDefault("Fires a grappling hook that deals damage"
			+ "\nWorks in the grappling hook slot");
		}
		public override void SetDefaults()
		{
			item.damage = 23;
			item.noMelee = true;
			item.ranged = true;
			item.width = 54;
			item.height = 16;
			item.useTime = 10;
			item.useAnimation = 10;
			item.shoot = 73;
			item.autoReuse = false;
			item.knockBack = 2;
			item.shootSpeed = 13;
			item.useStyle = 5;
			item.rare = 4;
			item.UseSound = SoundID.Item11;
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
