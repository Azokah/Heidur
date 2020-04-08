using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Managers
{
    public static class MapLoaderManager
    {
        public const int Width = Constants.Map.DEFAULT_MAP_WIDTH;
        public const int Height = Constants.Map.DEFAULT_MAP_HEIGHT;

        public const string path = @"..\..\..\..\Resources\Maps\";
        public const string floorLayerName = "Suelo";
        public const string wallsLayerName = "Paredes";
        public const string objectsLayerName = "Objetos";
        public const string collisionLayerName = "Colision";

        public static GameMap LoadMap(string mapName)
        {
            return LoadMapFromJson(mapName);
        }

        private static GameMap LoadMapFromJson(string mapName)
        {
            using (StreamReader r = new StreamReader(path + mapName))
            {
                string json = r.ReadToEnd();

                JObject o = JObject.Parse(json);

                
                int[,] floorLayer = new int[Height, Width];
                int[,] wallsLayer = new int[Height, Width];
                int[,] objectsLayer = new int[Height, Width];
                bool[,] collisionLayer = new bool[Height, Width];

                foreach (var layer in o["layers"])
                {
                    int wCounter = 0;
                    int hCounter = 0;

                    foreach (var tile in layer["data"])
                    {
                        if (layer["name"].ToString().Equals(floorLayerName,StringComparison.InvariantCultureIgnoreCase))
                        {
                            floorLayer[hCounter, wCounter] = int.Parse(tile.ToString());
                        }
                        else if (layer["name"].ToString().Equals(wallsLayerName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            wallsLayer[hCounter, wCounter] = int.Parse(tile.ToString());
                        }
                        else if (layer["name"].ToString().Equals(objectsLayerName, StringComparison.InvariantCultureIgnoreCase))
                        {
                            objectsLayer[hCounter, wCounter] = int.Parse(tile.ToString());
                        }
                        else
                        {
                            collisionLayer[hCounter, wCounter] = tile.ToString().Equals("1");
                        }

                        wCounter++;

                        if (wCounter >= Width)
                        {
                            hCounter++;
                            wCounter = 0;
                        }
                    }
                }

                GameMap mapToReturn = new GameMap();
                mapToReturn.FloorLayer = floorLayer;
                mapToReturn.ObjectsLayer = objectsLayer;
                mapToReturn.WallsLayer = wallsLayer;
                mapToReturn.ObjectsCollisionLayer = collisionLayer;

                return mapToReturn;
            }
        }
    }
}
