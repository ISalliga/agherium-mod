using Terraria.ModLoader;

namespace AgheriumMod
{
	class AgheriumMod : Mod
	{
		public AgheriumMod()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
