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
			//timer
			timer += deltaTime;

			//How fast should we go?
			if (timer >= 0.1f) {
				//Random X and Y
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				//Vector2 vel
				Vector2 vel = new Vector2(randX, randY) * 200;
				vel -= new Vector2(100, 100);
				//Create particles exactly where the particlesystem spawned
				Particle p = new Particle(0, 0, colors[rand.Next()%colors.Count]);
				//p.velocity is vel so it wont spawn at random locations but spawns there.
				p.Velocity = vel;
				//Adds particles
				particles.Add(p);
				//Rotates the particle in direction of where it goes.
				p.Rotation = (float)Math.Atan2(vel.Y, vel.X);
				//AddChild to draw the particle
				AddChild(p);
				//Timer returns to 0
				timer = 0.0f;
			}

			//Check how many particles it has counted
			//15 is the best amount in my opinion. You can still see the particles dissapearing.
			//The ones that go up wont dissapear as soon as they pass the origin zone again.

			if(particles.Count > 15)
			{
				//Remove child particle at index 0
				RemoveChild(particles[0]);
				//Remove particle at index 0
				particles.RemoveAt(0);
			}
		}
	}
}
