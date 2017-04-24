using System;
using System.Collections.Generic;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
	public abstract class Shape
	{
		private Color _color;
		private float _x, _y;
		private bool _selected;
		private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type> ();

		public static void RegisterShape (string name, Type t)
		{
			_ShapeClassRegistry [name] = t;
		}

		public static Shape CreateShape (string name)
		{
			return (Shape)Activator.CreateInstance (_ShapeClassRegistry [name]);
		}

		public Shape (Color clr)
		{
			clr = Color.Yellow;
			_color = clr;
		}

		public Color Color {
			get {
				return _color;
			}
			set {
				_color = value;
			}
		}

		public float X {
			get {
				return _x;
			}
			set {
				_x = value;
			}
		}

		public float Y {
			get {
				return _y;
			}
			set {
				_y = value;
			}
		}

		public abstract bool IsAt (Point2D pt);
		public abstract void Draw ();
		public abstract void DrawOutline ();

		public bool Selected {
			get {
				return _selected;
			}
			set {
				_selected = value;
			}
		}

		public virtual void SaveTo (StreamWriter writer)
		{
			writer.WriteLine (GetKey (GetType ()));
			writer.WriteLine (Color.ToArgb ());
			writer.WriteLine (X);
			writer.WriteLine (Y);
		}

		public virtual void LoadFrom (StreamReader reader)
		{
			Color = Color.FromArgb (reader.ReadInteger ());
			X = reader.ReadInteger ();
			Y = reader.ReadInteger ();
		}

		public static string GetKey (Type type)
		{
			Dictionary<string, Type>.KeyCollection keys = _ShapeClassRegistry.Keys;

			foreach (string key in keys) {
				if (type == typeof (Rectangle)) 
				{
					return "Rectangle";
				} else
				if (type == typeof (Circle)) 
				{
					return "Circle";
				} else 
				{
					return "Line";
				}
			}
			return null;
		}
	}
}
	