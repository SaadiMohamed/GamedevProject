using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    internal class Present : IGameObject, ICollide
    {
        Texture2D texture;
        public Vector2 Position { get; set;}
        public Rectangle HitBox { get; set;}
        public Present(ContentManager content, Vector2 position)
        {
            texture = content.Load<Texture2D>("Santa - Sprite Sheet");
            this.Position = position;
            HitBox = new Rectangle((int)Position.X + 5, (int)Position.Y, 25, 30);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, new Vector2(Position.X, Position.Y), new Rectangle(584, 49, 15, 20), Color.White, 0, new Vector2(), 2, SpriteEffects.None, 0f);
        }

        public void Update(GameTime gameTime)
        {
            HitBox = new Rectangle((int)Position.X + 5, (int)Position.Y, 25, 30);
        }
    }
}
