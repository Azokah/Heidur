﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur
{
    class Constants
    {
        // Configuration
        public const int RESOLUTION_WIDTH = 1024;
        public const int RESOLUTION_HEIGHT = 768;
        public const int TILESIZE = 64;

        //Below here paste constants of entities
        public class Camera
        {
            public const int CAMERA_SPEED = 16; // Try to keep it in 2^x.
            public const int CAMERA_BORDERS = 0;
        }

        public class Unit
        {
            public const string DEFAULT_UNIT_SPRITE = "Unit";
            public const int DEFAULT_RANGE = 32; // This is measured in Tiles
            public const int DEFAULT_SPEED = 256;
            public const int DEFAULT_DAMAGE = 1;
            public const int DEFAULT_HP = 10;
            public const int DEFAULT_EXPERIENCE = 0;
            public const int DEFAULT_EXPERIENCE_GAIN = 100;
            public const float DEFAULT_UNIT_HIT_INTERVAL = (float)1.5;
        }

        public class Map
        {
            public const string DEFAULT_MAP_SPRITE = "GameMapSprites";
            public const int DEFAULT_MAP_WIDTH = 20;
            public const int DEFAULT_MAP_HEIGHT = 20;

            public enum TILES
            {
                Grass,
                Dirt,
                StoneWall,
                Sand,
                WoodenFloor
            }
        }

        public class Music
        {
            public const string DEFAULT_MUSIC = "BattleTheme1";
            public const float DEFAULT_VOLUMEN_AUDIO = 0;
        }
    }
}
