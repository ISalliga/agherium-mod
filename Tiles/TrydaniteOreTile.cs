using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AgheriumMod.Tiles
{
	public class TrydaniteOreTile : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			dustType = 226;
			drop = mod.ItemType("TrydaniteOre");
			minPick = 100;
			AddMapEntry(new Color(217, 142, 67));
		}
	}
}