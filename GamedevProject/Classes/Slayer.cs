using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SharpDX.Direct2D1.Effects;

namespace GamedevProject.Classes
{
    class Slayer: Enemies
    {
        Texture2D monsterTexture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Animation currentAnimation { get; set; }
        public Animations movableAnimations { get; set; }

        public Rectangle HitBox { get; set; }


        public Slayer(ContentManager content)
        {
            movableAnimations = new Animations();
            movableAnimations.Run = new Animation();
            movableAnimations.Dead = new Animation(20);
            monsterTexture = content.Load<Texture2D>("Shardsoul Slayer Sprite Sheet"); 
            Position = new Vector2(600, 350);

            Speed = new Vector2(2, 0);
            for (int i = 0; i < 5; i++)
            {
                movableAnimations.Run.AddFrame(new AnimationFrame(new Rectangle(i * 64, 88, 48, 40)));

            }
            for (int i = 0; i < 7; i++)
            {
                movableAnimations.Dead.AddFrame(new AnimationFrame(new Rectangle(i * 64, 280, 60, 40)));
            }

            HitBox = new Rectangle((int)Position.X, (int)Position.Y + 5, 95, 75);
            currentAnimation = new Animation();
            currentAnimation = movableAnimations.Run;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(monsterTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(), 2, SpriteEffects, 0f);

        }

        public void Update(GameTime gameTime)
        {
          
            if (Speed.X < 0)
                SpriteEffects = SpriteEffects.FlipHorizontally;
            else
                SpriteEffects = SpriteEffects.None;
            if (HitBox.X >= (800 - 90) || HitBox.X <= 599)
            {
                Speed *= new Vector2(-1, 1);
            }
            Position += Speed;
         
            if (currentAnimation == movableAnimations.Dead)
                HitBox = new Rectangle(HitBox.X, HitBox.Y + 2, HitBox.Width, HitBox.Height);
            else
                HitBox = new Rectangle((int)Position.X, (int)Position.Y + 5, 95, 75);

            if (currentAnimation.CurrentFrame == movableAnimations.Dead.frames.Last())
            {
                currentAnimation = new Animation();
                currentAnimation.AddFrame(movableAnimations.Dead.frames.Last());
                HitBox = new Rectangle(0, 0, 0, 0);
            }
            currentAnimation.Update(gameTime);

        }
    }
}
