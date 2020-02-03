using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameWindowsStarter
{
    class Collisions
    {

        public BoundingRectangle(float X, float Y, float Width, float Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;

        }

        public bool CollidesWith(this BoundingRectangle a, BoundingRectangle b)
        {

            return !(a.X > b.X + b.Width || 
                a.X + a.Width < b.X ||
                a.Y > b.Y + b.Height || 
                a.Y + a.Width < b.Y);
        }


    }
}
