using UnityEngine;

namespace Spaceship
{
    public class MoveSpaceship : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform cursor;
        [SerializeField] private Transform rotationPivot;
        [SerializeField] private SpaceshipAnimation spaceshipAnimation;
        
        [Header("Rotation")]
        [SerializeField] private float rotationAcceleration;
        
        [Header("Movement")]
        [SerializeField] private float acceleration; //should be equals to => maxMoveSpeed * 10.0f
        [SerializeField] private float deceleration;
        [SerializeField] private float hyperDeceleration;
        [SerializeField] private float maxMoveSpeed;
        
        [Header("Cursor Ranges")]
        [SerializeField] private float maxRange;
        [SerializeField] private float maxSlowRange;

        private float rotationVelocity;
        private Vector2 moveVelocity;
        
        private void LateUpdate()
        {
            LookTowardsCursor();
            MoveForward();
            spaceshipAnimation.UpdateSpaceshipVisuals(moveVelocity, rotationVelocity);
        }

        private void MoveForward()
        {
            float distanceToCursor = transform.position.ToVector2().Distance(cursor.position);
            
            if (distanceToCursor <= maxSlowRange)
                moveVelocity = Vector2.MoveTowards(moveVelocity, Vector2.zero, hyperDeceleration * Time.deltaTime);
            else if (distanceToCursor <= maxRange)
                moveVelocity = Vector2.MoveTowards(moveVelocity, Vector2.zero, deceleration * Time.deltaTime);
            else
                moveVelocity = Vector2.MoveTowards(moveVelocity, rotationPivot.right * maxMoveSpeed, acceleration * Time.deltaTime);

            transform.position += moveVelocity.ToVector3() * Time.deltaTime;
        }

        private void LookTowardsCursor()
        {
            Vector2 directionToCursor = (cursor.position - rotationPivot.position).normalized;
            Vector2 currentDirection = rotationPivot.right;

            float targetAngle = Mathf.SmoothDampAngle(currentDirection.ToDegree(), directionToCursor.ToDegree(), ref rotationVelocity, rotationAcceleration);

            Vector2 targetDirection = Vector2.right.AddAngleToDirection(targetAngle);

            rotationPivot.rotation = targetDirection.ToRotation();
        }
    }
}
