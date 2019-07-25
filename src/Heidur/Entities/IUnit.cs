using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heidur.Entities
{
    public interface IUnit
    {
        Texture2D Texture { get; set; }

        Vector2 position { get; set; }
        Vector2 destination { get; set; }
        int Speed { get; set; }
        int HP { get; set; }
        int Damage { get; set; }
        int Range { get; set; }
        int Experience { get; set; }

        bool IsSelected { get; set; }
        int currentHP { get; set; }

        void Init();

        void MoveTo(Vector2 goTo);

        bool Attack(Unit target);

        void TakeDamage(int damage);

        void Update(float deltaTime, List<NonPlayerCharacter> nearbyNPC);

        bool CheckIfAlive();

        int GetDistanceFromUnit(Unit target);

        bool CheckIfClicked(Vector2 clickPosition);

        void Draw(Camera camera, SpriteBatch spriteBatch);

        void KeyActions(KeyboardState keyBoardState);

        void GainExperience(int experience);
    }
}
