using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public class GameMap
    {
        public const int Width = Constants.Map.DEFAULT_MAP_WIDTH;
        public const int Height = Constants.Map.DEFAULT_MAP_HEIGHT;

        public Vector2 position;

        public Texture2D Texture;

        public int[,] Map = new int[Width, Height];
        public bool[,] ObjectsCollisionMap = new bool[Width, Height];
        public bool[,] UnitsCollisionMap = new bool[Width, Height];

        public GameMap()
        {
            position = new Vector2()
            {
                X = 0,
                Y = 0
            };

            for(int j = 0; j < Height; j++)
            {
                for(int i = 0; i < Width; i++)
                {
                    if ( i == 0 || j == 0 || i == Constants.Map.DEFAULT_MAP_WIDTH-1 || j == Constants.Map.DEFAULT_MAP_HEIGHT-1 )
                    {
                        Map[j,i] = (int)Constants.Map.TILES.StoneWall;
                        ObjectsCollisionMap[j, i] = false;
                    }
                    else
                    {
                        Map[j,i] = (int) Constants.Map.TILES.Dirt;
                        ObjectsCollisionMap[j, i] = true;
                    }
                    UnitsCollisionMap[j, i] = true;
                }
            }
        }

        public void Draw(Camera camera, SpriteBatch spriteBatch)
        {
            position.Y = 0;
            position.X = 0;
            for (int j = 0; j < Height; j++)
            {
                position.Y = j * Constants.TILESIZE;
                for (int i = 0; i < Width; i++)
                {
                    position.X = i * Constants.TILESIZE;
                    spriteBatch.Draw(this.Texture, this.position - camera.position, new Rectangle(0 + Map[j,i] * Constants.TILESIZE, 0, Constants.TILESIZE, Constants.TILESIZE), Color.White);
                }
            }
        }

        public void LoadContent(Game1 game)
        {
            this.Texture = game.Content.Load<Texture2D>(Constants.Map.DEFAULT_MAP_SPRITE);
        }

        public bool IsTileWalkable(int x, int y)
        {
            var xToTiles = x / Constants.TILESIZE;
            var yToTiles = y / Constants.TILESIZE;
            if ( yToTiles < 0 || xToTiles < 0 || yToTiles >= Constants.Map.DEFAULT_MAP_HEIGHT || xToTiles >= Constants.Map.DEFAULT_MAP_WIDTH)
            {
                return false;
            }
            return ObjectsCollisionMap[yToTiles, xToTiles] && UnitsCollisionMap[yToTiles, xToTiles];
        }

        public bool IsTileWalkable(Vector2 position)
        {
            return IsTileWalkable(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));
        }

        public bool IsTileWalkable(Point position)
        {
            return IsTileWalkable(position.X, position.Y);
        }

        public void Update(List<IUnit> units)
        {
            UpdateCollisionMapWithUnits(units);
        }

        private void UpdateCollisionMapWithUnits(List<IUnit> units)
        {
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    UnitsCollisionMap[j, i] = true;
                }
            }

            foreach (var unit in units)
            {
                UnitsCollisionMap[Convert.ToInt32(unit.position.Y/Constants.TILESIZE), Convert.ToInt32(unit.position.X / Constants.TILESIZE)] = false;

                // We also set the destination tile as occupied, because if a unit is moving there will be colission issues, such as two units in the same tile
                UnitsCollisionMap[Convert.ToInt32(unit.destination.Y / Constants.TILESIZE), Convert.ToInt32(unit.destination.X / Constants.TILESIZE)] = false;
            }
        }
    }
}
