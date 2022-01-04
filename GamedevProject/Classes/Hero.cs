using GamedevProject.Classes;
using GamedevProject.Input;
using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GamedevProject.Classes
{
    // singleton
    class Hero : IGameObject, IMovable, IJumpable, ICollide, IUpdatable
    {

        private static Hero instance;

        public static Hero Instance
        {
            get
            {
                if (instance == null)
                    instance = new Hero();
                return instance;
            }
        }
        Texture2D heroTexture;
        public List<Present> Presents { get; set; }
        private int lives = 3;
        public bool NextLevel { set; get; }
        public int Lives
        {
            get { return lives; }
            set
            {
                if (value > -1 && value < 4)
                    lives = value;
            }
        }

        public Animations movableAnimations { get; set; }
        public bool IsFalling { get; set; }
        public Animation currentAnimation { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Speed { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public bool HasJumped { get; set; }
        public float HeightDeparture { get; set; }
        public int JumpHeight { get; set; }
        public Rectangle HitBox { get; set; }
        public float Landing { get; set; }
        public bool OnLanding { get; set; }

        private Color backgroundColor = Color.White;

        //DIP
        public void Init(ContentManager content, IInputReader inputReader, Vector2 position)
        {
            InputReader = inputReader;
            NextLevel = false;
            Presents = new List<Present>();
            movableAnimations = new Animations();
            OnLanding = false;
            heroTexture = content.Load<Texture2D>("Santa - Sprite Sheet");
            movableAnimations.Run = new Animation();
            movableAnimations.Idle = new Animation();
            Position = position;
            Speed = new Vector2(4, 4);
            HasJumped = false;
            JumpHeight = 112;
            HitBox = new Rectangle((int)position.X + 5, (int)position.Y + 10, 49, 56);
            Landing = 362;
            // loop-animatie
            for (int i = 0; i < 8; i++)
            {
                movableAnimations.Run.AddFrame(new AnimationFrame(new Rectangle(i * 96, 127, 30, 33)));
            }

            //idle - animatie
            for (int i = 0; i < 5; i++)
            {
                movableAnimations.Idle.AddFrame(new AnimationFrame(new Rectangle(i * 96, 30, 30, 33)));
            }
            currentAnimation = movableAnimations.Idle;

        }

        public void ChangeInput(IInputReader inputReader)
        {
            InputReader = inputReader;
        }


        public void Update(GameTime gameTime)
        {
            currentAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(heroTexture, Position, currentAnimation.CurrentFrame.SourceRectangle, backgroundColor, 0, new Vector2(), 2, SpriteEffects, 0f);
        }

    }
}
