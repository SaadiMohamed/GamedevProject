using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    internal class Sleigh : IGameObject, ICollide
    {
        Texture2D texture;
        public Rectangle HitBox { get; set; }
        public Sleigh(ContentManager content)
        {
            texture = content.Load<Texture2D>("SantaSleigh");
            HitBox = new Rectangle(150, 32, 50, 50);
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, new Rectangle(150, 32, 50, 50), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            HitBox = new Rectangle(150, 32, 50, 50);
        }
    }
}
