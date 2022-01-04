using GamedevProject.Blocks;
using GamedevProject.Classes.Enemies;
using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace GamedevProject.Classes.Level
{
    internal class LevelOne : IUpdatable
    {
        private Slayer _monster;
        private List<IGameObject> _gameObjects;
        private readonly int[,] gameboard = new[,]
        {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,1,2,2,2,2,2,3,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,1,2,3,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,1,2,2,3,0,0,0,0,0},
                {0,0, 0,0,0,0,1,2,2,2,2,3,0,0,0,0},
                { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
        };
        private Texture2D heart;
        private List<Present> presents;
        private Sleigh sleigh;

        //DIP
        public LevelOne() { }


        public void AddObjects(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _gameObjects = new List<IGameObject>();
            sleigh = new Sleigh(content, new Rectangle(150, 32, 50, 50));
            heart = content.Load<Texture2D>("lives");
            _monster = new Slayer(content);
            presents = new List<Present> {
                new Present(content, new Vector2(600, 150)),
                new Present(content, new Vector2(300, 50)),
                new Present(content, new Vector2(750, 400))};

            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if (gameboard[i, j] != 0)
                        _gameObjects.Add(BlockFactory.CreateBlock((SoortBlok)gameboard[i, j], j * 50, i * 50 - 20, graphicsDevice, content));
                }
            }
            _gameObjects.Add(_monster);
            _gameObjects.AddRange(presents);
            _gameObjects.Add(sleigh);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Hero.Instance.Draw(spriteBatch);
            for (var i = 0; i < Hero.Instance.Lives; i++)
            {
                spriteBatch.Draw(heart, new Vector2(i * 30, 0), Color.White);
            }
            for (var i = 0; i < Hero.Instance.Presents.Count; i++)
            {
                Hero.Instance.Presents[i].Position = new Vector2(800 - ((i + 1) * 30), 0);
                Hero.Instance.Presents[i].Draw(spriteBatch);
            }
            _gameObjects.ForEach(obj => obj.Draw(spriteBatch));
            MovementManager.Move(_gameObjects);
        }

        public void Update(GameTime gameTime)
        {
            _monster.Update(gameTime);
            Hero.Instance.Update(gameTime);
        }
    }
}
