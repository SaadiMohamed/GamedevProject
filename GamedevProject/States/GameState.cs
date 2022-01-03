using GamedevProject.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GamedevProject.Classes.Level;
using GamedevProject.Input;

namespace GamedevProject.States
{
    //state pattern

    public class GameState : State
    {
        private LevelOne level1;
        private LevelTwo level2;
        private int activeLevel = 1;
        private Hero hero = Hero.Instance;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            //DIP
            hero.Init(content, new KeyboardReader(), new Vector2(200, 200));
            level1 = new LevelOne();
            level1.AddObjects(graphicsDevice, content);
            level2 = new LevelTwo();
            level2.AddObjects(graphicsDevice, content);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (activeLevel == 1)
                level1.Draw(spriteBatch);
            else
                level2.Draw(spriteBatch); 

        }

        public override void Update(GameTime gameTime)
        {
            if(Hero.Instance.NextLevel && activeLevel == 1)
            {
                activeLevel = 2;
                Hero.Instance.NextLevel = false;
            }
                
            if (activeLevel == 1)
            {
                level1.Update(gameTime);
            }
            else 
            {
                level2.Update(gameTime);
            }

            if ( Hero.Instance.Lives < 1)
            {
                _game.ChangeState(new GameOverState(_game, _graphicsDevice, _content));
            }
            if(Hero.Instance.Presents.Count > 3 && activeLevel == 2)
            {
                if(Hero.Instance.NextLevel)
                    _game.ChangeState(new EndState(_game, _graphicsDevice, _content));
            }
            Hero.Instance.NextLevel = false;    
        }
    }
}
