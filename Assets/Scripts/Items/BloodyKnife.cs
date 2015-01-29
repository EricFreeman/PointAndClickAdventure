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
            get { return new Vector3(0.82608f, -1.9465f, 0); }
        }

        public int OrderLayer { get { return 1; } }

        public string Room
        {
            get { return "Living Room"; }
        }

        public Sprite Sprite
        {
            get { return Resources.Load<Sprite>("gfx/Bloody Knife"); }
        }
        public string ItemScript { get { return "BloodyKnife"; } }

        public void Interact()
        {
            Debug.Log("Clicked");
            IsInInventory = true;
        }

        public void Inspect()
        {
            Debug.Log("Inspected");
            // TODO: Fix bug in event aggregator where it throws error when nothing listens for event
//            EventAggregator.SendMessage(new DisplayMessageEvent
//            {
//                Message = "A bloody knife lying in the middle of the room.",
//                Location = Position
//            });
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