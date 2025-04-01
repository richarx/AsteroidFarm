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
            {
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.value);

                mousePosition.x = Mathf.Clamp(mousePosition.x, -8.75f, 8.75f);
                mousePosition.y = Mathf.Clamp(mousePosition.y, -4.85f, 4.85f);
                
                transform.position = mousePosition;
            }
        }
    }
}
