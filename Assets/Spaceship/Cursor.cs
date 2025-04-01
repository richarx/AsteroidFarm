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
            
            Debug.Log($"mouse {Mouse.current.displayName}");
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.value);
                transform.position = mousePosition;
            }
        }
    }
}
