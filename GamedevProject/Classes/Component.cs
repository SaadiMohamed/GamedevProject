using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    //MonoGame Tutorial 013 - Game States (Main Menu). (2017, 18 juli). YouTube. Geraadpleegd op 1 januari 2022, van https://www.youtube.com/watch?v=76Mz7ClJLoE 
    //Deze tutorial gevolgd
    public abstract class Component
    {
        public abstract void Draw(GameTime gametime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gametime);
    }
}
