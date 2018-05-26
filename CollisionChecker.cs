using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended;

namespace Robo
{
	public class CollisionChecker : IGameComponent, IUpdate
	{
		public Game Game { get; }
		public BattleScreen Screen;
		List<ICollisionRule> _rules { get; } = new List<ICollisionRule>();
		public CollisionChecker(BattleScreen screen)
		{
			Screen = screen ?? throw new ArgumentNullException(nameof(screen));
			Game = (Game)screen.Game;

			// Add rules
			_rules.Add(BeamToRobotCollisionRule.Rule);
		}

		public void RegisterNewRule(ICollisionRule rule) => _rules.Add(rule ?? throw new ArgumentNullException(nameof(rule)));

		/// Determines whether the line between two points is empty and so is safe to "travel".
		public bool IsIntervalEmpty(Vector2 A, Vector2 B)
		{
			throw new NotImplementedException();
		}

		void IGameComponent.Initialize() { }

		bool Collision(ICollisionable objA, ICollisionable objB)
		{
			return RectangleF.Intersects(objA.GetCollisionRectangle(), objB.GetCollisionRectangle()) &&
											 (objA.ExistCollisionWith(objB) || objB.ExistCollisionWith(objA));
		}

		public void Update(GameTime gameTime)
		{
			var entities = Screen.CloneCollisionable();
			for (var i = 0; i < entities.Length; i++)
				for (var j = i + 1; j < entities.Length; j++)
				{
					var ent0 = entities[i];
					var ent1 = entities[j];
					if (Collision(ent0, ent1))
						// Test every rule for this pair
						foreach (var rule in _rules)
						{
							if (rule.AreObjectsValid(ent0, ent1))
								rule.OnCollision(ent0, ent1);
							else if (rule.AreObjectsValid(ent1, ent0))
								rule.OnCollision(ent1, ent0);
						}
				}
		}
	}
}