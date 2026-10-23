using UnityEngine;

namespace SOLID_Object_Pool_Spawner
{
    // Sets position and rotation of a spawned object (with optional random offsets).
    public class SpawnPlacement
    {
        private readonly Transform positionPoint;
        private readonly bool hasParentObject;
        private readonly Vector3 position;
        private readonly Vector3 randPosFactor;
        private readonly Vector3 rotation;
        private readonly Vector3 randRotFactor;

        public SpawnPlacement(Transform positionPoint, bool hasParentObject, Vector3 position, Vector3 randPosFactor, Vector3 rotation, Vector3 randRotFactor)
        {
            this.positionPoint = positionPoint;
            this.hasParentObject = hasParentObject;
            this.position = position;
            this.randPosFactor = randPosFactor;
            this.rotation = rotation;
            this.randRotFactor = randRotFactor;
        }

        public void Apply(GameObject obj)
        {
            Vector3 randomPos = RandomOffset(randPosFactor);
            Vector3 randomRot = RandomOffset(randRotFactor);

            obj.transform.localRotation = Quaternion.Euler(rotation + randomRot);

            if (positionPoint)
            {
                obj.transform.position = positionPoint.position + randomPos;
            }
            else if (hasParentObject)
            {
                obj.transform.localPosition = position + randomPos;
            }
            else
            {
                obj.transform.position = position + randomPos;
            }
        }

        private static Vector3 RandomOffset(Vector3 factor)
        {
            return new Vector3(Random.Range(-factor.x, factor.x),
                               Random.Range(-factor.y, factor.y),
                               Random.Range(-factor.z, factor.z));
        }
    }
}
