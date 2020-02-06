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
    public class Paddle
    {
        Game1 game;
        public BoundingRectangle bound;

        Texture2D texture;
        Vector2 velocity;
        bool jumped;



        public Paddle(Game1 game)
        {

            this.game = game;
               
        }

        public void Initialize()
        {
           
            bound.Width = 200;
            bound.Height = 200;
            bound.X = game.GraphicsDevice.Viewport.Width / 2 - bound.Width / 2;
            bound.Y = game.GraphicsDevice.Viewport.Height;
            

        }

        public void LoadContent(ContentManager content)
        {

            texture = content.Load<Texture2D>("pixel");
            

        }

        public void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();
            bound.Y += velocity.Y;

           

            if (keyboardState.IsKeyDown(Keys.Up) && jumped == false)
            {
              
                bound.Y -= 10f;
                velocity.Y = -5f;
                jumped = true;            

            }

            if (jumped == true)
            {

                float i = 1;
                velocity.Y += 0.15f * i;

            }

            if (bound.Y >= 565)
            {

                jumped = false;

            }
            if(jumped == false)
            {

                velocity.Y = 0f;

            }


          
            if (keyboardState.IsKeyDown(Keys.Down) && jumped == false)
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

            if (bound.X > game.GraphicsDevice.Viewport.Width - (bound.Width))
            {

                bound.X = game.GraphicsDevice.Viewport.Width - (bound.Width);

            }

            if (bound.Y < 0)
            {

                bound.Y = 0;

            }

            if (bound.Y > game.GraphicsDevice.Viewport.Height - bound.Height)
            {

                bound.Y = game.GraphicsDevice.Viewport.Height - bound.Height;

            }         

            

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(texture, bound, Color.White);
            
        }

        

    }
}
