using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Moggle.Controls;
using MonoGame.Extended;
using MonoGame.Extended.Input.InputListeners;
using System.ComponentModel;
using System;

namespace Robo
{
	[Description("Testing, please remove me")]
	[Obsolete]
	public class LineControl : ClickableControl, Moggle.IDrawable
	{
		protected override Rectangle Bounds => _bounds;

		public LineControl(MouseListener mouse) : base(mouse) { }

		protected override void OnClick(ControlMouseEventArgs e)
		{
			Debug.WriteLine("clicked.");
		}
		void Moggle.IDrawable.Draw(SpriteBatch batch)
		{
			batch.DrawLine(_bounds.Left, _bounds.Top, _bounds.Right, _bounds.Bottom, Color.Green, 10);
			batch.DrawCircle(_bounds.Right, _bounds.Bottom, 200, 100, Color.Blue, 5);
			batch.DrawPoint(_bounds.Center.ToVector2(), Color.White * 1f, 20);
		}

		readonly Rectangle _bounds = new Rectangle(0, 0, 1000, 1000);
	}
}