using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Interfaces
{
    interface IJumpable
    {
        bool HasJumped { get; set; }
        float HeightDeparture{ get; set; }
        float Landing { get; set; }
        int JumpHeight { get; set; }


        public int Jump(Vector2 direction)
        {
            int vector = 0;
            var movable = this as IMovable;
            if (direction.Y == 1 && !HasJumped && HeightDeparture <= 0)
            {
                HasJumped = true;
                HeightDeparture = movable.Position.Y;
            }

            if (HasJumped && HeightDeparture - JumpHeight < movable.Position.Y)
            {
                vector = -8;
            }
            else if (movable.Position.Y < Landing)
            {

                HasJumped = false;
                vector = 4;
            }
            else
            {
                HeightDeparture = 0;
                HasJumped = false;

            }
            movable.Position += new Vector2(0, vector);
            return vector;
        }
    }
}
