using Assets.Scripts.Messages;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts
{
    public class Room : MonoBehaviour
    {
        private bool _wasFired;

        void Update()
        {
            if (!_wasFired)
            {
                EventAggregator.SendMessage(new EnterRoomMessage { RoomName = transform.name.Replace("(Clone)", "") });
                _wasFired = true;
            }
        }
    }
}