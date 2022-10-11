using UnityEngine;

namespace ShotMergerClone.Managers
{
    public class InputManager : MonoBehaviour
    {
        public static Vector2 Delta { get; private set; }

        private Vector2 screenRes;

        private Vector2 current;
        private Vector2 previous;

        private void Start()
        {
            screenRes.x = Screen.width;
            screenRes.y = Screen.height;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                previous = current = Input.mousePosition;

            }

            if (Input.GetMouseButton(0))
            {
                previous = current;
                current = Input.mousePosition;

                Delta = (current - previous) / screenRes;
            }

            if (Input.GetMouseButtonUp(0))
                Delta = Vector2.zero;
        }
    }
}


