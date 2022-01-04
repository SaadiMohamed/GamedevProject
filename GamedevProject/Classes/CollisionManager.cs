using GamedevProject.Blocks;
using GamedevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using GamedevProject.Classes.Enemies;

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
            var hasCollide = false;
            var previousLanding = jumpable.Landing;
            foreach (var obj in objects.Where(x => x != null).ToList())
            {
                var gameObjectHitbox = new Rectangle(0, 0, 0, 0);
                if (obj is Block block)
                    gameObjectHitbox = block.BoundingBox;
                else if (obj is ICollide collide)
                    gameObjectHitbox = collide.HitBox;

                hasCollide = HasCollide(futureHitbox, gameObjectHitbox);

                if (futureHitbox.Top <= gameObjectHitbox.Bottom && hasCollide && futureHitbox.Top > gameObjectHitbox.Top && jumpable.HasJumped)
                {
                    if (futureHitbox.Right >= gameObjectHitbox.Left && futureHitbox.Right <= gameObjectHitbox.Right || futureHitbox.Left >= gameObjectHitbox.Left && futureHitbox.Left <= gameObjectHitbox.Right)
                    {
                        jumpable.IsFalling = true;
                        break;
                    }

                }
                else
                    jumpable.IsFalling = false;

                if (obj is IEnemies monster && hasCollide)
                {
                    if (futureHitbox.Bottom - 1 == gameObjectHitbox.Top && monster is Slayer)
                    {
                        monster.Speed = new Vector2(0, 0);
                        monster.currentAnimation = monster.movableAnimations.Dead;
                    }

                    if (monster.Speed.X < 0 && monster is Slayer)
                    {
                        --Hero.Instance.Lives;
                        monster.Speed *= new Vector2(-1, 1);
                    }

                    if (monster is Hedgehog)
                    {
                        --Hero.Instance.Lives;
                        monster.Speed *= new Vector2(-1, 1);
                    }
                    if (monster is Spike)
                    {
                        --Hero.Instance.Lives;
                    }
                }

                if (hasCollide && obj is Sleigh)
                {
                    Hero.Instance.NextLevel = true;
                    break;
                }
                if (obj is Present present && hasCollide)
                {
                    present.Position = new Vector2(800 - ((Hero.Instance.Presents.Count + 1) * 30), 0);
                    Hero.Instance.Presents.Add(present);
                    present.HitBox = new Rectangle();
                }


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
