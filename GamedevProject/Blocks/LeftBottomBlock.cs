using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Blocks
{
    //SRP
    class LeftBottomBlock : Block
    {
        public LeftBottomBlock(int x, int y, GraphicsDevice graphics, ContentManager content) : base(x, y, graphics)
        {
            BoundingBox = BoundingBox;
            Passable = false;
            Color = Color.White;
            Texture = content.Load<Texture2D>(@"TilesGround\1");
        }
    }
}
