using UnityEngine;

namespace Asteroid
{
    public class AsteroidMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private const float areaMaxHorizontal = 8.4f;
        private const float areaMaxVertical = 4.55f;
        
        private Vector2 spawnPosition;
        private Vector2 moveDirection;

        private bool isInPlayArea;
        private bool isSetup;
        
        private void Update()
        {
            if (!isSetup)
                return;

            if (isInPlayArea || HasEnteredPlayArea())
                CheckForBounceOnAreaBorder();

            transform.position += (moveDirection * (moveSpeed * Time.deltaTime)).ToVector3();
        }

        private void CheckForBounceOnAreaBorder()
        {
            Vector2 currentPosition = transform.position;

            if (currentPosition.x >= areaMaxHorizontal && moveDirection.x >= 0)
                moveDirection = Vector2.Reflect(moveDirection, Vector2.left);
            else if (currentPosition.x <= -areaMaxHorizontal && moveDirection.x <= 0)
                moveDirection = Vector2.Reflect(moveDirection, Vector2.right);
            else if (currentPosition.y >= areaMaxVertical && moveDirection.y >= 0)
                moveDirection = Vector2.Reflect(moveDirection, Vector2.down);
            else if (currentPosition.y <= -areaMaxVertical && moveDirection.y <= 0)
                moveDirection = Vector2.Reflect(moveDirection, Vector2.up);
        }

        private bool HasEnteredPlayArea()
        {
            if (spawnPosition.Distance(transform.position) >= 3.5f)
                isInPlayArea = true;
            
            return isInPlayArea;
        }

        public void Setup(Vector2 direction)
        {
            moveDirection = direction;
            spawnPosition = transform.position;
            isSetup = true;
        }
    }
}
