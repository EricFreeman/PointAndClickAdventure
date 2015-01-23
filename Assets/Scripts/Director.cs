using UnityEngine;

namespace Assets.Scripts
{
    public class Director : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                 var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                 var hitCollider = Physics2D.OverlapPoint(mousePosition);

                if (hitCollider)
                {
                    var t = hitCollider.GetComponent<GoToRoom>();
                    if (t != null)
                        t.Go();
                }
            }
        }
    }
}