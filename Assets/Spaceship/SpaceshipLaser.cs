using Asteroid;
using UnityEngine;

namespace Spaceship
{
    public class SpaceshipLaser : MonoBehaviour
    {
        [SerializeField] private Transform asteroidHolder;
        [SerializeField] private SpriteRenderer laser;
        [SerializeField] private float maxRange;
        [SerializeField] private int damage;
        [SerializeField] private float timeBetweenDamage;
        
        private AsteroidTakeDamage previousTarget;
        private float targetingTimestamp;
        
        private void Update()
        {
            GameObject closestAsteroid = FindClosestAsteroid();

            if (closestAsteroid != null && (previousTarget == null || closestAsteroid != previousTarget.gameObject))
            {
                previousTarget = closestAsteroid.GetComponent<AsteroidTakeDamage>();
                targetingTimestamp = Time.time;
            }
            else if (closestAsteroid == null)
                previousTarget = null;

            if (previousTarget != null && Time.time - targetingTimestamp >= timeBetweenDamage)
            {
                previousTarget.TakeDamage(damage);
                targetingTimestamp = Time.time;
            }

            if (closestAsteroid != null)
                DisplayLaser(closestAsteroid);
            else
                HideLaser();
        }

        private void DisplayLaser(GameObject closestAsteroid)
        {
            laser.gameObject.SetActive(true);

            Vector2 asteroidPosition = closestAsteroid.transform.position;
            
            RotateLaserTowardsTarget(asteroidPosition);
            
            float distance = (asteroidPosition - laser.transform.parent.position.ToVector2()).magnitude;

            laser.size = new Vector2(distance, laser.size.y);
        }

        private void RotateLaserTowardsTarget(Vector2 targetPosition)
        {
            Vector2 direction = (targetPosition - laser.transform.parent.position.ToVector2()).normalized;
            laser.transform.parent.rotation = direction.ToRotation();
        }

        private void HideLaser()
        {
            laser.gameObject.SetActive(false);
        }

        private GameObject FindClosestAsteroid()
        {
            Vector2 currentPosition = transform.position;
            
            float minDistance = maxRange;
            int index = -1;

            for (int i = 0; i < asteroidHolder.childCount; i++)
            {
                float distance = currentPosition.Distance(asteroidHolder.GetChild(i).position);
                if (distance <= minDistance)
                {
                    minDistance = distance;
                    index = i;
                }
            }

            if (index < 0)
                return null;

            return asteroidHolder.GetChild(index).gameObject;
        }
    }
}
