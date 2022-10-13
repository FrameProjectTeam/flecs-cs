using JetBrains.Annotations;
using static flecs_hub.flecs;

namespace Flecs;

[PublicAPI]
public readonly unsafe struct Query
{
	private readonly World _world;
	internal readonly ecs_query_t* Handle;
	
	public Query(World world, ecs_query_t* query)
	{
		_world = world;
		Handle = query;
	}

	public Iterator Iter()
	{
		ecs_iter_t it = ecs_query_iter(_world.Handle, Handle);
		return new Iterator(_world, &it);
	}
	
	public void Fini()
	{
		ecs_query_fini(Handle);
	}
}