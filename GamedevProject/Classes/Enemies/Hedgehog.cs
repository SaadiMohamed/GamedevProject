using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamedevProject.Classes.Enemies
{
    internal class Hedgehog : IEnemies, IMovable
    {
        Texture2D monsterTexture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Animation currentAnimation { get; set; }
        public Animations movableAnimations { get; set; }

        public Rectangle HitBox { get; set; }


        public Hedgehog(ContentManager content)
        {
            movableAnimations = new Animations();
            movableAnimations.Run = new Animation();
            movableAnimations.Dead = new Animation();
            monsterTexture = content.Load<Texture2D>("Hedgehog Sprite Sheet");
            Position = new Vector2(550, 355);

            Speed = new Vector2(2, 0);
            for (int i = 0; i < 4; i++)
            {
                movableAnimations.Run.AddFrame(new AnimationFrame(new Rectangle(i * 32, 20, 30, 20)));

            }

            HitBox = new Rectangle((int)Position.X, (int)Position.Y , 30, 20);
            currentAnimation = new Animation();
            currentAnimation = movableAnimations.Run;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(monsterTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(), 2, SpriteEffects, 0f);

        }

        public void Update(GameTime gameTime)
        {
            int rotate = 10;
            if (Speed.X < 0) 
                SpriteEffects = SpriteEffects.FlipHorizontally;
            
            else { 
                SpriteEffects = SpriteEffects.None;
                rotate += 3;
            }
            
            if (HitBox.X >= (650) || HitBox.X <= 400)
            {
                Speed *= new Vector2(-1, 1);
            }
            Position += Speed;
            HitBox = new Rectangle((int)Position.X + rotate, (int)Position.Y, 33, 20);

            currentAnimation.Update(gameTime);

        }
    }
}
