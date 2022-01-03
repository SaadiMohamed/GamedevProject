using GamedevProject.Classes;
using GamedevProject.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace GamedevProject.States
{
    //state pattern
    public class MenuState : State
    {

        private List<Component> _components;
        private ContentManager content;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>(@"Controls\Button");
            var buttonFont = _content.Load<SpriteFont>(@"Fonts\Font");
            this.content = content;
            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "Play"
            };

            newGameButton.Click += newGameButton_Click;

            var quitButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 250),
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
            spriteBatch.Draw(arrows,new Rectangle(600,300,200,100), Color.White);
            spriteBatch.Draw(spacebar, new Rectangle(600, 420, 200,50 ), Color.White);
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
