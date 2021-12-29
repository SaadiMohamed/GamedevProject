using GamedevProject.Classes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.States
{
    public class GameState : State
    {
        private Level level1;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            level1 = new Level();
            level1.AddObjects(graphicsDevice, content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            level1.Draw(spriteBatch);
            level1.Start();
        }


        public override void Update(GameTime gameTime)
        {
            level1.Update(gameTime);
        }
    }
}
