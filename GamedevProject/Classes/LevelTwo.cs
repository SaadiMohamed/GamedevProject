﻿using GamedevProject.Blocks;
using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    internal class LevelTwo
    {
        public Hero Hero { set; get; }
        private Hedgehog hedgehog;
        private List<IGameObject> _gameObjects;
        private readonly int[,] gameboard;
        private MovementManager _movementManager;
        private Texture2D _block;
        private Texture2D heart;
        private List<Present> presents;
        private Sleigh sleigh;

        public LevelTwo(Hero hero)
        {
            _gameObjects = new List<IGameObject>();
            _movementManager = new MovementManager();
            Hero = hero;
            gameboard = new[,]
 {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 1,2,2,2,2,2,2,3,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,1,2,2,2,2,3,0,0},
                { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
 };
        }

        public void AddObjects(GraphicsDevice graphicsDevice, ContentManager content)
        {
            sleigh = new Sleigh(content, new Rectangle(715, 382, 50, 50));
            _block = new Texture2D(graphicsDevice, 1, 1);
            _block.SetData(new[] { Color.White });
            heart = content.Load<Texture2D>("lives");
            hedgehog = new Hedgehog(content);
            presents = new List<Present> {
                new Present(content, new Vector2(300, 100)),
                new Present(content, new Vector2(600, 350)),
                new Present(content, new Vector2(200, 400))
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
            _gameObjects.Add(sleigh);
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
            _movementManager.Move(Hero, _gameObjects);

        }
        public void Update(GameTime gameTime)
        {
            hedgehog.Update(gameTime);
            Hero.Update(gameTime);
        }
    }
}
