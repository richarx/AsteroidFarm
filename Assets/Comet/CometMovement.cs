using UnityEngine;

namespace Comet
{
    public class CometMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        
        private Vector2 moveDirection;
        private bool isSetup;
        
        private void Update()
        {
            if (!isSetup)
                return;

            transform.position += (moveDirection * (moveSpeed * Time.deltaTime)).ToVector3();
        }
        
        public void Setup(Vector2 direction)
        {
            transform.rotation = direction.ToRotation();
            moveDirection = direction;
            isSetup = true;
        }
    }
}
