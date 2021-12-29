using GamedevProject.Blocks;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamedevProject.Classes
{
    internal class Level
    {
        Hero hero;
        Monster monster;
        List<IGameObject> objects;
        int[,] gameboard;
        MovementManager movementManager;
        Texture2D block;
        public Level(Hero hero)
        {
            this.hero = hero;
            objects = new List<IGameObject>();
            movementManager = new MovementManager();
            gameboard = new int[,]
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
            movementManager.Move(hero, objects);
        }

        public void AddObjects(GraphicsDevice graphicsDevice, ContentManager content)
        {
            
            monster = new Monster(content);
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if( i == 8 && j == 6)
                        Console.WriteLine();
                    objects.Add(BlockFactory.CreateBlock((SoortBlok)gameboard[i, j], j * 50, i * 50 - 20, graphicsDevice, content));
                }
            }
            objects.Add(monster);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IGameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.Draw(spriteBatch);
                    
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IGameObject obj in objects)
            {
                if (obj is Monster monster)
                {
                    monster.Update(gameTime);
                }
            }
        }
    }
}
