using UnityEngine;

namespace SOLID_Object_Pool_Spawner
{
    public class ObjectPoolSpawner : Spawner
    {
        [Header("Spawn properties")]
        [SerializeField]
        private int count;
        public int Count => count;

        protected override ISpawnedObjectSource CreateObjectSource()
        {
            return new PooledObjectSource(spawnedObject, count);
        }
    }
}
