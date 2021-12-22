using GamedevProject.Blocks;
using GamedevProject.Classes;
using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GamedevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;
        private Hero hero;
        private Texture2D blockTexture;
        private Texture2D _backgroundTexture;
        private List<Block> blocks; 
        int[,] gameboard;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            hero = new Hero(_heroTexture, new KeyboardReader(), new Vector2(200,360));
            blocks = new List<Block>();
            gameboard = new int[,]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,1,2,2,2,3,0,0,0,0},
                { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
            };

            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    blocks.Add(BlockFactory.CreateBlock((SoortBlok)gameboard[i,j],j*50,i*50 -20, GraphicsDevice, this.Content));
                }

            }
        }
        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _heroTexture = Content.Load<Texture2D>("Santa - Sprite Sheet");
            blockTexture = new Texture2D(GraphicsDevice, 1,1);
            _backgroundTexture = Content.Load<Texture2D>("BG");
            blockTexture.SetData(new[] {Color.White});
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //TODO: Add your update logic here
            hero.Update(gameTime);
            base.Update(gameTime);           
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            _spriteBatch.Draw(_backgroundTexture, new Vector2(0, 0), Color.White);
            hero.Draw(_spriteBatch);
            foreach (Block blok in blocks)
            {
                if (blok != null)
                {
                    blok.Draw(_spriteBatch);
                }
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
