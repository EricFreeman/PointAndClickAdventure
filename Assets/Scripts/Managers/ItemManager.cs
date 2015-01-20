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

            Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => type.GetInterface("IItem") != null && !type.IsInterface)
                .Each(item =>
                {
                    var obj = (IItem) Activator.CreateInstance(item);
                    
                    if (!_roomItems.ContainsKey(obj.Room))
                        _roomItems.Add(obj.Room, new List<IItem>());
                    
                    _roomItems[obj.Room].Add(obj);
                });
        }

        public void Handle(EnterRoomMessage message)
        {
            _roomItems[message.RoomName].Each(item =>
            {
                var baseItem =  ((GameObject)Instantiate(BaseItem)).GetComponent<BaseItem>();
                baseItem.Setup(item);
            });
        }
    }
}