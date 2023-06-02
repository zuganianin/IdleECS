using Leopotam.Ecs;

public class RuntimeData
{
    public EcsEntity[] businessEntities;
    private int _money;
    public int Money {
        get => _money;
        set {
            _money = value;
        }
    }

    public ref EcsEntity GetEntity(int idx)
    {
        return ref businessEntities[idx];
    }
}
