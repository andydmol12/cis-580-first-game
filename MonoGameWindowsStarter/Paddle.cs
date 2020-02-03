using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
   

namespace MonoGameWindowsStarter
{
    class Paddle
    {
        Game1 game;
        BoundingRectangle bound;

        Texture2D texture;
        public Paddle(Game1 game)
        {
            this.game = game;
            
          

        }

        public void LoadContent(ContentManager content)
        {

            texture = content.Load<Texture2D>("pixel");
            bound.Width = 50;
            bound.Height = 200;
            bound.X = 0;
            bound.Y = game.GraphicsDevice.Viewport.Height / 2 - bound.Width / 2;

        }

        public void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();
          

           

            if (keyboardState.IsKeyDown(Keys.Up))
            {

                bound.Y -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {

                bound.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                
            }

            if (bound.Y < 0)
            {

                bound.Y = 0;

            }

            if (bound.Y > GraphicsDevice.Viewport.Height - bound.Height)
            {

                bound.Y = GraphicsDevice.Viewport.Height - bound.Height;

            }

            // TODO: Add your update logic here

      
           


            oldKeyboardState = newKeyboardState;
            base.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, bound, Color.Green);

        }

        public static implicit operator Rectangle(BoundingRectangle br)
        {
            return new Rectangle(
                (int)br.X,
                (int)br.Y,
                (int)br.Height,
                (int)br.Width);

        }

    }
}
