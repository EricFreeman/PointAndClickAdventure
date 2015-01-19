using System;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class BaseItem : MonoBehaviour
    {
        public IItem Item;

        public string ItemScript;

        public void Setup()
        {
            var t = Type.GetType("Assets.Scripts.Items." + ItemScript); 
            Item = Activator.CreateInstance(t) as IItem;
        }
    }
}