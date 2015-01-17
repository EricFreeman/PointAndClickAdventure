using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Messages;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Managers
{
    public class ItemManager : MonoBehaviour,
        IListener<EnterRoomMessage>
    {
        public GameObject BaseItem;

        private Dictionary<string, List<IItem>> _roomItems;

        void Start()
        {
            _roomItems = new Dictionary<string, List<IItem>>();

            var itemInterface = typeof(IItem);
            var itemList = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetInterface("IItem") != null && !type.IsInterface);

            foreach (var item in itemList)
            {
                var obj = (IItem)Activator.CreateInstance(item);
                var gameObject = ((GameObject)Instantiate(BaseItem)).GetComponent<BaseItem>();
                gameObject.GetComponent<BaseItem>()
//                if (!_roomItems.ContainsKey(item.Room))
//                    _roomItems.Add(item.Room, new List<IItem>());
//
//                _roomItems[item.Room].Add(item);
            }

            Debug.Log(_roomItems.Count);
        }

        public void Handle(EnterRoomMessage message)
        {
            
        }
    }
}