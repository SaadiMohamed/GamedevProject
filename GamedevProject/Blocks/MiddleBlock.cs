using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Blocks
{

    //SRP
    class MiddleBlock : Block
    {
        public MiddleBlock(int x, int y, GraphicsDevice graphics, ContentManager content) : base(x, y, graphics)
        {
            Texture = content.Load<Texture2D>(@"TilesGround\2");
        }
    }
}
