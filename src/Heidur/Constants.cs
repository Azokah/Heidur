using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
            public const float DEFAULT_UNIT_HIT_INTERVAL = 1.5f;
            public const float DEFAULT_UNIT_Z_INDEX = 0.3f;
			public const int DEFAULT_SPEED = 256;
		}

		public class Stats
		{
			public const int DEFAULT_RANGE = 3; // This is measured in Tiles
			public const int DEFAULT_DAMAGE = 1;
			public const int DEFAULT_HP = 10;
			public const int DEFAULT_EXPERIENCE = 0;
			public const int DEFAULT_LEVEL = 1;
			public const int DEFAULT_REWARD = 250;
			public const int DEFAULT_EXPERIENCE_GAIN = 100;
			public const int DEFAULT_STRENGTH = 1;
			public const int DEFAULT_DEXTERITY= 1;
			public const int DEFAULT_INTELLIGENCE = 1;
			public const int DEFAULT_CONSTITUTION = 1;
			public const int DEFAULT_SPIRIT = 1;
			public const float INTERVAL_MODIFIER_CONSTANT = 0.013f;
			public const int DEFAULT_LEARNINGPOINTS_ADVANCEMENT = 5;
		}

		public class Leveling
		{
			public const int DEFAULT_LEVELING_ADVANCEMENT = 1000;
			public const int DEFAULT_HP_ADVANCEMENT = 10;
			public const int DEFAULT_DAMAGE_ADVANCEMENT = 2;
		}

        public class NPC
        {
            public const string DEFAULT_SPRITE = "ninja_m";
            public const int DEFAULT_SPEED = 128;
            public const float DEFAULT_UNIT_HIT_INTERVAL = 2f;
            public const float DEFAULT_UNIT_MOVE_INTERVAL_IDLE = 4f;
            public const float DEFAULT_UNIT_MOVE_INTERVAL_AGGRESIVE = 0.3f;
            public const int DEFAULT_NPC_SIZE_MODIFIER = 1;
            public const int DEFAULT_VISION = 8; // This is measured in Tiles
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
                HIT,
				LEVEL_UP
            }

            public static readonly string[] FXSoundsNamesAndPaths = { "Hit", "Level_up" }; 
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
			public const string DEFAULT_CROSSHAIR_SPRITE = "crosshair";
			public static Vector2 DEFAULT_UI_POSITION = new Vector2(0, 0);
			public static Vector2 DEFAULT_UI_POSITION_INCREMENT_Y = new Vector2(0, 32);
			public static Color DEFAULT_UI_COLOR = Color.Yellow;
			public static float DEFAULT_FLOATING_TEXT_DURATION = 1.0f;
		}

		public class RangedSkill
		{
			public const int DEFAULT_RANGED_RANGE = 5;
		}

		public class Item
		{
			public const string DEFAULT_NAME = "Item";
			public const string DEFAULT_DESCRIPTION = "Description";
			public const string DEFAULT_ITEM_TEXTURE = "star";
		}

		public class Scene
		{
			public enum SCENE_STATE
			{
				INITIALIZING,
				LOADING,
				RUNNING,
				PAUSED
			}
		}
	}
}
