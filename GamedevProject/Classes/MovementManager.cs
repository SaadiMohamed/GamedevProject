using GamedevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;
using GamedevProject.Blocks;

namespace GamedevProject.Classes
{
    // Single Responsiblity Principle

    static class MovementManager
    {
        static public void Move(IMovable movable, List<IGameObject> objects)
        {
            ICollide collide = movable as ICollide;
            IJumpable jumpable = movable as IJumpable;
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            //soorten animations idle en lopen
            movable.currentAnimation = direction.X == 0 ? movable.movableAnimations.Idle : movable.movableAnimations.Run;

            //direction.Y == 1
            if (direction.X == -1)
                movable.SpriteEffects = SpriteEffects.FlipHorizontally;
            else if (direction.X == 1)
                movable.SpriteEffects = SpriteEffects.None;


            if (jumpable != null)
            {
                collide.HitBox = new Rectangle(collide.HitBox.X, collide.HitBox.Y + jumpable.Jump(direction), collide.HitBox.Width, collide.HitBox.Height);
            }


            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;
            var futureHitbox = new Rectangle(collide.HitBox.X + (int)distance.X, collide.HitBox.Y + (int)distance.Y, collide.HitBox.Width, collide.HitBox.Height);

            var (hasCollide, previousLanding) = CollisionManager.CheckCollisions(objects, futureHitbox, jumpable);

            if (previousLanding != jumpable.Landing)
            {
                futurePosition = new Vector2(futurePosition.X, previousLanding);
                futureHitbox = new Rectangle(collide.HitBox.X + (int)distance.X, (int)futurePosition.Y + 10, collide.HitBox.Width, collide.HitBox.Height);
            }

            if (futurePosition.X <= (800 - 60) && futurePosition.X >= 0 && futurePosition.Y <= 480 - 66 && futurePosition.Y > 0)
            {
                if (!hasCollide || movable.Position.Y <= jumpable.Landing)
                {
                    movable.Position = futurePosition;
                    collide.HitBox = futureHitbox;
                    jumpable.Landing = 362;
                }
            }

            if (hasCollide)
                jumpable.Landing = previousLanding;

        }
    }

}


