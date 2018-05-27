using System;
using System.Collections;
using System.Collections.Generic;

namespace Robo
{
	/// Collection of robot components.
	public class RobotComponentColletion : IReadOnlyCollection<IRobotComponent>
	{
		/// Gets the robot associated to this collection.
		public Robot Robot { get; }

		public int Count => _pieces.Count;
		List<IRobotComponent> _pieces { get; }

		/// Initializes a new instance of the
		/// <see cref="RobotComponentColletion"/>
		/// class.
		public RobotComponentColletion(Robot robot)
		{
			Robot = robot;
			_pieces = new List<IRobotComponent>();
		}

		public IEnumerator<IRobotComponent> GetEnumerator()
		{
			return ((IReadOnlyCollection<IRobotComponent>)_pieces).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IReadOnlyCollection<IRobotComponent>)_pieces).GetEnumerator();
		}

		/// Attach the specified component.
		internal void Add(IRobotComponent component)
		{
			_pieces.Add(component);
		}

		/// Detach the specified component.
		internal void Remove(IRobotComponent component)
		{
			if (!_pieces.Remove(component))
				throw new Exception("Consistency error when trying to detach a component.");
		}
	}
}