namespace Robo
{
	public class RobotResourceManager
	{
		float[] _resources { get; }

		public float this[ResourceType type]
		{
			get => _resources[(int)type];
			set => _resources[(int)type] = value;
		}

		public RobotResourceManager()
		{
			_resources = new float[typeof(ResourceType).GetEnumNames().Length];
		}
	}
}