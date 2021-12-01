using GamedevProject.Classes;
using GamedevProject.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Interfaces
{
    interface IMovable
    {
        Vector2 Position { get; set; }
        Vector2 Speed { get; set; }
        IInputReader InputReader { get; set; }
        SpriteEffects SpriteEffects { get; set; }
        Animation currentAnimation { get; set; }


       
    }
}
