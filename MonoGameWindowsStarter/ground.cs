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
    public class Ground
    {
        Game1 game;
        public BoundingRectangle bound;

        Texture2D texture;
        Vector2 velocity;
        


        public Ground(Game1 game)
        {

            this.game = game;

        }

        public void Initialize()
        {

            bound.Width = game.GraphicsDevice.Viewport.Width;
            bound.Height = 50;
            bound.X = 0;
            bound.Y = game.GraphicsDevice.Viewport.Height - 50;




        }

        public void LoadContent(ContentManager content)
        {

            texture = content.Load<Texture2D>("pixel");


        }

        public void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();
           


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bound, Color.Black);

        }



    }
}
