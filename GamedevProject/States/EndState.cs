using GamedevProject.Classes;
using GamedevProject.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.States
{
    //State pattern
    class EndState : State
    {
        private List<Component> _components;
        private SpriteFont Font;

        public EndState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>(@"Controls\Button");
            Font = _content.Load<SpriteFont>(@"Fonts\Font");
            var continueButton = new Button(buttonTexture, Font)
            {
                Position = new Vector2(300, 300),
                Text = "Start Again"
            };

            continueButton.Click += continueButton_Click;

            _components = new List<Component>()
            {
                continueButton
            };
        }


        private void continueButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            foreach (var component in _components)
            {
                spriteBatch.DrawString(Font, "Congratulations, you won !!!!", new Vector2(300, 200), Color.Black);
                component.Draw(gameTime, spriteBatch);
            }
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
