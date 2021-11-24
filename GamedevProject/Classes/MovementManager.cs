using GamedevProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace GamedevProject.Classes
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            //sprite spiegelen
            

            movable.currentAnimation = direction.X == 0 ? Animations.Idle : Animations.Run;
            if(direction.X == -1)
                movable.SpriteEffects = SpriteEffects.FlipHorizontally;
            else if(direction.X == 1)
                movable.SpriteEffects = SpriteEffects.None;


            var afstand = direction * movable.Speed;
            var toekomstigePositie = movable.Position + afstand;

            if ((toekomstigePositie.X <= (800 - 60) && toekomstigePositie.X > 0) && (toekomstigePositie.Y <= 480 - 66 && toekomstigePositie.Y > 0))
            {
                movable.Position = toekomstigePositie;
            }


        }

    }

}


