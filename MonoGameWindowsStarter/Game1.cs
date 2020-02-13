using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Random random = new Random();
        Ball ball;
        Paddle paddle;
        Ground ground;
        SpriteFont spriteFont;
 
        KeyboardState oldKeyboardState;
        KeyboardState newKeyboardState;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            paddle = new Paddle(this);
            ball = new Ball(this);
            ground = new Ground(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1042;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            ball.Initialize();
            paddle.Initialize();
            ground.Initialize();
           

          

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            ground.LoadContent(Content);

            ball.LoadContent(Content);

            paddle.LoadContent(Content);


            spriteFont = Content.Load<SpriteFont>("defaultFont");


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            newKeyboardState = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (newKeyboardState.IsKeyDown(Keys.Escape))
                Exit();

            paddle.Update(gameTime);
            ball.Update(gameTime);

            // TODO: Add your update logic here

            

            
            if(paddle.bound.CollidesWith(ball.bound))
            {

                ball.Velocity.X *= -1;
                var delta = (paddle.bound.X + paddle.bound.Width) - (ball.bound.X - ball.bound.Radius);
                ball.bound.X += 2 * delta;

            }

            if (paddle.bound.CollidesWith(ground.bound))
            {

                paddle.bound.Y = ground.bound.Y - paddle.bound.Height;

            }

            var size = spriteFont.MeasureString("Have Fun Jumping!");
            oldKeyboardState = newKeyboardState;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>-
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            ground.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            paddle.Draw(spriteBatch);
            spriteBatch.DrawString(spriteFont, "Have Fun Jumping!" ,new Vector2(0, 50), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
 