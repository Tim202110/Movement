using System;
using System.Numerics; // Vector2
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
	class BouncingBall : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, addForce method)
		// constructor + call base constructor
		public BouncingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 6, Settings.ScreenSize.Y / 4);
			Color = Color.BLUE;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Fall(deltaTime);
			Move(deltaTime);
			BounceEdges();

			Console.WriteLine(Acceleration.Length());
		}

		// your own private methods
		private void Fall(float deltaTime)
		{

			Vector2 Wind= new Vector2(150.0f, 0.0f);
			Vector2 Gravity = new Vector2(0.0f, 981.0f);
			
			AddForce(Wind);
			AddForce(Gravity);
		}

	}
}
