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

            var itemList = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetInterface("IItem") != null && !type.IsInterface);

            foreach (var item in itemList)
            {
                var obj = (IItem)Activator.CreateInstance(item);
                var baseItem = ((GameObject)Instantiate(BaseItem)).GetComponent<BaseItem>();
                baseItem.Setup(obj);

                if (!_roomItems.ContainsKey(baseItem.Item.Room))
                    _roomItems.Add(baseItem.Item.Room, new List<IItem>());

                _roomItems[baseItem.Item.Room].Add(baseItem.Item);
            }

            Debug.Log(_roomItems.Count);
        }

        public void Handle(EnterRoomMessage message)
        {
            
        }
    }
}