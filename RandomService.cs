using System;
using MonoGame.Extended;

namespace Robo
{
	public static class RandomService
	{
		public static Random Rnd { get; }

		static RandomService()
		{
			Rnd = new Random();
		}

	}
}