using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
   

namespace MonoGameWindowsStarter
{
    public class Paddle
    {
        Game1 game;
        public BoundingRectangle bound;
        State state;
        Texture2D texture;
        Vector2 velocity;
        bool jumped;
        TimeSpan timer;
        SoundEffect jumpSFX;
        int frame;

        enum State
        {
            East = 3,
            West = 2,
            Idle = 0,

        }
        const int ANIMATION_FRAME_RATE = 124;
        const float PLAYER_SPEED = 100;
        const int FRAME_WIDTH = 200;
        const int FRAME_HEIGHT = 200;




        public Paddle(Game1 game)
        {
            

            this.game = game;
            timer = new TimeSpan(0);
            state = State.Idle;

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

            texture = content.Load<Texture2D>("slimeSheet");
            jumpSFX = content.Load<SoundEffect>("jump");

            

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
                jumpSFX.Play();

            }

            if (jumped == true)
            {

                float i = 1;
                velocity.Y += 0.15f * i;

            }

            if (bound.Y >= 515)
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

            else if (keyboardState.IsKeyDown(Keys.Left))
            {

                bound.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                state = State.West;
            }

            else if (keyboardState.IsKeyDown(Keys.Right))
            {

                bound.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                state = State.East;
            }
            else state = State.Idle;

            if (state != State.Idle) timer += gameTime.ElapsedGameTime;

            while(timer.TotalMilliseconds > ANIMATION_FRAME_RATE)
            {

                frame++;
                timer -= new TimeSpan(0, 0, 0, 0, ANIMATION_FRAME_RATE);
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

            frame %= 2;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var source = new Rectangle(
                frame * FRAME_WIDTH,
                (int)state % 2 * FRAME_HEIGHT,
                FRAME_WIDTH,
                FRAME_HEIGHT);

            spriteBatch.Draw(texture, bound, source, Color.White);
            
        }

        

    }
}
