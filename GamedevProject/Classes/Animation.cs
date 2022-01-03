using GamedevProject.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    class Animation : IUpdate
    {
        public AnimationFrame CurrentFrame { get; set; }
        public List<AnimationFrame> frames;
        private int counter;
        private double secondCounter = 0;
        private int fps = 10;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }
        public Animation(int fps)
        {
            frames = new List<AnimationFrame>();
            this.fps = fps;
        }
        public void AddFrame(AnimationFrame frame)
        {
            frames.Add(frame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
            {
                counter = 0;
            }

        }


    }
}
