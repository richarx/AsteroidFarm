using UnityEngine;

namespace Spaceship
{
    public class SpaceshipTakeDamage : MonoBehaviour
    {
        [SerializeField] private SqueezeAndStretch squeezeAndStretch;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Asteroid") || other.CompareTag("Damage"))
            {
                squeezeAndStretch.Trigger();
                GameLoop.instance.LooseGame();
            }
        }
    }
}
