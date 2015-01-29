using System;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class BaseItem : MonoBehaviour, IClickable
    {
        public IItem Item;

        public void Setup(IItem obj)
        {
            Item = obj;
            var t = Type.GetType("Assets.Scripts.Items." + Item.ItemScript);
            Item = Activator.CreateInstance(t) as IItem;

            GetComponent<SpriteRenderer>().sprite = Item.Sprite;
            transform.position = Item.Position;
            GetComponent<SpriteRenderer>().sortingOrder = Item.OrderLayer;
        }

        public void Click()
        {
            if (Input.GetMouseButtonDown(0))
                Item.Interact();
            else if (Input.GetMouseButtonDown(1))
                Item.Inspect();
        }
    }
}