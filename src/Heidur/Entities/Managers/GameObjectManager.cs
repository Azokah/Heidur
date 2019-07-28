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
        public GameObject unit;
        public List<NonPlayerCharacter> npcs;
        public GameMap gameMap;

        public GameObjectManager()
        {
            unit = new GameObject();
            npcs = new List<NonPlayerCharacter>() { new NonPlayerCharacter(), new NonPlayerCharacter(), new NonPlayerCharacter(), new NonPlayerCharacter() };
            gameMap = new GameMap();
        }

        public void LoadContent(Game1 game)
        {
            gameMap.LoadContent(game);
            unit.spriteComponent.LoadContent(game);
            npcs.ForEach(n => n.LoadContent(game));
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

        public void Draw(Camera camera, SpriteBatch spriteBatch)
        {
            gameMap.Draw(camera, spriteBatch);
            unit.spriteComponent.Draw(camera, spriteBatch, unit.physicsComponent.position);
            npcs.ForEach(n => n.spriteComponent.Draw(camera, spriteBatch, n.physicsComponent.position));
        }

        public void RemoveDeadGameObjects()
        {
            var npcsToRemove = new List<NonPlayerCharacter>();
            foreach(var npc in npcs)
            {
                if(!npc.statsComponent.CheckIfAlive())
                {
                    npcsToRemove.Add(npc);
                }
            }

            npcsToRemove.ForEach(n => npcs.Remove(n));
        }
    }
}
