using System;
using System.Collections.Generic;
using System.Text;

namespace GamedevProject.Interfaces
{
    interface IJumpable
    {
        bool HasJumped { get; set; }
        float HeightDestination { get; set; }
        int Landing { get; set; }
        int JumpHeight { get; set; }
    }
}
