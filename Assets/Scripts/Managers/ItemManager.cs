using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Items;
using Assets.Scripts.Messages;
using Assets.Scripts.Util;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Managers
{
    public class ItemManager : MonoBehaviour,
        IListener<EnterRoomMessage>,
        IListener<TakeItemMessage>
    {
        public GameObject BaseItem;

        private Dictionary<string, List<IItem>> _roomItems;

        private List<IItem> _inventory;

        void Start()
        {
            _roomItems = new Dictionary<string, List<IItem>>();
            _inventory = new List<IItem>();

            Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetInterface("IItem") != null && !type.IsInterface)
                .Each(item =>
                {
                    var obj = (IItem)Activator.CreateInstance(item);

                    if (!_roomItems.ContainsKey(obj.Room))
                        _roomItems.Add(obj.Room, new List<IItem>());

                    _roomItems[obj.Room].Add(obj);
                });

            this.Register<EnterRoomMessage>();
            this.Register<TakeItemMessage>();
        }

        void OnDestroy()
        {
            this.UnRegister<EnterRoomMessage>();
            this.UnRegister<TakeItemMessage>();
        }

        public void Handle(EnterRoomMessage message)
        {
            // clear existing items from old room
            var itemParent = GameObject.Find("Items");
            itemParent.GetComponentsInChildren<Transform>().Each(x =>
            {
                if (x != itemParent.transform)
                    Destroy(x.gameObject);
            });

            // add items from entered room
            if (!_roomItems.ContainsKey(message.RoomName)) return;

            _roomItems[message.RoomName].Each(item =>
            {
                if (_inventory.ContainsType(item)) return;
                var baseItem = Instantiate(BaseItem).GetComponent<BaseItem>();
                baseItem.Setup(item);
                baseItem.transform.SetParent(itemParent.transform);
            });
        }

        public void Handle(TakeItemMessage message)
        {
            _inventory.Add(message.Item);
        }
    }
}