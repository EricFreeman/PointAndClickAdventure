using System;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class BaseItem : MonoBehaviour
    {
        public IItem Item;

        public void Setup(IItem obj)
        {
            Item = obj;
            var t = Type.GetType("Assets.Scripts.Items." + Item.ItemScript);
            Item = Activator.CreateInstance(t) as IItem;

            GetComponent<SpriteRenderer>().sprite = Item.Sprite;
        }
    }
}