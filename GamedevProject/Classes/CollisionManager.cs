using GamedevProject.Blocks;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    class CollisionManager
    {
        private bool HasCollide(Rectangle rec1, Rectangle rec2)
        {
           return rec1.Intersects(rec2);
               
        }

        public (bool hasCollide, float previousLanding) CheckCollisions(List<Block> blocks, Rectangle futureHitbox, IJumpable jumpable)
        {
            bool hasCollide = false;
            var previousLanding = jumpable.Landing;
            foreach (var block in blocks)
            {
                if (block != null)
                    hasCollide = HasCollide(futureHitbox, block.BoundingBox);
                if (hasCollide && block.BoundingBox.Top - 50 <= futureHitbox.Bottom + jumpable.JumpHeight)
                {
                    jumpable.Landing = block.BoundingBox.Top - 50;
                    previousLanding = block.BoundingBox.Top - 50 - 16;
                    break;
                }
            }

            return (hasCollide, previousLanding);
        }
    }
}
