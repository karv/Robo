using System;
using CE;
namespace Robo
{
	public class CollisionChecker
	{
		public Game Game { get; }
		public CollisionChecker(Game game)
		{
			Game = game ?? throw new ArgumentNullException(nameof(game));
		}

		/// Determines whether the line between two points is empty and so is safe to travel.
		public bool IsIntervalEmpty(PointF A, PointF B)
		{
			throw new NotImplementedException();
		}
	}
}
