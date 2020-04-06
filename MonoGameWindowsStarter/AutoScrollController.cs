using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameWindowsStarter
{
    public class AutoScrollController : IScrollController
    {
        float elapsedTime = 0;

        public float Speed = 10f;

        /// <summary>
        /// Gets the current tansformation matrix
        /// </summary>
        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(-elapsedTime * Speed, 0, 0);
            }
        }

        public void Update(GameTime gameTime)
        {

            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

    }
}
