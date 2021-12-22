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
                if (direction.Y == 1 && !jumpable.HasJumped && jumpable.HeightDeparture <= 0)
                {
                    jumpable.HasJumped = true;
                    jumpable.HeightDeparture = movable.Position.Y;
                }

                if (jumpable.HasJumped && jumpable.HeightDeparture - jumpable.JumpHeight < movable.Position.Y)
                {
                    vector = -8;                   
                }
                else if (movable.Position.Y < jumpable.Landing)
                {

                    jumpable.HasJumped = false;
                    vector = 4;
                }
                else
                {
                    jumpable.HeightDeparture = 0;
                    jumpable.HasJumped = false;

                }
                movable.Position += new Vector2(0, vector);
                collide.HitBox = new Rectangle(collide.HitBox.X, collide.HitBox.Y + vector, collide.HitBox.Width, collide.HitBox.Height);
            }           
            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;
            var futureHitbox = new Rectangle(collide.HitBox.X + (int)distance.X, collide.HitBox.Y + (int)distance.Y, collide.HitBox.Width, collide.HitBox.Height);

            bool hasCollide = false;
            //List<Rectangle> collisions = new List<Rectangle>
            //{
            //    // block voor collision
            //};

            List<Rectangle> collisions = new List<Rectangle>
            float landing = 0;
            foreach (var collision in collisions)
            {
                hasCollide = new CollisionManager().HasCollide(futureHitbox, collision);
                if (hasCollide && collision.Top <= futureHitbox.Bottom + jumpable.JumpHeight)
                {
                    landing = jumpable.Landing = collision.Top - collision.Height;
                    break;
                }
            }
            
            if (futurePosition.X <= (800 - 60)&& futurePosition.X >= 0 && futurePosition.Y <= 480 - 66 && futurePosition.Y > 0)
            {
                if(!hasCollide || movable.Position.Y <= jumpable.Landing)
                {
                    movable.Position = futurePosition;
                    collide.HitBox = futureHitbox;
                    jumpable.Landing = 360;
                }              
            }

            if(hasCollide)
            {           
                jumpable.Landing = landing - 4;
            }
        }

    }

}


