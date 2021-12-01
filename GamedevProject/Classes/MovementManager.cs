using GamedevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace GamedevProject.Classes
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            var jumpable = movable as IJumpable;
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            //soorten animations idle en lopen
            movable.currentAnimation = direction.X == 0 ? Animations.Idle : Animations.Run;

            //direction.Y == 1
            if (direction.X == -1)
                movable.SpriteEffects = SpriteEffects.FlipHorizontally;
            else if (direction.X == 1)
                movable.SpriteEffects = SpriteEffects.None;

            //spring animation
            if (jumpable != null)
            {
                if (direction.Y == 1 && !jumpable.HasJumped && jumpable.HeightDestination <= 0)
                {
                    jumpable.HasJumped = true;
                    jumpable.HeightDestination = movable.Position.Y;
                }

                if (jumpable.HasJumped && jumpable.HeightDestination - jumpable.JumpHeight < movable.Position.Y)
                {
                    movable.Position += new Vector2(0, -8f);
                }
                else if (jumpable.HeightDestination > movable.Position.Y)
                {
                    movable.Position += new Vector2(0, 4f);
                    jumpable.HasJumped = false;
                }
                else
                {
                    jumpable.HeightDestination = 0;
                }
            }

            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance ;

            if (futurePosition.X <= (800 - 60) && futurePosition.X >= 0 && futurePosition.Y <= 480 - 66 && futurePosition.Y > 0)
            {
                movable.Position = futurePosition;
            }

            if (futurePosition.X <= (800 - 60) && futurePosition.X >= 0 && futurePosition.Y <= 480 - 66 && futurePosition.Y > 0)
            {
                movable.Position = futurePosition;
            }
        }

    }

}


