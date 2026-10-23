using SOLID_Object_Pool;
using UnityEngine;

namespace SOLID_Object_Pool_Spawner
{
    // Always provides the single object assigned in the factory (no pooling).
    public class DirectObjectSource : ISpawnedObjectSource
    {
        private readonly IComposition<GameObject> spawnedObject;

        public DirectObjectSource(IComposition<GameObject> spawnedObject)
        {
            this.spawnedObject = spawnedObject;
        }

        public GameObject Acquire()
        {
            return spawnedObject.Object;
        }

        public void Release(GameObject obj)
        {
        }
    }
}
