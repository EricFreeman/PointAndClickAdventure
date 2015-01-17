using System;
using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class BaseItem : MonoBehaviour
    {
        private IItem _interface;

        public string ItemScript;

        void Start()
        {
            var t = Type.GetType("Assets.Scripts.Items." + ItemScript); 
            _interface = Activator.CreateInstance(t) as IItem;
        }
    }
}