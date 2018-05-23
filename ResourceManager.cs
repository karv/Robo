namespace Robo
{
	public class ResourceManager
	{
		float[] _resources { get; }
		public ResourceManager()
		{
			_resources = new float[typeof(ResourceType).GetEnumNames().Length];
		}
		public float this[ResourceType type]
		{
			get => _resources[(int)type];
			set => _resources[(int)type] = value;;
		}
	}
}