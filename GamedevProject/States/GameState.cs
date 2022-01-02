﻿using GamedevProject.Classes;
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
        private LevelOne level1;
        private LevelTwo level2;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            level1 = new LevelOne();
            level1.AddObjects(graphicsDevice, content);
            level2 = new LevelTwo();
            level2.AddObjects(graphicsDevice, content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!level1.Hero.NextLevel)
            {
                level1.Draw(spriteBatch);
                level1.Start();
            }
            else
                level2.Draw(spriteBatch);

        }


        public override void Update(GameTime gameTime)
        {
            if (!level1.Hero.NextLevel)
                level1.Update(gameTime);
        }
    }
}