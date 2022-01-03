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
        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Sleigh(ContentManager content , Rectangle position)
        {
            texture = content.Load<Texture2D>("SantaSleigh");
            HitBox = position;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, HitBox, Color.White);
        }
    }
}
