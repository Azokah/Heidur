using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Heidur.Constants.Physics;

namespace Heidur.Entities.Components
{
    public class PhysicsComponent
    {
        public Vector2 position { get; set; }
        public Vector2 destination { get; set; }

        public FacingDirections FacingDirection;
        public List<GameObject> NearbyUnits;

        public float Clock;
        public bool Up, Down, Left, Right;
        public bool IsMoving;
        public int Speed { get; set; }
        public bool IsSelected { get; set; }

        public PhysicsComponent()
        {
            this.NearbyUnits = new List<GameObject>();
            position = new Vector2(50 * Constants.TILESIZE, 50 * Constants.TILESIZE);
            destination = position;
            Speed = Constants.Unit.DEFAULT_SPEED;
            Up = Down = Left = Right = IsMoving = false;
            FacingDirection = FacingDirections.DOWN;
            IsSelected = false;
        }

    }
}
