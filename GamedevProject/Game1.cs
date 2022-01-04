using GamedevProject.Blocks;
using GamedevProject.Classes;
using GamedevProject.Input;
using GamedevProject.Interfaces;
using GamedevProject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace GamedevProject
{
    //https://www.youtube.com/watch?v=76Mz7ClJLoE 
    //Deze tutorial gevolgd
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D blockTexture;
        private Texture2D _backgroundTexture;
        private State _nextState;
        private State _currentState;
        List<SoundEffect> soundEffects;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            soundEffects = new List<SoundEffect>();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here          
            blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            _backgroundTexture = Content.Load<Texture2D>("BG");
            blockTexture.SetData(new[] { Color.White });
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
            soundEffects.Add(Content.Load<SoundEffect>("ChristmasBackgroundMusic"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            soundEffects[0].Play();
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            //TODO: Add your update logic here

            _currentState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
            _currentState.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
