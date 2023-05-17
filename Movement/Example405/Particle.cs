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

		// constructor + call base constructor
		public Particle(float x, float y, Color color) : base("resources/spaceship.png")
		{
			Position = new Vector2(x, y);
			Scale = new Vector2(0.25f, 0.25f);
			Color = color;

			Velocity = new Vector2(0f, 0f);
			Acceleration = new Vector2(0f, 0f);

		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Fall(deltaTime);
			Move(deltaTime);
		}

		//Add wind and gravity in this function.
		void Fall(float deltaTime)
		{
			Vector2 wind = new Vector2(90f, 0f);
			Vector2 Gravity = new Vector2(0f, 109.81f);

			//add rotation to velocity so the triangle points towards the direction of movement.
			Rotation = Math.Atan2(Velocity.Y, Velocity.X);

			//Adding the wind vector and the gravity vector as forces
			AddForce(wind);
			AddForce(Gravity);
		}
		
	}
}
