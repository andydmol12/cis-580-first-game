using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MonoGameWindowsStarter
{
    public struct BoundingRectangle
    {

        public float X;
        public float Y;
        public float Width;
        public float Height;

        public BoundingRectangle(float X, float Y, float Width, float Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
      
        }

        public bool CollidesWith(BoundingRectangle other)
        {

            return !(this.X > other.X + other.Width || this.X + this.Width < other.X || this.Y > other.Y + other.Height || this.Y + this.Width < other.Y);
        }

    }

   
}
