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
	class SimpleBall : SpriteNode
	{
		// your private fields here
		float speedx = 400f;
		float speedy = 200f;


		// constructor + call base constructor
		public SimpleBall() : base("resources/bigball.png")
		{
			Position = new Vector2(Settings.ScreenSize.X / 2, Settings.ScreenSize.Y / 4);
			Color = Color.YELLOW;
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
			Position.X += speedx * deltaTime;
			Position.Y += speedy * deltaTime;
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
				Position.X = scr_width - spr_width / 2;
				speedx *= -1;
			}
			if (Position.X < 0 + spr_width / 2)
			{
				Position.X = 0 + spr_width / 2;
				speedx *= -1;
			}
			if (Position.Y > scr_height - spr_height / 2)
			{
				Position.Y = scr_height - spr_height / 2;
				speedy *= -1;
			}
			if (Position.Y < 0 + spr_height / 2)
			{
				Position.Y = 0 + spr_height / 2;
				speedy *= -1;
			}
		}

	}
}
