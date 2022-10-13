using flecs_hub;

using JetBrains.Annotations;

namespace Flecs;

[PublicAPI]
public readonly unsafe struct Filter
{
	private readonly World _world;
	internal readonly flecs.ecs_filter_t* Handle;
	
	public Filter(World world, flecs.ecs_filter_t* filter)
	{
		_world = world;
		Handle = filter;
	}

	public Iterator Iter()
	{
		flecs.ecs_iter_t it = flecs.ecs_filter_iter(_world.Handle, Handle);
		return new Iterator(_world, &it);
	}
	
	public void Fini()
	{
		flecs.ecs_filter_fini(Handle);
	}
}