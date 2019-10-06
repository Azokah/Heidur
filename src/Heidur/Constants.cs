﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur
{
    public static class Constants
    {
        // Configuration
        public const int RESOLUTION_WIDTH = 1024;
        public const int RESOLUTION_HEIGHT = 768;
        public const int TILESIZE = 32;

        //Below here paste constants of entities
        public class Camera
        {
            public const int CAMERA_SPEED = 16; // Try to keep it in 2^x.
            public const int CAMERA_BORDERS = 0;
            public const int MOUSE_MOVEMENT_WIDTH_ACTIVE_ZONE = RESOLUTION_WIDTH / 3;
            public const int MOUSE_MOVEMENT_HEIGHT_ACTIVE_ZONE = RESOLUTION_HEIGHT / 3;
        }

        public class Unit
        {
            public const string DEFAULT_SPRITE = "AdventurerTileset";
            public const int DEFAULT_RANGE = 15; // This is measured in Tiles
            public const int DEFAULT_SPEED = 256;
            public const int DEFAULT_DAMAGE = 1;
            public const int DEFAULT_HP = 10;
            public const int DEFAULT_EXPERIENCE = 0;
            public const int DEFAULT_EXPERIENCE_GAIN = 100;
            public const float DEFAULT_UNIT_HIT_INTERVAL = 1.5f;
            public const float DEFAULT_UNIT_Z_INDEX = 0.3f;
        }

        public class NPC
        {
            public const string DEFAULT_SPRITE = "MagoIao";
            public const float DEFAULT_UNIT_HIT_INTERVAL = 2f;
            public const float DEFAULT_UNIT_MOVE_INTERVAL_IDLE = 4f;
            public const float DEFAULT_UNIT_MOVE_INTERVAL_AGGRESIVE = 0.3f;
            public const int DEFAULT_RANGE = 8; // This is measured in Tiles
            public const int DEFAULT_SPEED = 64;
        }

        public class Map
        {
            public const string DEFAULT_MAP_SPRITE = "MapTileset";
            public const int DEFAULT_MAP_WIDTH = 100;
            public const int DEFAULT_MAP_HEIGHT = 100;
            public const int TILES_PER_ROW = 16;
        }

        public class Music
        {
            public const string DEFAULT_MUSIC = "BattleTheme1";
            public const float DEFAULT_VOLUMEN_AUDIO = 0.1f;
        }

        public class Physics
        {
            public enum FacingDirections
            {
                UP,
                DOWN,
                LEFT,
                RIGHT
            }
        }

        public class Sprites
        {
            public const float DEFAULT_UNIT_INDEX = 0.3f;
            public const int DEFAULT_ZOOMING_MODIFIER = 2;
        }

        public class Animation
        {
            public const float DEFAULT_FRAMES_SPEED_MS = 0.1f;
            public const int DEFAULT_FRAMES_IDLE = 4;
            public const int DEFAULT_FRAMES_WALKING = 4;
            public const int DEFAULT_FRAMES_ATTACK = 4;
            public enum FrameCategory
            {
                WALKING_S,
                WALKING_N,
                WALKING_E,
                WALKING_W,
                IDLE,
                ATTACK
            }
            public const int FRAME_CATEGORIES = 6;
        }
    }
}
