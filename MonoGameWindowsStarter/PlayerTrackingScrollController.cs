using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace MonoGameWindowsStarter
{
    public class PlayerTrackingScrollController : IScrollController
    {

        Paddle paddle;

        public float ScrollRatio = 1.0f;

        public float Offset = 200;

        /// <summary>
        /// Gets the transformation matrix to use with the layer
        /// </summary>
        public Matrix Transform
        {
            get
            {
                float x = ScrollRatio * (Offset - paddle.bound.X);
                return Matrix.CreateTranslation(x, 0, 0);
            }
        }

        // <summary>
        /// Updates the controller (a no-op in this case)
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime) { }

        /// <summary>
        /// Constructs a new PlayerTrackingScrollController
        /// </summary>
        /// <param name="player">The player to track</param>
        /// <param name="ratio">The scroll ratio for the controlled layer</param>
        public PlayerTrackingScrollController(Paddle paddle, float ratio)
        {
            this.paddle = paddle;
            this.ScrollRatio = ratio;
        }

    }

}
