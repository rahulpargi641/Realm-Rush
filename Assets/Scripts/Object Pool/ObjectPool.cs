using System;
using System.Collections.Generic;

public interface IObjectPool<T>
{
    T Get();
    void Release(T obj);
    void Destroy();
}

public class ObjectPool<T> : IObjectPool<T> where T : class
{
    private readonly Stack<T> objects;
    private readonly Func<T> objectGenerator;
    private readonly Action<T> onGet;
    private readonly Action<T> onRelease;
    private readonly Action<T> onDestroyPoolObject;

    public ObjectPool(Func<T> objectGenerator, Action<T> onGet, Action<T> onRelease, Action<T> onDestroyPoolObject, int defaultCapacity = 10, int maxPoolSize = int.MaxValue)
    {
        this.objects = new Stack<T>(defaultCapacity);
        this.objectGenerator = objectGenerator;
        this.onGet = onGet;
        this.onRelease = onRelease;
        this.onDestroyPoolObject = onDestroyPoolObject;

        for (int i = 0; i < defaultCapacity; i++)
        {
            AddObject(objectGenerator());
        }
    }

    private void AddObject(T obj)
    {
        objects.Push(obj);
    }

    public T Get()
    {
        if (objects.Count == 0)
        {
            return null;
        }

        T obj = objects.Pop();
        onGet?.Invoke(obj);
        return obj;
    }

    public void Release(T obj)
    {
        onRelease?.Invoke(obj);
        objects.Push(obj);
    }

    public void Destroy()
    {
        foreach (T obj in objects)
        {
            onDestroyPoolObject?.Invoke(obj);
        }

        objects.Clear();
    }
}
