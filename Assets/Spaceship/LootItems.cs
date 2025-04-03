using UnityEngine;

namespace Spaceship
{
    public class LootItems : MonoBehaviour
    {
        [SerializeField] private SqueezeAndStretch squeezeAndStretch;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Loot"))
            {
                squeezeAndStretch.Trigger();
                Destroy(other.gameObject);
            }
        }
    }
}
