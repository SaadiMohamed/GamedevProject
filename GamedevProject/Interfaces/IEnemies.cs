using GamedevProject.Classes;
using GamedevProject.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Interfaces
{
    interface IEnemies : IGameObject, IMovable, ICollide
    {
    }
}
