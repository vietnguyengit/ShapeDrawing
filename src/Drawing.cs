using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.IO; 

namespace MyGame
{
	public class Drawing
	{
		private static List<Shape> _shapes;
		private static Color _background;

		public Color Background {
			get {
				return _background;
			}
			set {
				_background = value;
			}
		}

		public Drawing (Color background)
		{
			_shapes = new List<Shape> ();
			_background = background;
		}

		public Drawing () : this (Color.White)
		{
		}

		public int ShapeCount {
			get {
				return _shapes.Count;
			}
		}

		public void AddShape(Shape s)
		{
			_shapes.Add(s);
		}

		public void Draw ()
		{
			SwinGame.ClearScreen (_background);
			foreach (Shape s in _shapes) {
				s.Draw ();
			}
		}

		public void SelectShapesAt(Point2D pt)
		{
			foreach (Shape s in _shapes)
			{
				if (true == s.IsAt (pt) || s.Selected)
				{
					s.Selected = true;
				}
				else
				{
					s.Selected = false;
				}
			}
		}

		public List<Shape> SelectedShapes
		{
			get { List<Shape> result;
				result = new List<Shape>();
				foreach (Shape s in _shapes)
				{ 
					if (true == s.Selected) 
					{
						result.Add(s);
					}
				}
				return result;
			}
		}

		public void RemoveShape(Shape s)
		{
			_shapes.Remove (s);
		}

		public void Save (string filename)
		{
			StreamWriter writer;

			writer = new StreamWriter (filename);
			try {
				writer.WriteLine (Background.ToArgb ());
				writer.WriteLine (ShapeCount);

				foreach (Shape s in _shapes) {
					s.SaveTo (writer);
				}
			} finally {
				writer.Close ();
			}
		}

		public void Load (string filename)
		{
			int count;
			Shape s;
			string kind;

			StreamReader reader = new StreamReader (filename);
			try {
				Background = Color.FromArgb (reader.ReadInteger ());
				count = reader.ReadInteger ();

				for (int i = 0; i < count; i++) {
					kind = reader.ReadLine ();
					switch (kind) {
					case  "Rectangle":
						s = new Rectangle ();
						break;
					case "Circle":
						s = new Circle ();
						break;
					case "Line":
						s = new Line ();
						break;
					default:
						throw new InvalidDataException ("Unknown shape kind: " + kind);
					}
					s.LoadFrom (reader);
					AddShape (s);
				}
			} finally {
				reader.Close ();
			}
		}
	}
}
