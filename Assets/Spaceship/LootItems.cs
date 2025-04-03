using UnityEngine;

namespace Spaceship
{
    public class LootItems : MonoBehaviour
    {
        [SerializeField] private SqueezeAndStretch squeezeAndStretch;
        [SerializeField] private GameObject lootVfx;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Loot"))
            {
                Instantiate(lootVfx, other.transform.position, Quaternion.identity);
                squeezeAndStretch.Trigger();
                Destroy(other.gameObject);
            }
        }
    }
}
