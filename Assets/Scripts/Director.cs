using Assets.Scripts.Interfaces;
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
                    var t = (IClickable)hitCollider.GetComponent(typeof(IClickable));
                    t.Click();
                }
            }
        }
    }
}