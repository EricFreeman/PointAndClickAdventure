using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IItem
    {
        bool IsInInventory { get; set; }
        Vector3 Position { get; }
        string Room { get; }

        Sprite Sprite { get; }

        void Interact();
        void Inspect();
        void Remove();
        void Combine(IItem otherItem);
    }
}