using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.EtherumGear
{
	public class EtherumScepter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Etherum Scepter");
			Tooltip.SetDefault("FRICKIN' LAZER BEAMS");
		}
		public override void SetDefaults()
		{
			item.damage = 21;
			item.noMelee = true;
			item.magic = true;
			item.width = 50;
			item.height = 20;
			item.useTime = 7;
			item.useAnimation = 7;
			item.shoot = 88;
			item.shootSpeed = 19;
			item.useStyle = 5;
			item.mana = 5;
			item.knockBack = 2;
			item.rare = 4;
			item.UseSound = SoundID.Item12;
			item.autoReuse = true;
			item.useTurn = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EtherumBar", 14);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

