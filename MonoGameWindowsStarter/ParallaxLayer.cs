﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MonoGameWindowsStarter
{
    public class ParallaxLayer : DrawableGameComponent
    {

        private SpriteBatch spriteBatch;

        public List<ISprite> Sprites = new List<ISprite>();


        /// <summary>
        /// The controller for this scroll layer
        /// </summary>
        public IScrollController ScrollController { get; set; } = new AutoScrollController();


        public ParallaxLayer(Game game) : base(game)
        {

            spriteBatch = new SpriteBatch(game.GraphicsDevice);

        }

        /// <summary>
        /// Draws the Parallax layer
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, ScrollController.Transform);
            foreach (var sprite in Sprites)
            {
                sprite.Draw(spriteBatch, gameTime);
            }
            spriteBatch.End();
        }

        /// <summary>
        /// Updates the ParallaxLayer
        /// </summary>
        /// <param name="gameTime">the GameTime object</param>
        public override void Update(GameTime gameTime)
        {
            ScrollController.Update(gameTime);
        }

    }
}
