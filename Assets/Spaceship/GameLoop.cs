using System.Collections;
using Asteroid;
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

        private bool isPlayingLoosingAnimation;

        private void Awake()
        {
            instance = this;
            asteroidSpawner = GetComponent<AsteroidSpawner>();
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
            cursor.transform.position = Vector2.zero;
            spaceship.SetLookDirection(Vector2.right);
            asteroidSpawner.ResetAsteroids();

            yield return Tools.Fade(blackScreen, fadeDuration * 2.0f, false);

            spaceship.SetLockState(false);
        }
    }
}
