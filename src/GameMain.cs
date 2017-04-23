using System;
using System.IO;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		private enum ShapeKind
		{
			Rectangle, Circle, Line
		}

		public static void Main ()
		{
			ShapeKind kindToAdd = ShapeKind.Circle;

			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			SwinGame.ShowSwinGameSplashScreen ();

			Drawing myDrawing = new Drawing ();
		
			while (false == SwinGame.WindowCloseRequested ()) {
				SwinGame.ProcessEvents ();

				SwinGame.DrawFramerate (0, 0);
				myDrawing.Draw ();
					
				if (SwinGame.MouseClicked (MouseButton.LeftButton)) 
				{
					Shape newShape;

					if (kindToAdd == ShapeKind.Circle) {
						Circle newCircle = new Circle ();
						newCircle.X = SwinGame.MouseX ();
						newCircle.Y = SwinGame.MouseY ();
						newShape = newCircle;
					} else if (kindToAdd == ShapeKind.Rectangle) {
						Rectangle newRect = new Rectangle ();
						newRect.X = SwinGame.MouseX ();
						newRect.Y = SwinGame.MouseY ();
						newShape = newRect;
					} else {
						Line newLine = new Line ();
						newLine.X1 = SwinGame.MouseX ();
						newLine.Y1 = SwinGame.MouseY ();
						newLine.X2 = newLine.X1 + 150;
						newLine.Y2 = newLine.Y1;
						newShape = newLine;
					}
					myDrawing.AddShape (newShape);
				}

				if (SwinGame.KeyTyped (KeyCode.SpaceKey)) {
					myDrawing.Background = SwinGame.RandomRGBColor (alpha: 255);
				}

				if (SwinGame.MouseClicked (MouseButton.RightButton))
				{
					myDrawing.SelectShapesAt (SwinGame.MousePosition());
				}

				if (SwinGame.KeyTyped (KeyCode.DeleteKey) || SwinGame.KeyTyped(KeyCode.BackspaceKey))
				{
					foreach (Shape s in myDrawing.SelectedShapes)
					{
						myDrawing.RemoveShape (s);
					}
				}

				if (SwinGame.KeyTyped (KeyCode.RKey))
				{
					kindToAdd = ShapeKind.Rectangle;
				}

				if (SwinGame.KeyTyped (KeyCode.CKey)) {
					kindToAdd = ShapeKind.Circle;
				}

				if (SwinGame.KeyTyped (KeyCode.LKey)) {
					kindToAdd = ShapeKind.Line;
				}

				if (SwinGame.KeyTyped (KeyCode.SKey))
				{
					string fileLoc = @"/Users/devnguyen/Desktop/TestDrawing.txt";
					myDrawing.Save (fileLoc);
				}

				if (SwinGame.KeyTyped (KeyCode.OKey))
				{
					try {
						string fileLoc = @"/Users/devnguyen/Desktop/TestDrawing.txt";
						myDrawing.Load (fileLoc);
					} catch (Exception e) {
						Console.Error.WriteLine ("Error loading file: {0}", e.Message);
					}
				}

 			SwinGame.RefreshScreen (60);
			}
		}
	}
}