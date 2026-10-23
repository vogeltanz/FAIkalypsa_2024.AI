using SOLID_Object_Pool;
using UnityEngine;

namespace SOLID_Object_Pool_Spawner
{
    // Integrates Unity with the spawning logic. Composes an object source (where objects come from)
    // and a placement (where and how they are put into the scene).
    public class Spawner : MonoBehaviour
    {
        [Tooltip("Assign a reference which implements ISpawnTriggerable interface (optional).")]
        [SerializeField]
        private GameObject spawnTriggerable;


        [Header("Spawned object")]
        [SerializeField]
        protected PooledObjectFactory spawnedObject;


        [Header("First spawned using external class or system")]
        [SerializeField]
        protected bool spawnedExternallyFirst = false;


        [SerializeField]
        private float spawnChance = 1;
        [SerializeField]
        private Transform positionPoint;
        [SerializeField]
        private Vector3 customPosition;
        [SerializeField]
        private Vector3 randPosFactor;
        [SerializeField]
        private Vector3 rotation;
        [SerializeField]
        private Vector3 randRotFactor;


        private ISpawnedObjectSource objectSource;
        private SpawnPlacement placement;


        protected void Awake()
        {
            Initialize();

            //spawn trigger initialization of the gameobject
            if (spawnTriggerable != null)
            {
                ISpawnTriggerable spawnEventableObj = spawnTriggerable.GetComponent<ISpawnTriggerable>();
                if (spawnEventableObj != null)
                {
                    spawnEventableObj.SpawnTrigger += this.SpawnObject;
                }
            }
        }


        //Create objects before the game starts to make the ready to be reused.
        protected virtual void Initialize()
        {
            objectSource = CreateObjectSource();
            placement = new SpawnPlacement(positionPoint, spawnedObject.ParentObject != null, customPosition, randPosFactor, rotation, randRotFactor);

            //can be used, e.g., for player respawn when the player where inserted to the scene by a designer (i.e. not by a code)
            if (spawnedExternallyFirst == true && spawnedObject != null)
            {
                ConnectDespawnEvent(spawnedObject.Object);
            }
        }

        //Defines where spawned objects come from. Override to provide a different source.
        protected virtual ISpawnedObjectSource CreateObjectSource()
        {
            return new DirectObjectSource(spawnedObject);
        }


        public void SpawnObject()
        {
            if (Random.value > spawnChance)
            {
                return;
            }

            Spawn(objectSource.Acquire());
        }

        public void SpawnObject(GameObject obj)
        {
            if (Random.value > spawnChance)
            {
                return;
            }

            Spawn(obj);
        }

        private void Spawn(GameObject obj)
        {
            if (obj == null)
            {
                Debug.LogWarning("No GameObject was spawned! (Pool with objects is probably empty)");
                return;
            }

            placement.Apply(obj);
            ConnectDespawnEvent(obj);
            Reinitialize(obj);

            //activate game object after reinitialization
            obj.SetActive(true);
        }

        //reinitialization of all game object's scripts (just prior to activation of game object)
        private static void Reinitialize(GameObject obj)
        {
            foreach (var reinitializableObj in obj.GetComponents<IReinitializable>())
            {
                reinitializableObj?.Reinitializate();
            }
        }

        private void ConnectDespawnEvent(GameObject obj)
        {
            IDespawnable<GameObject> despawnableObj = obj.GetComponent<IDespawnable<GameObject>>();
            if (despawnableObj != null)
            {
                despawnableObj.Despawn += this.DeSpawn;
            }
        }


        public void DeSpawn(GameObject obj)
        {
            DeSpawn(obj, false);
        }

        public void DeSpawn(GameObject obj, bool setActive)
        {
            //disconnect method with the despawn event
            IDespawnable<GameObject> despawnableObj = obj.GetComponent<IDespawnable<GameObject>>();
            if (despawnableObj != null)
            {
                despawnableObj.Despawn -= this.DeSpawn;
            }
            obj.SetActive(setActive);
            objectSource.Release(obj);
        }
    }
}
