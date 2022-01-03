using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    //https://www.youtube.com/watch?v=76Mz7ClJLoE 
    //Deze tutorial gevolgd
    public abstract class Component
    {
        public abstract void Draw(GameTime gametime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gametime);
    }
}
