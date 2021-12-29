using GamedevProject.Blocks;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GamedevProject.Classes
{
    class CollisionManager
    {
        private static bool HasCollide(Rectangle rec1, Rectangle rec2)
        {
            return rec1.Intersects(rec2);

        }

        public static (bool hasCollide, float previousLanding) CheckCollisions(List<IGameObject> objects, Rectangle futureHitbox, IJumpable jumpable)
        {
            bool hasCollide = false;
            var previousLanding = jumpable.Landing;
            foreach (var obj in objects.Where(x => x != null).ToList())
            {
                Rectangle gameObjectHitbox = new Rectangle(0, 0, 0, 0);
                if (obj is Block block)
                    gameObjectHitbox = block.BoundingBox;
                
                else if (obj is Monster monster)
                    gameObjectHitbox = new Rectangle((int)monster.Position.X, (int)monster.Position.Y, monster.currentAnimation.CurrentFrame.SourceRectangle.Width, monster.currentAnimation.CurrentFrame.SourceRectangle.Height);



                hasCollide = HasCollide(futureHitbox, gameObjectHitbox);

                if (futureHitbox.Top <= gameObjectHitbox.Bottom && hasCollide && futureHitbox.Top > gameObjectHitbox.Top)
                {
                    if (futureHitbox.Right > gameObjectHitbox.Left && futureHitbox.Right < gameObjectHitbox.Right || futureHitbox.Left > gameObjectHitbox.Left && futureHitbox.Left < gameObjectHitbox.Right)
                        jumpable.IsFalling = true;
                }
                else
                    jumpable.IsFalling = false;
                if (hasCollide && gameObjectHitbox.Top - gameObjectHitbox.Height <= futureHitbox.Bottom + jumpable.JumpHeight && !jumpable.IsFalling)
                {
                    jumpable.OnLanding = true;
                    jumpable.Landing = gameObjectHitbox.Top - gameObjectHitbox.Height;
                    previousLanding = gameObjectHitbox.Top - gameObjectHitbox.Height - 16;
                    break;
                }

            }

            return (hasCollide, previousLanding);
        }
    }
}
