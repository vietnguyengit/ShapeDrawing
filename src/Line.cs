using System;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
	public class Line : Shape
	{

		private float _x1, _y1, _x2, _y2;

		public Line () : this (Color.DarkTurquoise, 50, 100, 200, 100)
		{
		}

		public Line (Color color, float x1, float x2, float y1, float y2) : base (color)
		{
			Color = color;
			X1 = _x1;
			X2 = _x2;
			Y1 = _y1;
			Y2 = _y2;
		}

		public float X1 {
			get {
				return _x1;
			}
			set {
				_x1 = value;
			}
		}

		public float X2 {
			get {
				return _x2;
			}
			set {
				_x2 = value;
			}
		}

		public float Y1 {
			get {
				return _y1;
			}
			set {
				_y1 = value;
			}
		}

		public float Y2 {
			get {
				return _y2;
			}
			set {
				_y2 = value;
			}
		}

		public override void Draw ()
		{
			if (Selected) {
				DrawOutline ();
			}
			SwinGame.DrawLine (Color, X1, Y1, X2, Y2);
		}

	 public override void DrawOutline ()
		{
			SwinGame.DrawCircle (Color.Black, X1, Y1, 6);
			SwinGame.DrawCircle (Color.Black, X2, Y2, 6);
		}

		public override bool IsAt (Point2D pt)
		{
			return SwinGame.PointOnLine (pt, _x1, _y1, _x2, _y2);
		}

		public override void SaveTo (StreamWriter writer)
		{
			writer.WriteLine ("Line");
			base.SaveTo (writer);
			writer.WriteLine (X1);
			writer.WriteLine (X2);
			writer.WriteLine (Y1);
			writer.WriteLine (Y2);
		}

		public override void LoadFrom (StreamReader reader)
		{
			base.LoadFrom (reader);
			X1 = reader.ReadInteger();
			X2 = reader.ReadInteger();
			Y1 = reader.ReadInteger();
			Y2 = reader.ReadInteger();
		}
	}
}