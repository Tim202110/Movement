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
		//private float maxspeed;

		List<Particle> particles;
		private List<Color> colors;

		// constructor + call base constructor
		public ParticleSystem(float x, float y) : base()
		{

			Position = new Vector2(x, y);
			velocity = new Vector2(0f, 0f);
			acceleration = new Vector2(0f, 0f);

			colors = new List<Color>();
			colors.Add(Color.WHITE);
			colors.Add(Color.ORANGE);
			colors.Add(Color.RED);
			colors.Add(Color.BLUE);
			colors.Add(Color.GREEN);
			colors.Add(Color.BEIGE);
			colors.Add(Color.SKYBLUE);
			colors.Add(Color.YELLOW);

			particles = new List<Particle>();
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Particles(deltaTime);
		}

		void Particles(float deltaTime) 
		{
			Random rand = new Random();
			for (int i = 0; i < deltaTime; i++)
			{
				float randX = (float)rand.NextDouble();
				float randY = (float)rand.NextDouble();
				Vector2 pos = new Vector2(randX, randY) * 200;
				pos -= new Vector2(100, 100);
				Particle p = new Particle(pos.X, pos.Y, colors[rand.Next()%colors.Count]);
				//p.Rotation = (float)(Math.Atan2(pos.Y, pos.X));
				particles.Add(p);
				AddChild(p);

				p.Velocity = pos;

				if (p.isDead() == true)
				{	
					particles.Remove(p);
				}
			}
		}

	}
}
