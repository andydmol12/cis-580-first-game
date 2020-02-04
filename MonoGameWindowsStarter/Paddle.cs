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
            bound.Width = 75;
            bound.Height = 75;
            bound.X = game.GraphicsDevice.Viewport.Width / 2 - bound.Width / 2;
            bound.Y = game.GraphicsDevice.Viewport.Height - 100;

        }

        public void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();
          

           

            if (keyboardState.IsKeyDown(Keys.Up))
            {

                bound.Y -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {

                bound.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {

                bound.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {

                bound.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }


            if (bound.X < 0)
            {

                bound.X = 0;

            }

            if (bound.X > game.GraphicsDevice.Viewport.Width - bound.Width)
            {

                bound.X = game.GraphicsDevice.Viewport.Width - bound.Width;

            }

            if (bound.Y < 0)
            {

                bound.Y = 0;

            }

            if (bound.Y > game.GraphicsDevice.Viewport.Height - bound.Height)
            {

                bound.Y = game.GraphicsDevice.Viewport.Height - bound.Height;

            }

            // TODO: Add your update logic here

      
           

            

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(texture, bound, Color.Green);
            
        }

        

    }
}
