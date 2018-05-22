using System;
using CE;
using Microsoft.Xna.Framework;

namespace Robo
{
	public class ObjectDisplacer
	{
		public Game Game { get; }
		CollisionChecker _collitionChecker => Game.CollitionChecker;
		public ObjectDisplacer(Game game)
		{
			Game = game ?? throw new ArgumentNullException(nameof(game));
		}


		public void Displace(IGameEntity entity, Vector2 vector, bool continuous = false)
		{
			// TODO: do checks
			entity.Position.Offset(vector);
			//entity.Position = new RectangleF(new PointF(entity.Position.Left + vector.X, entity.Position.Top + vector.Y), entity.Position..Size);
		}
	}
}
