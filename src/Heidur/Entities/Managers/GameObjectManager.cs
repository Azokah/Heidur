using Heidur.Entities.Processors;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities.Managers
{
    class GameObjectManager
    {
		private const string FixedStartingMapName = Constants.Map.DEFAULT_MAP_NAME;

        public GameObject unit;
        public List<GameObject> npcs;
        public GameMap gameMap;

        public GameObjectManager()
        {
            unit = new GameObject();
            npcs = new List<GameObject>() { new NonPlayerCharacter(50, 52), new NonPlayerCharacter(50,53), new NonPlayerCharacter(50,54), new NonPlayerCharacter(50,55) };
            gameMap = MapLoaderManager.LoadMap(FixedStartingMapName);
        }

        public void LoadContent(Game1 game)
        {
            gameMap.LoadContent(game);
            SpriteProcessor.LoadContent(game, unit.spriteComponent);
            npcs.ForEach(n => SpriteProcessor.LoadContent(game, n.spriteComponent));
        }

        public void Update(float delta)
        {
            unit.Update(delta, npcs.Cast<GameObject>().ToList(), gameMap);
            npcs.ForEach(n => n.Update(delta, new List<GameObject>() { unit }, gameMap));
            var units = new List<GameObject>();
            units.AddRange(npcs);
            units.Add(unit);
            gameMap.Update(units);

            RemoveDeadGameObjects();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            gameMap.Draw(spriteBatch);
            unit.Draw(spriteBatch, unit.physicsComponent.position);
            npcs.ForEach(n => n.Draw(spriteBatch, n.physicsComponent.position));
        }

        public void RemoveDeadGameObjects()
        {
            var npcsToRemove = new List<GameObject>();
            foreach(var npc in npcs)
            {
                if(!StatsProcessor.CheckIfAlive(npc.statsComponent))
                {
                    npcsToRemove.Add(npc);
                }
            }

            npcsToRemove.ForEach(n => npcs.Remove(n));
        }
    }
}
