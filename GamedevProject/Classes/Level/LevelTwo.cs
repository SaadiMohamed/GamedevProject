using GamedevProject.Blocks;
using GamedevProject.Classes.Enemies;
using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes.Level
{
    internal class LevelTwo : IUpdate
    {
        public Hero Hero { set; get; }
        private Hedgehog hedgehog;
        private List<IGameObject> _gameObjects;
        private readonly int[,] gameboard = new[,]
        {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 1,2,2,2,2,2,2,3,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,1,0,0,1,2,2,2,2,2,2,3,0,0},
                { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
        };
        private Texture2D heart;
        private List<Present> presents;

        //DIP
        public LevelTwo(Hero hero)
        {
            Hero = hero;
        }

        public void AddObjects(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _gameObjects = new List<IGameObject>();
            heart = content.Load<Texture2D>("lives");
            hedgehog = new Hedgehog(content);
            presents = new List<Present> {
                new Present(content, new Vector2(300, 100)),
                new Present(content, new Vector2(600, 350)),
                new Present(content, new Vector2(100, 400))
            };

            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if (gameboard[i, j] != 0)
                        _gameObjects.Add(BlockFactory.CreateBlock((SoortBlok)gameboard[i, j], j * 50, i * 50 - 20, graphicsDevice, content));
                }
            }
            _gameObjects.Add(hedgehog);
            _gameObjects.AddRange(presents);
            _gameObjects.Add(new Sleigh(content, new Rectangle(715, 382, 50, 50)));
            _gameObjects.Add(new Spike(content, new Vector2(200, 400)));
            _gameObjects.Add(new Spike(content, new Vector2(230, 400)));
            _gameObjects.Add(new Spike(content, new Vector2(260, 400)));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hero.Draw(spriteBatch);
            for (var i = 0; i < Hero.Lives; i++)
            {
                spriteBatch.Draw(heart, new Vector2(i * 30, 0), Color.White);
            }
            Hero.Presents.ForEach(present => present.Draw(spriteBatch));
            _gameObjects.ForEach(obj => obj.Draw(spriteBatch));
            MovementManager.Move(_gameObjects);

        }
        public void Update(GameTime gameTime)
        {
            hedgehog.Update(gameTime);
            Hero.Update(gameTime);
        }
    }
}
