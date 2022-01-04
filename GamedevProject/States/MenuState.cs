using GamedevProject.Classes;
using GamedevProject.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using GamedevProject.Input;

namespace GamedevProject.States
{
    //state pattern

    //MonoGame Tutorial 013 - Game States (Main Menu). (2017, 18 juli). YouTube. Geraadpleegd op 1 januari 2022, van https://www.youtube.com/watch?v=76Mz7ClJLoE
    //Deze tutorial gevolgd
    public class MenuState : State
    {

        private List<Component> _components;
        private ContentManager content;
        private SpriteFont font;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>(@"Controls\Button");
            font = _content.Load<SpriteFont>(@"Fonts\Font");
            this.content = content;
            var newGameButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(300, 250),
                Text = "Play"
            };

            newGameButton.Click += newGameButton_Click;

            var quitButton = new Button(buttonTexture, font)
            {
                Position = new Vector2(300, 300),
                Text = "Quit"
            };

            quitButton.Click += quitButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                quitButton
            };
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            Hero.Instance.Lives = 3;
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            var arrows = content.Load<Texture2D>("arrows");
            var spacebar = content.Load<Texture2D>("spacebar");
            var title = content.Load<Texture2D>("Save christmas");
            spriteBatch.Draw(arrows, new Rectangle(600, 300, 200, 100), Color.White);
            spriteBatch.Draw(spacebar, new Rectangle(600, 420, 200, 50), Color.White);
            spriteBatch.Draw(title, new Rectangle(180, 30, 400, 200), Color.White);
            spriteBatch.DrawString(font, "Use left arrow and right arrow to move.\nUse Spacebar to jump.\nTry to collect as many presents as possible.\nYou can kill the slayer by jumping on him.", new Vector2(0, 240), Color.Black);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
