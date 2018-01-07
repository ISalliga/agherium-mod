using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.SpiderQueenGear
{
	public class Arachnophobia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Arachnophobia");
			Tooltip.SetDefault("Fires homing venom bubbles");
		}
		public override void SetDefaults()
		{
			item.damage = 49;
			item.noMelee = true;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 5;
			item.useAnimation = 25;
			item.shoot = mod.ProjectileType("VenomBubble");
			item.shootSpeed = 5;
			item.useStyle = 1;
			item.mana = 9;
			item.knockBack = 2;
			item.rare = 7;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.useTurn = false;
        }		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "SmoothSilk", 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

