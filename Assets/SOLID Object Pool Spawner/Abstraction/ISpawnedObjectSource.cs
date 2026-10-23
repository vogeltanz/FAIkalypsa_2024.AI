using UnityEngine;

namespace SOLID_Object_Pool_Spawner
{
    // Provides objects to be spawned and takes them back when they are despawned.
    public interface ISpawnedObjectSource
    {
        GameObject Acquire();
        void Release(GameObject obj);
    }
}
