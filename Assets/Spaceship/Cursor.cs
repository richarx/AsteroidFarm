using UnityEngine;
using UnityEngine.InputSystem;

namespace Spaceship
{
    public class Cursor : MonoBehaviour
    {
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
            //UnityEngine.Cursor.visible = false;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
                MoveCursorToPosition(mainCamera.ScreenToWorldPoint(Mouse.current.position.value));
            else if (Input.touchCount > 0)
                MoveCursorToPosition(Input.GetTouch(0).position);
        }

        private void MoveCursorToPosition(Vector2 position)
        {
            position.x = Mathf.Clamp(position.x, -8.75f, 8.75f);
            position.y = Mathf.Clamp(position.y, -4.85f, 4.85f);
                
            transform.position = position;
        }
    }
}
