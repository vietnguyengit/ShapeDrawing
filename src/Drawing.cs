using System;
using SwinGameSDK;
using System.Collections.Generic;

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
	}
}
