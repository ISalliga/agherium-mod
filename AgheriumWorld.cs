using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using AgheriumMod.NPCs;
using AgheriumMod.NPCs.Bosses;
using AgheriumMod.NPCs.Minibosses;
using Terraria.ModLoader.IO;
using System.Linq;
using Terraria.Localization;

namespace AgheriumMod
{
    public class AgheriumWorld : ModWorld
    {
		public static bool downedOrb = false;
		public static bool downedAngel = false;
		public static bool downedRorbert = false;
		public static bool downedSpodermen = false;
		public static bool downedSoul = false;
		
		public override void Initialize()
		{
			downedOrb = false;
			downedAngel = false;
			downedRorbert = false;
			downedSpodermen = false;
			downedSoul = false;
		}
        public override TagCompound Save()
        {
            var downed = new List<string>();
            if (downedOrb) downed.Add("downedOrb");
			if (downedAngel) downed.Add("downedAngel");
			if (downedSoul) downed.Add("downedSoul");
			if (downedSpodermen) downed.Add("downedSpodermen");
			if (downedRorbert) downed.Add("downedRorbert");

            return new TagCompound
			{
                {"downed", downed}
            };
        }

        public override void Load(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedOrb = downed.Contains("downedOrb");
			downedAngel = downed.Contains("downedAngel");
			downedSoul = downed.Contains("downedSoul");
			downedSpodermen = downed.Contains("downedSpodermen");
			downedRorbert = downed.Contains("downedRorbert");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                downedOrb = flags[0];
				downedAngel = flags[1];
				downedRorbert = flags[2];
				downedSpodermen = flags[3];
				downedSoul = flags[4];
            }
            else
            {
                ErrorLogger.Log("AgheriumMod: Unknown loadVersion: " + loadVersion);
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedOrb;
			flags[1] = downedAngel;
			flags[2] = downedRorbert;
			flags[3] = downedSpodermen;
			flags[4] = downedSoul;
			writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedOrb = flags[0];
			downedAngel = flags[10];
			downedRorbert = flags[2];
			downedSpodermen = flags[3];
			downedSoul = flags[4];
        }
    }
}