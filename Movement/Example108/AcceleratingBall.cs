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
	class AcceleratingBall : SpriteNode
	{
		// your private fields here (add Velocity, Acceleration, and MaxSpeed)
		// Velocity
		Vector2 Velocity;
	     // Acceleration
		Vector2 Acceleration;
		// MaxSpeed
		float MaxSpeed = 1000f;

		// constructor + call base constructor
		public AcceleratingBall() : base("resources/ball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.RED;
			Velocity = new Vector2(0f, 0f);
			Acceleration = new Vector2(-40f, 30f);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			RespEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			
			Velocity += Acceleration * deltaTime;
		     //-                                         - Maxspeed import goes here
			Position += Velocity * deltaTime;
			 /*//---------------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			////ASK HOW TO IMPORT MAXSPEED ON VELOCITY!!!\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
			\\\\-----------------------------------------//////////////////////////////
			 \\\\---------------------------------------////////////////////////////*/

		}

		private void RespEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_height = TextureSize.Y;

			// TODO implement...

			if (Position.X > scr_width)
			{
				Position.X = 0;
			}
			if (Position.X < 0)
			{
				Position.X = scr_width;
			}
			if (Position.Y > scr_height)
			{
				Position.Y = 0;
			}
			if (Position.Y < 0)
			{
				Position.Y = scr_height;
			}

		}

	}
}
