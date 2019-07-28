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
        public Unit unit;
        public List<NonPlayerCharacter> npcs;
        public GameMap gameMap;

        public GameObjectManager()
        {
            unit = new Unit();
            npcs = new List<NonPlayerCharacter>() { new NonPlayerCharacter(), new NonPlayerCharacter(), new NonPlayerCharacter(), new NonPlayerCharacter() };
            gameMap = new GameMap();
        }

        public void LoadContent(Game1 game)
        {
            gameMap.LoadContent(game);
            unit.LoadContent(game);
            npcs.ForEach(n => n.LoadContent(game));
        }

        public void Update(float delta)
        {
            unit.Update(delta, npcs.Cast<IUnit>().ToList(), gameMap);
            npcs.ForEach(n => n.Update(delta, new List<IUnit>() { unit }, gameMap));
            var units = new List<IUnit>();
            units.AddRange(npcs.Cast<IUnit>().ToList());
            units.Add(unit);
            gameMap.Update(units);
        }

        public void Draw(Camera camera, SpriteBatch spriteBatch)
        {
            gameMap.Draw(camera, spriteBatch);
            unit.Draw(camera, spriteBatch);
            npcs.ForEach(n => n.Draw(camera, spriteBatch));
        }
    }
}
