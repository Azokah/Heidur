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

        public const float FloorZIndex = 0.1f;
        public const float ObjectsZIndex = 0.2f;
        public const float WallsZIndex = 0.5f;

        public Vector2 position;

        public Texture2D Texture;

        public int[,] FloorLayer = new int[Height, Width];
        public int[,] WallsLayer = new int[Height, Width];
        public int[,] ObjectsLayer = new int[Height, Width];
        public bool[,] ObjectsCollisionLayer = new bool[Height, Width];
        public bool[,] UnitsCollisionLayer = new bool[Height, Width];

        public GameMap()
        {
            position = new Vector2()
            {
                X = 0,
                Y = 0
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            position.Y = 0;
            position.X = 0;
            for (int j = 0; j < Height; j++)
            {
                position.Y = j * Constants.TILESIZE;
                for (int i = 0; i < Width; i++)
                {
                    position.X = i * Constants.TILESIZE;

                    Rectangle tileToDrawPositionInAtlas = new Rectangle(0 + FloorLayer[j, i], 0, Constants.TILESIZE, Constants.TILESIZE);
                    tileToDrawPositionInAtlas.Y += tileToDrawPositionInAtlas.X / Constants.Map.TILES_PER_ROW;
                    tileToDrawPositionInAtlas.X -= (tileToDrawPositionInAtlas.Y * Constants.Map.TILES_PER_ROW);
                    tileToDrawPositionInAtlas.Y *= Constants.TILESIZE;
                    tileToDrawPositionInAtlas.X = (tileToDrawPositionInAtlas.X * Constants.TILESIZE) - Constants.TILESIZE;

                    spriteBatch.Draw(this.Texture, this.position - Camera.position, tileToDrawPositionInAtlas, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, FloorZIndex);

                    tileToDrawPositionInAtlas = new Rectangle(0 + WallsLayer[j, i], 0, Constants.TILESIZE, Constants.TILESIZE);
                    tileToDrawPositionInAtlas.Y += tileToDrawPositionInAtlas.X / Constants.Map.TILES_PER_ROW;
                    tileToDrawPositionInAtlas.X -= (tileToDrawPositionInAtlas.Y * Constants.Map.TILES_PER_ROW);
                    tileToDrawPositionInAtlas.Y *= Constants.TILESIZE;
                    tileToDrawPositionInAtlas.X = (tileToDrawPositionInAtlas.X * Constants.TILESIZE) - Constants.TILESIZE;

                    spriteBatch.Draw(this.Texture, this.position - Camera.position, tileToDrawPositionInAtlas, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, WallsZIndex);

                    tileToDrawPositionInAtlas = new Rectangle(0 + ObjectsLayer[j, i], 0, Constants.TILESIZE, Constants.TILESIZE);
                    tileToDrawPositionInAtlas.Y += tileToDrawPositionInAtlas.X / Constants.Map.TILES_PER_ROW;
                    tileToDrawPositionInAtlas.X -= (tileToDrawPositionInAtlas.Y * Constants.Map.TILES_PER_ROW);
                    tileToDrawPositionInAtlas.Y *= Constants.TILESIZE;
                    tileToDrawPositionInAtlas.X = (tileToDrawPositionInAtlas.X * Constants.TILESIZE) - Constants.TILESIZE;

                    spriteBatch.Draw(this.Texture, this.position - Camera.position, tileToDrawPositionInAtlas, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, ObjectsZIndex);
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
            return ObjectsCollisionLayer[yToTiles, xToTiles] && UnitsCollisionLayer[yToTiles, xToTiles];
        }

        public bool IsTileWalkable(Vector2 position)
        {
            return IsTileWalkable(Convert.ToInt32(position.X), Convert.ToInt32(position.Y));
        }

        public bool IsTileWalkable(Point position)
        {
            return IsTileWalkable(position.X, position.Y);
        }

        public void Update(List<GameObject> units)
        {
            UpdateCollisionMapWithUnits(units);
        }

        private void UpdateCollisionMapWithUnits(List<GameObject> units)
        {
            for (int j = 0; j < Height; j++)
            {
                for (int i = 0; i < Width; i++)
                {
                    UnitsCollisionLayer[j, i] = true;
                }
            }

            foreach (var unit in units)
            {
                UnitsCollisionLayer[Convert.ToInt32(unit.PhysicsComponent.position.Y/Constants.TILESIZE), Convert.ToInt32(unit.PhysicsComponent.position.X / Constants.TILESIZE)] = false;

                // We also set the destination tile as occupied, because if a unit is moving there will be colission issues, such as two units in the same tile
                UnitsCollisionLayer[Convert.ToInt32(unit.PhysicsComponent.destination.Y / Constants.TILESIZE), Convert.ToInt32(unit.PhysicsComponent.destination.X / Constants.TILESIZE)] = false;
            }
        }
    }
}
