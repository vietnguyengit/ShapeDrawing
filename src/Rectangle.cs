using System;
using SwinGameSDK;
using System.IO;

namespace MyGame
{
	public class Rectangle : Shape
	{

		private int _width, _height;

		public Rectangle () : this (Color.Green, 0, 0, 100, 100)
		{
		}

		public Rectangle (Color color, float x, float y, int width, int height) : base(color)
		{
			Color = color;
			X = x;
			Y = y;
			Width = width;
			Height = height;
		}

		public int Width {
			get {
				return _width;
			}
			set {
				_width = value;
			}
		}

		public int Height {
			get {
				return _height;
			}
			set {
				_height = value;
			}
		}

		public override void Draw ()
		{
			if (Selected) {
				DrawOutline ();
			}
			SwinGame.FillRectangle (Color, X, Y, Width, Height);
		}

		public override void DrawOutline ()
		{
			SwinGame.DrawRectangle (Color.Black, (X - 2), (Y - 2), (Width + 4), (Height + 4));
		}

		public override bool IsAt (Point2D pt)
		{
			return SwinGame.PointInRect (pt, X, Y, _width, _height);
		}

		public override void SaveTo (StreamWriter writer)
		{
			writer.WriteLine ("Rectangle");
			base.SaveTo(writer);
			writer.WriteLine (Width);
			writer.WriteLine (Height);
		}

		public override void LoadFrom (StreamReader reader)
		{
			base.LoadFrom (reader);
			Width = reader.ReadInteger();
			Height = reader.ReadInteger();
		}
	}
}
