using System.Collections;
using Asteroid;
using Comet;
using UnityEngine;
using UnityEngine.UI;

namespace Spaceship
{
    public class GameLoop : MonoBehaviour
    {
        [SerializeField] private MoveSpaceship spaceship;
        [SerializeField] private GameObject cursor;
        [SerializeField] private Image blackScreen;
        [SerializeField] private float fadeDuration;

        public static GameLoop instance;

        private AsteroidSpawner asteroidSpawner;
        private CometSpawner cometSpawner;

        private bool isPlayingLoosingAnimation;

        private void Awake()
        {
            instance = this;
            asteroidSpawner = GetComponent<AsteroidSpawner>();
            cometSpawner = GetComponent<CometSpawner>();
        }

        public void LooseGame()
        {
            if (!isPlayingLoosingAnimation)
                StartCoroutine(PlayLoosingAnimation());
        }

        private IEnumerator PlayLoosingAnimation()
        {
            spaceship.SetLockState(true);

            yield return Tools.Fade(blackScreen, fadeDuration, true);

            spaceship.transform.position = Vector2.zero;
            cursor.transform.position = Vector2.zero + (Vector2.right * 0.5f);
            spaceship.SetLookDirection(Vector2.right);
            asteroidSpawner.ResetAsteroids();
            cometSpawner.ResetComets();

            yield return Tools.Fade(blackScreen, fadeDuration * 2.0f, false);

            spaceship.SetLockState(false);
        }
    }
}
