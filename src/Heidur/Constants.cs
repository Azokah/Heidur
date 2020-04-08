using Microsoft.Xna.Framework;
using System;
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
        public const int DEFAULT_ZOOMING_MODIFIER = 2;

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
            public const string DEFAULT_SPRITE = "warrior_m";
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
            public const string DEFAULT_SPRITE = "ninja_m";
            public const int DEFAULT_SPEED = 128;
            public const float DEFAULT_UNIT_HIT_INTERVAL = 2f;
            public const float DEFAULT_UNIT_MOVE_INTERVAL_IDLE = 4f;
            public const float DEFAULT_UNIT_MOVE_INTERVAL_AGGRESIVE = 0.3f;
            public const int DEFAULT_NPC_SIZE_MODIFIER = 1;
            public const int DEFAULT_RANGE = 8; // This is measured in Tiles
        }

        public class Map
        {
            public const string DEFAULT_MAP_SPRITE = "MapTileset";
            public const int DEFAULT_MAP_WIDTH = 100;
            public const int DEFAULT_MAP_HEIGHT = 100;
            public const int TILES_PER_ROW = 16;
			public const string DEFAULT_MAP_NAME = "Town.json";
        }

        public class Music
        {
            public const string DEFAULT_MUSIC = "BattleTheme1";
            public const float DEFAULT_VOLUMEN_AUDIO = 0.0f;
        }

        public class SoundEffects
        {
            public enum FXSounds
            {
                HIT
            }

            public static readonly string[] FXSoundsNamesAndPaths = { "Hit" }; 
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
        }

        public class Animation
        {
            public const float DEFAULT_FRAMES_SPEED_MS = 0.1f;
            public const int DEFAULT_FRAMES_WALKING = 3;
            public enum FrameCategory
            {
                WALKING_N,
                WALKING_W,
                WALKING_S,
                WALKING_E
            }
            public const int FRAME_CATEGORIES = 4;
        }

        public class Particles
        {
            public const int DEFAULT_ATTACK_PARTICLES_AMMOUNT = 30;
            public const float DEFAULT_LAYER_DEPTH = 0.9f;

			public static List<string> DEFAULT_PARTICLES_SPRITES = new List<string>(){ "star", "circle" };


			public enum ParticlesStyle
            {
                ATTACK
            }
        }

		public class UI
		{
			public const float DEFAULT_UI_INDEX = 0.9f;
			public const string DEFAULT_UI_FONT = "Fonts/Calibri32";
			public static Vector2 DEFAULT_UI_POSITION = new Vector2(0, 0);
			public static Vector2 DEFAULT_UI_POSITION_INCREMENT_Y = new Vector2(0, 32);
			public static Color DEFAULT_UI_COLOR = Color.Yellow;
		}

		public class RangedSkill
		{
			public const int DEFAULT_RANGED_RANGE = 5;
		}
	}
}
