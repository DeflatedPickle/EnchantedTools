﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EnchantedTools {
    public class WorldGeneration : ModWorld {
        public override void PostWorldGen() {
            var items = new int[] {
                mod.ItemType("EnchantedPickaxe")
            };

            var itemChoice = 0;

            for (var chestIndex = 0; chestIndex < 1000; chestIndex++) {
                var chest = Main.chest[chestIndex];

                if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 11 * 36) {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
                        if (chest.item[inventoryIndex].type == 1) {
                            chest.item[inventoryIndex].SetDefaults(items[itemChoice]);
                            itemChoice = (itemChoice + 1) % items.Length;
                            break;
                        }
                    }
                }
            }
        }
    }
}