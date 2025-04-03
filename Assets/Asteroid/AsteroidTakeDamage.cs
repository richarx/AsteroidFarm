using UnityEngine;

namespace Asteroid
{
    public class AsteroidTakeDamage : MonoBehaviour
    {
        [SerializeField] private int healthPoints;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private GameObject loot;
        [SerializeField] private GameObject explosionPrefab;

        private SqueezeAndStretch squeezeAndStretch;
        
        private int currentHealth;

        private void Start()
        {
            currentHealth = healthPoints;
            squeezeAndStretch = GetComponent<SqueezeAndStretch>();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Max(0, currentHealth);

            if (currentHealth == 0)
            {
                DestroyAsteroid();
                return;
            }
            
            squeezeAndStretch.Trigger();
                
            spriteRenderer.gameObject.SetActive(true);

            float size = Tools.NormalizeValueInRange(currentHealth, 0.0f, healthPoints, 0.0f, 0.875f);

            spriteRenderer.size = new Vector2(spriteRenderer.size.x, size);
        }

        private void DestroyAsteroid()
        {
            Vector2 position = transform.position;
            Instantiate(explosionPrefab, position, Quaternion.identity);
            Instantiate(loot, position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
