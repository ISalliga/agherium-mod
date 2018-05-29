using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace AgheriumMod.Items.MiscGear
{
    public class LamentingMourge : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lamenting Mourge");
			Tooltip.SetDefault("Leave them in shambles.");
		}
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 10;
            item.rare = 5;
            item.noMelee = true;
            item.useStyle = 5;
            item.useAnimation = 40;
            item.useTime = 40;
            item.knockBack = 7.5f;
            item.damage = 75;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("LamentingMourgeProj");
            item.shootSpeed = 10f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofFright, 15);
			recipe.AddIngredient(ItemID.HallowedBar, 7);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
 
    }
}