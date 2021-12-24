using GamedevProject.Blocks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GamedevProject.Classes
{
    internal class Level
    {
        Hero hero;
        List<Block> blocks;
        int[,] gameboard;
        MovementManager movementManager;
        public Level(Hero hero)
        {
            this.hero = hero;
            blocks = new List<Block>();
            movementManager = new MovementManager();
            gameboard = new int[,]
 {
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,2,2,2,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                { 0,0,0,0,0,0,0,0,1,3,0,0,0,0,0,0},
                { 0,0,0,0,0,0,1,2,2,2,2,3,0,0,0,0},
                { 1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,3},
 };
        }

        public void Start()
        {
            movementManager.Move(hero, blocks);
        }

        public void FillBlocks(GraphicsDevice graphicsDevice, ContentManager content)
        {
            for (int i = 0; i < gameboard.GetLength(0); i++)
            {
                for (int j = 0; j < gameboard.GetLength(1); j++)
                {
                    if( i == 8 && j == 6)
                        Console.WriteLine();
                    blocks.Add(BlockFactory.CreateBlock((SoortBlok)gameboard[i, j], j * 50, i * 50 - 20, graphicsDevice, content));
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block blok in blocks)
            {
                if (blok != null)
                {
                    blok.Draw(spriteBatch);
                }
            }
        }
    }
}
