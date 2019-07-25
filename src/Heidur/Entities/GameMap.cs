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
                    Map[j][i] = 0;
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
                    if (Map[j][i] == 0)
                    {
                        position.X = i * Constants.TILESIZE;
                        spriteBatch.Draw(this.Texture, this.position - camera.position, Color.White);
                    }
                }
            }
        }
    }
}
