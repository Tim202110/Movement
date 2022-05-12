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
	class MovingBall : SpriteNode
	{
		// your private fields here (add Velocity)
		Vector2 Velocity;


		// constructor + call base constructor
		public MovingBall() : base("resources/bigball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.ORANGE;
			Velocity = new Vector2(150f, 75f);
		}

		// Update is called every frame
		public override void Update(float deltaTime)
		{
			Move(deltaTime);
			BounceEdges();
		}

		// your own private methods
		private void Move(float deltaTime)
		{
			// TODO implement
			Position += Velocity * deltaTime;
		}

		private void BounceEdges()
		{
			float scr_width = Settings.ScreenSize.X;
			float scr_height = Settings.ScreenSize.Y;
			float spr_width = TextureSize.X;
			float spr_height = TextureSize.Y;

			// TODO implement...
			if (Position.X > scr_width - spr_width / 2)
			{
				Velocity.X *= -1;
			}
			if (Position.X < 0 + spr_width / 2)
			{
				Velocity.X *= -1;
			}
			if (Position.Y > scr_height - spr_height / 2)
			{
				Velocity.Y *= -1;
			}
			if (Position.Y < 0 + spr_height / 2)
			{
				Velocity.Y *= -1;
			}
		}

	}
}
