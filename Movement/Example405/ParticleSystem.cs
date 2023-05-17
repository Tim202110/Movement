using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using System.Timers;
using Raylib_cs; // Color

namespace Movement
{
	class ParticleSystem : Node
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 velocity;
		private Vector2 acceleration;

		Random rand = new Random();

		// Fields
		//int timer = 1;
		private float timer;
		//particle list
		List<Particle> particles;
		private List<Color> colors;

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{
			// Position, Velocity and acceleration since this class doesn't/can't use MoverNode 
			Position = new Vector2(x, y);
			velocity = new Vector2(0f, 0f);
			acceleration = new Vector2(0f, 0f);

			//The different colors it can be.
			colors = new List<Color>();
			colors.Add(Color.WHITE);
			colors.Add(Color.ORANGE);
			colors.Add(Color.RED);
			colors.Add(Color.BLUE);
			colors.Add(Color.GREEN);
			colors.Add(Color.BEIGE);
			colors.Add(Color.SKYBLUE);
			colors.Add(Color.YELLOW);

			//put particle sccript as a new list.
			particles = new List<Particle>();
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			//Put particle creation method into update.
			//Particles(deltaTime);

			timer += deltaTime;

			if (timer >= 0.1f) {
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				Vector2 vel = new Vector2(randX, randY) * 200;
				vel -= new Vector2(100, 100);
				Particle p = new Particle(0, 0, colors[rand.Next()%colors.Count]);
				p.Velocity = vel;
				particles.Add(p);
				p.Rotation = (float)Math.Atan2(vel.Y, vel.X);
				AddChild(p);
				timer = 0.0f;
			}

			if(particles.Count > 10)
			{
				RemoveChild(particles[0]);
				particles.RemoveAt(0);
			}
		}
	}
}
