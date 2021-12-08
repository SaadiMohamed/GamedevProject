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
            ICollide collide = movable as ICollide;
            IJumpable jumpable = movable as IJumpable;
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

                int vector = 0;
                if (direction.Y == 1 && !jumpable.HasJumped && jumpable.HeightDestination <= 0)
                {
                    jumpable.HasJumped = true;
                    jumpable.HeightDestination = movable.Position.Y;
                }

                if (jumpable.HasJumped && jumpable.HeightDestination - jumpable.JumpHeight < movable.Position.Y)
                {
                    vector = -8;
 
                }
                else if ( movable.Position.Y < jumpable.Landing)
                {
                    
                    jumpable.HasJumped = false;
                    vector = 4;
                }
                else
                {
                    jumpable.HeightDestination = 0;

                }
                movable.Position += new Vector2(0, vector);
                collide.HitBox = new Rectangle(collide.HitBox.X, collide.HitBox.Y + vector, collide.HitBox.Width, collide.HitBox.Height);
            }

            
            var distance = direction * movable.Speed;
            var futureHitbox =new Rectangle(collide.HitBox.X + (int)distance.X,collide.HitBox.Y + (int) distance.Y, collide.HitBox.Width, collide.HitBox.Height);
            var futurePosition = movable.Position + distance;
           
            bool hasCollide = new CollisionManager().HasCollide(futureHitbox, new Rectangle(300, 414, 50, 48));

            if (futurePosition.X <= (800 - 60) && futurePosition.X >= 0 && futurePosition.Y <= 480 - 66 && futurePosition.Y > 0 && !hasCollide || movable.Position.Y <= 364 )
            {
                movable.Position = futurePosition;
                collide.HitBox = futureHitbox;
            }
            if(hasCollide && new Rectangle(300, 414, 50, 48).Top >= futureHitbox.Y)
            {
                jumpable.Landing = new Rectangle(300, 414, 50, 48).Top - new Rectangle(300, 414, 50, 48).Height - 4;
            }                
            else
                jumpable.Landing = 414;

            hasCollide = new CollisionManager().HasCollide(futureHitbox, new Rectangle(400, 390, 50, 50));
            if (hasCollide && new Rectangle(300, 414, 50, 48).Top >= futureHitbox.Y)
            {
                jumpable.Landing = new Rectangle(300, 414, 50, 48).Top - new Rectangle(300, 414, 50, 48).Height - 4;
            }
            else
                jumpable.Landing = 414;
            //List<Rectangle> collisions = new List<Rectangle>();
            //collisions.Add(new Rectangle(300, 414, 50, 50));
            //collisions.Add(new Rectangle(400, 390, 50, 50));

                //foreach (var collision in collisions)
                //{
                //    hasCollide = new CollisionManager().HasCollide(futureHitbox, collision);
                //    if (hasCollide && collision.Top > futureHitbox.Y)
                //    {
                //        jumpable.Landing = collision.Top - collision.Height - 2;
                //        Debug.WriteLine(collision.Top - collision.Height);
                //        movable.Position = new Vector2(movable.Position.X, jumpable.Landing);
                //        break;
                //    }
                //    else
                //        jumpable.Landing = 414;

                //}

        }

    }

}


