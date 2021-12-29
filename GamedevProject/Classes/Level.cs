using GamedevProject.Blocks;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using GamedevProject.Input;
using SharpDX.Direct2D1.Effects;

namespace GamedevProject.Classes
{
    internal class Level
    {
        private Hero _hero;
        private Monster _monster;
        private List<IGameObject> _objects;
        private readonly int[,] gameboard;
        private Texture2D _heroTexture;
        private MovementManager _movementManager;
        private Texture2D _block;
        private Texture2D heart;
        public Level()
        {

            _objects = new List<IGameObject>();
            _movementManager = new MovementManager();
            gameboard = new[,]
 {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0},
                { 0,0,0,0,0,0,1,2,2,2,2,3,0,0,0,0},
                { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
 };
        }

        public void Start()
        {
            _movementManager.Move(_hero, _objects);
        }

        public void AddObjects(GraphicsDevice graphicsDevice, ContentManager content)
        {
            _block = new Texture2D(graphicsDevice, 1, 1);
            _block.SetData(new[] { Color.White });
            _heroTexture = content.Load<Texture2D>("Santa - Sprite Sheet");
            _hero = new Hero(_heroTexture, new KeyboardReader(), new Vector2(200, 100));
            heart = content.Load<Texture2D>("lives");
            _monster = new Monster(content);
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if (i == 8 && j == 6)
                        Console.WriteLine();
                    _objects.Add(BlockFactory.CreateBlock((SoortBlok)gameboard[i, j], j * 50, i * 50 - 20, graphicsDevice, content));
                }
            }
            _objects.Add(_monster);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _hero.Draw(spriteBatch);
            spriteBatch.Draw(_block, _hero.HitBox, Color.Red * 0.2f);
            for (var i = 0; i < _hero.Lives; i++)
            {
                spriteBatch.Draw(heart, new Vector2(i * 50, 0), Color.White);
            }
            foreach (var obj in _objects.Where(x => x != null).ToList())
            {
                obj.Draw(spriteBatch);
                if (obj is Monster)
                    spriteBatch.Draw(_block, _monster.HitBox, Color.Red * 0.2f);
            }
        }

        public void Update(GameTime gameTime)
        {
            _monster.Update(gameTime);
            _hero.Update(gameTime);
        }
    }
}
