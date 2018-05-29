using Terraria.ID;
using Terraria.ModLoader;

namespace AgheriumMod.Items.EtherumGear
{
	public class EtherumPulsar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Etherum Pulsar");
			Tooltip.SetDefault("Creates an expanding damage area around the user which hits multiple times");
		}
		public override void SetDefaults()
		{
			item.damage = 10;
			item.noMelee = true;
			item.magic = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 50;
			item.useAnimation = 50;
			item.shoot = mod.ProjectileType("PulsyThing");
			item.shootSpeed = 0;
			item.useStyle = 1;
			item.mana = 40;
			item.knockBack = 2;
			item.rare = 4;
			item.autoReuse = false;
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

