using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameWindowsStarter
{
    public delegate void ParticleSpawner(ref Particle particle);
    public delegate void ParticleUpdater(float deltaT, ref Particle particle);


    public class ParticleSystem
    {

        private Particle[] particles;
        private Texture2D texture;
        private SpriteBatch spritebatch;
        private Random random = new Random();
        private int nextIndex = 0;

        public Vector2 Emitter { get; set; }

        public int SpawnPerFrame { get; set; }

        public ParticleSystem(GraphicsDevice graphicsDevice, int size, Texture2D texture)
        {
            this.particles = new Particle[size];
            this.spritebatch = new SpriteBatch(graphicsDevice);
            this.texture = texture;

        }

        public void Update(GameTime gametime)
        {

            if (SpawnParticle == null || UpdateParticle == null) return;
            //Part 1
            for (int i = 0; i < SpawnPerFrame; i++)
            {

                SpawnParticle(ref particles[nextIndex]);

                nextIndex++;
                if (nextIndex > particles.Length - 1)
                    nextIndex = 0;

            }

            //Part 2
            float deltaT = (float)gametime.ElapsedGameTime.TotalSeconds;
            for (int i = 0; i < particles.Length; i++)
            {

                if (particles[i].life <= 0) continue;
                //To do 2

                UpdateParticle(deltaT, ref particles[i]);


            }

        }


        public void Draw()
        {
            spritebatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);



            for (int i = 0; i < particles.Length; i++)
            {

                if (particles[i].life <= 0) continue;

                spritebatch.Draw(texture, particles[i].position, null, particles[i].color, 0f, Vector2.Zero, particles[i].scale, SpriteEffects.None, 0);

            }
            //TO do

            spritebatch.End();


        }

        public ParticleSpawner SpawnParticle { get; set; }
        public ParticleUpdater UpdateParticle { get; set; }




    }
}
