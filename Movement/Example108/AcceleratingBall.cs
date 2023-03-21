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
	class AcceleratingBall : MoverNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)

		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.RED;
			Velocity = new Vector2(0f, 0f);
			MaxSpeed = 1000f;
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			WrapEdges();
			Acceleration = new Vector2(-40f, 30f);
			//Velocity = Limit(Velocity, MaxSpeed);
			limit();
			Move(deltaTime);
		    Console.WriteLine(Velocity.Length());
		}
	}
}
