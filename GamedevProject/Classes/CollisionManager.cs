using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Classes
{
    class CollisionManager
    {
        public bool HasCollide(Rectangle rec1, Rectangle rec2)
        {
           return rec1.Intersects(rec2);
               
        }
    }
}
