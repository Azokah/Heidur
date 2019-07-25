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

        public int[][] Map = new int[Width][];

        public float TileSize { get; private set; }

        public void Init()
        {
            position = new Vector2()
            {
                X = 0,
                Y = 0
            };

            for(int j = 0; j < Height; j++)
            {
                Map[j] = new int[Width];
                for(int i = 0; i < Width; i++)
                {
                    if ( i == 0 || j == 0 || i == Constants.Map.DEFAULT_MAP_WIDTH-1 || j == Constants.Map.DEFAULT_MAP_HEIGHT-1 )
                    {
                        Map[j][i] = (int)Constants.Map.TILES.StoneWall;
                    }
                    else
                    {
                        Map[j][i] = (int) Constants.Map.TILES.Grass;
                    }
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
                    spriteBatch.Draw(this.Texture, this.position - camera.position, new Rectangle(0 + Map[j][i] * Constants.TILESIZE, 0, Constants.TILESIZE, Constants.TILESIZE), Color.White);
                }
            }
        }

        public void LoadContent(Game1 game)
        {
            this.Texture = game.Content.Load<Texture2D>(Constants.Map.DEFAULT_MAP_SPRITE);
        }
    }
}
