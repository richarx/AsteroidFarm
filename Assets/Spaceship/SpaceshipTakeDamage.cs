using UnityEngine;

namespace Spaceship
{
    public class SpaceshipTakeDamage : MonoBehaviour
    {
        private SqueezeAndStretch squeezeAndStretch;

        private void Start()
        {
            squeezeAndStretch = GetComponent<SqueezeAndStretch>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Asteroid"))
            {
                squeezeAndStretch.Trigger();
                GameLoop.instance.LooseGame();
            }
        }
    }
}
