using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class Ball
    {

        Game1 game;

        Texture2D texture;


        public BoundingCircle bound;

        public Vector2 Velocity;

        public Ball(Game1 game)
        {

            this.game = game;

        }


        public void Initialize()
        {

            bound.Radius = 25;

            bound.X = game.GraphicsDevice.Viewport.Width / 2;
            bound.Y = game.GraphicsDevice.Viewport.Height / 2;

            Velocity = new Vector2
                (
                (float)game.random.NextDouble(),
                (float)game.random.NextDouble()
                );

           
            Velocity.Normalize();


        }

        public void LoadContent(ContentManager content)
        {

            texture = content.Load<Texture2D>("ballThing");

        }

        public void Update(GameTime gameTime)
        {

            var viewport = game.GraphicsDevice.Viewport;

            bound.Center += 0.5f * (float)gameTime.ElapsedGameTime.TotalMilliseconds * Velocity;



            if (bound.Center.Y < bound.Radius)
            {
                Velocity.Y *= -1;
                float delta = bound.Radius - bound.Y;
                bound.Y += 2 * delta;

            }

            if (bound.Center.Y > viewport.Height - bound.Radius)
            {

                Velocity.Y *= -1;
                float delta = viewport.Height - bound.Radius - bound.Y;
                bound.Y += 2 * delta;

            }

            if (bound.X < 0)
            {
                Velocity.X *= -1;
                float delta = bound.Radius - bound.X;
                bound.X += 2 * delta;
                
            }

            if (bound.X > viewport.Width - bound.Radius)
            {

                Velocity.X *= -1;
                float delta = viewport.Width - bound.Radius - bound.X;
                bound.X += 2 * delta;

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bound, Color.White);
        }


    }
}
