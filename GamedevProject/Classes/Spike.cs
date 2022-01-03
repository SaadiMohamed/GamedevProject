using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    internal class Spike : Enemies
    {
        Texture2D texture;
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Animation currentAnimation { get; set; }
        public Animations movableAnimations { get; set; }
        public Rectangle HitBox { get; set; }
        public Spike(ContentManager content, Vector2 position)
        {
            texture = content.Load<Texture2D>("spikes");
            Position = position;
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, 30, 30);

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, Position, new Rectangle(0,0,30,30), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
