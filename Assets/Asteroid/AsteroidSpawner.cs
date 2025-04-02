using UnityEngine;

namespace Asteroid
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] private AsteroidMovement asteroidPrefab;
        [SerializeField] private float timeBetweenSpawn;
        [SerializeField] private int maxAsteroidCount;
        
        private const float horizontalLimit = 5.0f;
        private const float height = 5.75f;
        
        private const float verticalLimit = 2.5f;
        private const float width = 10.0f;

        private float spawnTimestamp;
        
        private void Update()
        {
            if (transform.childCount < maxAsteroidCount && Time.time - spawnTimestamp >= timeBetweenSpawn)
            {
                SpawnAsteroid();
                spawnTimestamp = Time.time;
            }
        }

        public void ResetAsteroids()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        private void SpawnAsteroid()
        {
            if (Tools.RandomBool())
                SpawnVertical();
            else
                SpawnHorizontal();
        }

        private void SpawnHorizontal()
        {
            bool spawnFromTheRight = Tools.RandomBool();

            float spawnX = spawnFromTheRight ? width : -width;
            float spawnY = Random.Range(-verticalLimit, verticalLimit);

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Vector2 direction = Vector2.left.AddRandomAngleToDirection(-45.0f, 45.0f);

            if (!spawnFromTheRight)
                direction *= -1.0f;

            AsteroidMovement newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity, transform);
            newAsteroid.Setup(direction);
        }

        private void SpawnVertical()
        {
            bool spawnFromTheTop = Tools.RandomBool();

            float spawnX = Random.Range(-horizontalLimit, horizontalLimit);
            float spawnY = spawnFromTheTop ? height : -height;

            Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            Vector2 direction = Vector2.down.AddRandomAngleToDirection(-45.0f, 45.0f);

            if (!spawnFromTheTop)
                direction *= -1.0f;

            AsteroidMovement newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity, transform);
            newAsteroid.Setup(direction);
        }
    }
}
