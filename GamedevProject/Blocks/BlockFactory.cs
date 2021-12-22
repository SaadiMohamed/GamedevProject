using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Blocks
{

    enum SoortBlok {
        LeftBottom = 1, MiddleBlock = 2, RightBlock = 3
    }

    class BlockFactory
    {
        public static Block CreateBlock(SoortBlok type, int x, int y, GraphicsDevice graphics, ContentManager content)
        {
            Block newBlock = null;
            if (type == SoortBlok.LeftBottom)
            {
                newBlock = new LeftBottomBlock(x, y, graphics, content);
            }
            else if (type == SoortBlok.MiddleBlock)
            {
                newBlock = new MiddleBlock(x, y, graphics, content);
            }
            else if (type == SoortBlok.RightBlock)
            {
                newBlock = new RightBlock(x, y, graphics, content);
            }

            return newBlock;
        }

    }
}
