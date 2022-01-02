using GamedevProject.Blocks;
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
        private Monster _monster;
        private List<IGameObject> _gameObjects;
        private readonly int[,] gameboard;
        private MovementManager _movementManager;
        private Texture2D _block;
        private Texture2D heart;
        private List<Present> presents;
        private Sleigh sleigh;
        private Texture2D _heroTexture;

        public LevelTwo()
        {
            _gameObjects = new List<IGameObject>();
            _movementManager = new MovementManager();
            gameboard = new[,]
 {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
 };
        }

        public void Start()
        {
            _movementManager.Move(Hero, _gameObjects);
        }

        public void AddObjects(GraphicsDevice graphicsDevice, ContentManager content)
        {
            sleigh = new Sleigh(content);
            _block = new Texture2D(graphicsDevice, 1, 1);
            _block.SetData(new[] { Color.White });
            _heroTexture = content.Load<Texture2D>("Santa - Sprite Sheet");
            Hero = new Hero(_heroTexture, new KeyboardReader(), new Vector2(200, 200));
            heart = content.Load<Texture2D>("lives");
            _monster = new Monster(content);
            presents = new List<Present> {
               // presents
            };

            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if (gameboard[i, j] != 0)
                        _gameObjects.Add(BlockFactory.CreateBlock((SoortBlok)gameboard[i, j], j * 50, i * 50 - 20, graphicsDevice, content));
                }
            }
            //_gameObjects.Add(_monster);
            //_gameObjects.AddRange(presents);
            //_gameObjects.Add(sleigh);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hero.Draw(spriteBatch);

            spriteBatch.Draw(_block, Hero.HitBox, Color.Red * 0.2f);
            for (var i = 0; i < Hero.Lives; i++)
            {
                spriteBatch.Draw(heart, new Vector2(i * 30, 0), Color.White);
            }
            for (var i = 0; i < Hero.Presents.Count; i++)
            {
                Hero.Presents[i].Position = new Vector2(800 - ((i + 1) * 30), 0);
                Hero.Presents[i].Draw(spriteBatch);
            }
            _gameObjects.ForEach(obj => obj.Draw(spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            //_monster.Update(gameTime);
            Hero.Update(gameTime);
        }
    }
}
