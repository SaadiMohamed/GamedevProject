using GamedevProject.Classes;
using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GamedevProject.Classes
{
    class Hero : IGameObject , IMovable, IJumpable
    {
        Texture2D heroTexture;
        
        public Animation currentAnimation { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public bool HasJumped { get ; set; }
        public float HeightDestination { get ; set; }
        public int JumpHeight { get ; set; }

        private MovementManager movementManager;

        public Hero(Texture2D texture, IInputReader inputReader, Vector2 position)
        {
            Animation runAnimation;
            Animation idleAnimation;
            heroTexture = texture;
            this.InputReader = inputReader;
            runAnimation = new Animation();
            idleAnimation = new Animation();
            this.Position = position;
            Speed = new Vector2(4, 4);
            movementManager = new MovementManager();
            HasJumped = false;
            JumpHeight = 64;
            int x_coordinate = 0;
            // loop-animatie
            for (int i = 0; i < 8; i++)
            {
                runAnimation.AddFrame(new AnimationFrame(new Rectangle(x_coordinate, 127, 30, 33)));
                x_coordinate += 96;
            }

            x_coordinate = 0;
            //idle - animatie
            for (int i = 0; i < 5; i++)
            {
                idleAnimation.AddFrame(new AnimationFrame(new Rectangle(x_coordinate, 30, 30, 33)));
                x_coordinate += 96;
            }
            Animations.Idle = idleAnimation;
            Animations.Run = runAnimation;
            currentAnimation = Animations.Idle;

        }

        public void ChangeInput(IInputReader inputReader)
        {
            this.InputReader = inputReader;
        }

        public void Move()
        {
            movementManager.Move(this);
        }

        public void Update(GameTime gameTime)
        {
            Move();
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(heroTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, Color.White,0,new Vector2(),2,SpriteEffects,0f);
        }

    }
}
