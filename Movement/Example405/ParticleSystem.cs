using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

namespace Movement
{
	class ParticleSystem : Node
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		private Vector2 velocity;
		private Vector2 acceleration;

		// Fields

		private bool StopAdd = false;
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
			Particles(deltaTime);
		}

		void Particles(float deltaTime) 
		{
			//Random number.
			Random rand = new Random();

			//put particle in a for loop so it can go slower.
			for (int i = 0; i < deltaTime + 1; i++)
			{
				//Random X and Y
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				Vector2 pos = new Vector2(randX, randY) * 200;
				pos -= new Vector2(100, 100);
				// Create how a particle works
				Particle p = new Particle(pos.X, pos.Y, colors[rand.Next()%colors.Count]);
				// No need for this --> p.Rotation = (float)(Math.Atan2(pos.Y, pos.X));
				
				//List adds item. And thus the list count goes up.
				particles.Add(p);
				AddChild(p);

				//Particle Velocity is position.
				p.Velocity = pos;

				// Checking particle count.
				Console.WriteLine("Particles: " + particles.Count);
				Console.WriteLine("Children Particles: " + Children.Count);

				//If particle count is at 100 clear the list and continue.
				// if (particles.Count >= 100)
				// {	
				// 	particles.Clear();
				// }
				// if (Children.Count >= 100)
				// {
				// 	StopAdd = true;
				// 	RemoveChild(p);
				// 	//Node LastItem = Children[Children.Count - 1];
				// 	Children.Insert(0, Children[Children.Count - 1]);
				// }

				if (particles.Count >= 100)
				{
					Particle pp = particles[particles.Count - 1];
					particles.RemoveAt(particles.Count - 1);
					particles.Insert(0, pp);
				}
			}
		}
	}
}
