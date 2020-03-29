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
        ParticleSystem particleSystem;
        ParticleSystem particles2;
        Texture2D particleTexture;
        
 
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

            spriteBatch = new SpriteBatch(GraphicsDevice);
            particleTexture = Content.Load<Texture2D>("pixel");

            particleSystem = new ParticleSystem(GraphicsDevice, 1000, particleTexture);
            particleSystem.SpawnPerFrame = 4;

          
            particles2 = new ParticleSystem(GraphicsDevice, 1000, particleTexture);
            particles2.SpawnPerFrame = 4;

            particleSystem.SpawnParticle = (ref Particle particle) =>
            {

                MouseState mouse = Mouse.GetState();
                particle.position = new Vector2(mouse.X, mouse.Y);
                particle.velocity = new Vector2
                (MathHelper.Lerp(-30, 30, (float)random.NextDouble()),
                 MathHelper.Lerp(50,50, (float)random.NextDouble())

                );
                particle.acceleration = 0.1f * new Vector2(100, (float)-random.NextDouble());
                particle.color = Color.Red;
                particle.scale = 1f;
                particle.life = 1.0f;


            };

           
            particles2.SpawnParticle = (ref Particle particle) =>
            {

               
                particle.position = new Vector2(55, 64);
                particle.velocity = new Vector2
                (MathHelper.Lerp(-50, 50, (float)random.NextDouble()),
                 MathHelper.Lerp(0, 100, (float)random.NextDouble())

                );
                particle.acceleration = 0.1f * new Vector2(0, (float)-random.NextDouble());
                particle.color = Color.Gold;
                particle.scale = 1f;
                particle.life = 1.0f;


            };


            particles2.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.velocity += deltaT * particle.acceleration;
                particle.position += deltaT * particle.velocity;
                particle.scale -= deltaT;
                particle.life -= deltaT;
            };

            particleSystem.UpdateParticle = (float deltaT, ref Particle particle) =>
            {
                particle.velocity += deltaT * particle.acceleration;
                particle.position += deltaT * particle.velocity;
                particle.scale -= deltaT;
                particle.life -= deltaT;
            };

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
            particleSystem.Update(gameTime);
            particles2.Update(gameTime);
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
          

            var offset = new Vector2(421, 520) - new Vector2(paddle.bound.X, paddle.bound.Y);
            var t = Matrix.CreateTranslation(offset.X, offset.Y, 0);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, t);

            ground.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            paddle.Draw(spriteBatch);
            spriteBatch.DrawString(spriteFont, "Have Fun Jumping!" ,new Vector2(0, 50), Color.Black);
            particleSystem.Draw();
            particles2.Draw();


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
 