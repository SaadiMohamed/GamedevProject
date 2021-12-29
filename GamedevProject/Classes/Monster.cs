using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GamedevProject.Classes
{
    class Monster : IGameObject, IMovable
    {
        Texture2D monsterTexture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Animation currentAnimation { get; set; }

        public int Status { get; set; }

        public Monster(ContentManager content)
        {
            monsterTexture = content.Load<Texture2D>("Shardsoul Slayer Sprite Sheet"); ;
            Position = new Vector2(600, 315);
            currentAnimation = new Animation();
            Speed = new Vector2(2, 0);
            for (int i = 0; i < 5; i++)
            {
                currentAnimation.AddFrame(new AnimationFrame(new Rectangle(i * 64, 70, 60, 64)));
            }
            Status = 1;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {

            if (Status == 1)
                _spriteBatch.Draw(monsterTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(), 2, SpriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            if (Speed.X < 0)
                SpriteEffects = SpriteEffects.FlipHorizontally;
            else
                SpriteEffects = SpriteEffects.None;
            if (Position.X >= (800 - 90) || Position.X <= 572)
            {
                Speed *= new Vector2(-1, 1);
            }
            Position += Speed;
            currentAnimation.Update(gameTime);
        }
    }
}
