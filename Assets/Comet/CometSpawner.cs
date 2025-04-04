using UnityEngine;

namespace Comet
{
    public class CometSpawner : MonoBehaviour
    {
        [SerializeField] private CometMovement cometPrefab;
        [SerializeField] private Transform parentPivot;
        [SerializeField] private float timeBetweenSpawn;
        [SerializeField] private float spawnAngle;
        
        private const float horizontalLimit = 5.0f;
        private const float height = 5.75f;
        
        private const float verticalLimit = 2.5f;
        private const float width = 10.0f;
        
        private float spawnTimestamp;
        
        private void Update()
        {
            if (Time.time - spawnTimestamp >= timeBetweenSpawn)
            {
                SpawnComet();
                spawnTimestamp = Time.time;
            }
        }

        public void ResetComets()
        {
            for (int i = parentPivot.childCount - 1; i >= 0; i--)
            {
                Destroy(parentPivot.GetChild(i).gameObject);
            }
        }

        private void SpawnComet()
        {
            /*
            if (Tools.RandomBool())
                SpawnVertical();
            else
            */
            SpawnHorizontal();
        }

        private void SpawnHorizontal()
        {
            bool spawnFromTheRight = Tools.RandomBool();

            float spawnX = spawnFromTheRight ? width : -width;
            float spawnY = Random.Range(-verticalLimit, verticalLimit);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Vector2 direction = Vector2.left.AddRandomAngleToDirection(-spawnAngle, spawnAngle);

            if (!spawnFromTheRight)
                direction *= -1.0f;

            CometMovement cometMovement = Instantiate(cometPrefab, spawnPosition, Quaternion.identity, parentPivot);
            cometMovement.Setup(direction);
        }

        private void SpawnVertical()
        {
            bool spawnFromTheTop = Tools.RandomBool();

            float spawnX = Random.Range(-horizontalLimit, horizontalLimit);
            float spawnY = spawnFromTheTop ? height : -height;

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Vector2 direction = Vector2.down.AddRandomAngleToDirection(-spawnAngle, spawnAngle);

            if (!spawnFromTheTop)
                direction *= -1.0f;

            CometMovement cometMovement = Instantiate(cometPrefab, spawnPosition, Quaternion.identity, parentPivot);
            cometMovement.Setup(direction);
        }
    }
}
