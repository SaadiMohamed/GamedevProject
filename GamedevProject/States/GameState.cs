using GamedevProject.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GamedevProject.States
{
    public class GameState : State
    {
        private Level1 level1;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            level1 = new Level1();
            level1.AddObjects(graphicsDevice, content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!level1.Hero.NextLevel)
            {
                level1.Draw(spriteBatch);
                level1.Start();
            }

        }


        public override void Update(GameTime gameTime)
        {
            if (!level1.Hero.NextLevel)
                level1.Update(gameTime);
        }
    }
}
