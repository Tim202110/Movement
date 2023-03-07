using System; // Console
using System.Numerics; // Vector2
using System.Collections.Generic; // List
using Raylib_cs; // Color

/*
In this class, we have the properties:

- Vector2  Position
- float    Rotation
- Vector2  Scale

- Vector2 TextureSize
- Vector2 Pivot
- Color Color

Methods:

- AddChild(Node child)
- RemoveChild(Node child, bool keepAlive = false)
*/

namespace Movement
{
	class Particle : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		public Vector2 force;
		float lifespan;

		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			Position = new Vector2(x, y);
			Scale = new Vector2(0.25f, 0.25f);
			Color = color;

			lifespan = 255;
			MaxSpeed = 500;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			limit();
			AddForce(force);
			WrapEdges();
			lifespan -= 5;
		}

		public bool isDead()
		{
			if (lifespan == 0.0f)
			{
				return true;
			} else {
				return false;
			}
		}
	}
}
