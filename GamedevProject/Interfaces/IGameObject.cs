﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Interfaces
{
    // ISP
    interface IGameObject
    {
        void Draw(SpriteBatch _spriteBatch);
    }
}
