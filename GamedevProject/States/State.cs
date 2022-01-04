using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.States
{
    // State pattern

    //MonoGame Tutorial 013 - Game States (Main Menu). (2017, 18 juli). YouTube. Geraadpleegd op 1 januari 2022, van https://www.youtube.com/watch?v=76Mz7ClJLoE
    //Deze tutorial gevolgd
    public abstract class State
    {
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Game1 _game;

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);

        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

    }
}
