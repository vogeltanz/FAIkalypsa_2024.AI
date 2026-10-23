using System.Collections.Generic;
using SOLID_Object_Pool;
using UnityEngine;

namespace SOLID_Object_Pool_Spawner
{
    // Provides objects from an object pool and returns them to the pool when released.
    public class PooledObjectSource : ISpawnedObjectSource
    {
        private readonly IObjectPool<PooledObjectUnity> objectPool;
        private readonly Dictionary<GameObject, PooledObjectUnity> acquiredObjects = new Dictionary<GameObject, PooledObjectUnity>();

        public PooledObjectSource(IInstantiable<PooledObjectUnity> factory, int count)
        {
            objectPool = new ObjectPool<PooledObjectUnity>(factory, count);
        }

        public GameObject Acquire()
        {
            PooledObjectUnity objPooled = objectPool.GetObject();
            if (objPooled == null)
            {
                return null;
            }

            acquiredObjects[objPooled.Object] = objPooled;
            return objPooled.Object;
        }

        public void Release(GameObject obj)
        {
            if (acquiredObjects.TryGetValue(obj, out PooledObjectUnity objPooled))
            {
                objectPool.ReleaseObject(objPooled);
                acquiredObjects.Remove(obj);
            }
        }
    }
}
