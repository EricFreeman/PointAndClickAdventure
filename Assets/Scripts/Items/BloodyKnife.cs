using System;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Messages;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts.Items
{
    public class BloodyKnife : IItem
    {
        public bool IsInInventory { get; set; }

        public Vector3 Position
        {
            get { return new Vector3(3, 3, 0); }
        }

        public string Room
        {
            get { return "Living Room"; }
        }

        public void Interact()
        {
            IsInInventory = true;
        }

        public void Inspect()
        {
            EventAggregator.SendMessage(new DisplayMessageEvent
            {
                Message = "A bloody knife lying in the middle of the room.",
                Location = Position
            });
        }

        public void Remove()
        {
            IsInInventory = false;
        }

        public void Combine(IItem otherItem)
        {
            EventAggregator.SendMessage(new DisplayMessageEvent
            {
                Message = "That doesn't seem to do anything."
            });
        }
    }
}
