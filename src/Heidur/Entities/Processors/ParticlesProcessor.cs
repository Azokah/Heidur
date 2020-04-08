using Heidur.Entities.Processors.Models;
using Heidur.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using static Heidur.Constants.Particles;

namespace Heidur.Entities.Processors
{
    public static class ParticlesProcessor
    {
        public static Vector2 EmitterLocation { get; set; }
        public static List<Particle> particles = new List<Particle>();
        public static List<Texture2D> textures;

        public static void NewParticleStreamAt(int ammount, Vector2 position)
        {
            SetPosition(position);
            for (int i = 0; i < ammount; i++)
            {
                particles.Add(GenerateNewParticle());
            }
        }

        public static void NewParticleStreamAt(int ammount, Vector2 position, ParticlesStyle style)
        {
            SetPosition(position);
            for (int i = 0; i < ammount; i++)
            {
                particles.Add(GenerateNewParticle(style));
            }
        }

        public static void Update()
        {           
            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        private static Particle GenerateNewParticle()
        {
            Texture2D texture = textures[RandomNumbersHelper.ReturnRandomNumber(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                                    1f * (float)(RandomNumbersHelper.ReturnRandomDouble() * 2 - 1),
                                    1f * (float)(RandomNumbersHelper.ReturnRandomDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(RandomNumbersHelper.ReturnRandomDouble() * 2 - 1);
            Color color = new Color(
                (float)RandomNumbersHelper.ReturnRandomDouble(),
                (float)RandomNumbersHelper.ReturnRandomDouble(),
                (float)RandomNumbersHelper.ReturnRandomDouble());
            float size = (float)RandomNumbersHelper.ReturnRandomDouble();
            int ttl = 20 + RandomNumbersHelper.ReturnRandomNumber(40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        private static Particle GenerateNewParticle(ParticlesStyle style)
        {
            Texture2D texture = textures[RandomNumbersHelper.ReturnRandomNumber(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                                    1f * (float)(RandomNumbersHelper.ReturnRandomDouble() * 2 - 1),
                                    1f * (float)(RandomNumbersHelper.ReturnRandomDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(RandomNumbersHelper.ReturnRandomDouble() * 2 - 1);
            Color color;
            float size = (float)RandomNumbersHelper.ReturnRandomDouble();
            int ttl = 5 + RandomNumbersHelper.ReturnRandomNumber(20);

            switch (style)
            {
                case ParticlesStyle.ATTACK:
                    color = Color.DarkRed;
                    position += new Vector2(Constants.TILESIZE / 2, Constants.TILESIZE / 2);
                    size = size / 2;
                    break;
                default:
                    color = new Color(
                        (float)RandomNumbersHelper.ReturnRandomDouble(),
                        (float)RandomNumbersHelper.ReturnRandomDouble(),
                        (float)RandomNumbersHelper.ReturnRandomDouble());
                    break;
            }

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }

        public static void LoadContent(Game game1, List<string> particlesPaths)
        {
            List<Texture2D> textures = new List<Texture2D>();

            foreach (var particle in particlesPaths)
            {
                textures.Add(game1.Content.Load<Texture2D>(particle));
            }

            ParticlesProcessor.textures = textures;
        }

		public static void LoadContent(Game game1)
		{
			List<Texture2D> textures = new List<Texture2D>();

			foreach (var particle in DEFAULT_PARTICLES_SPRITES)
			{
				textures.Add(game1.Content.Load<Texture2D>(particle));
			}

			ParticlesProcessor.textures = textures;
		}


		public static void SetPosition(Vector2 position)
        {
            EmitterLocation = position;
        }
    }
}
