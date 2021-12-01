using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Input
{
    class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;

        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X = -1;
            }
            else if (state.IsKeyDown(Keys.Right))
            {
                direction.X = 1;
            }
            else
            {
                direction.X = 0;
            }

            if(state.IsKeyDown(Keys.Space))
            {
                direction.Y = 1;
            }
            
            return direction;
        }

    }
}
