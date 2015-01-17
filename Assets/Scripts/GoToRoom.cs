using Assets.Scripts.Messages;
using Assets.Scripts.Util;
using UnityEngine;
using UnityEventAggregator;

namespace Assets.Scripts
{
    public class GoToRoom : MonoBehaviour
    {
        public void Go(string roomName)
        {
            var scene = GameObject.Find("Scene");
            var newRoom = (GameObject)(Instantiate(Resources.Load("prefabs/rooms/{0}".ToFormat(roomName))));

            foreach (var t in scene.GetComponentsInChildren<Transform>())
                if(t.gameObject.GetInstanceID() != scene.GetInstanceID())
                    Destroy(t.gameObject);

            newRoom.transform.SetParent(scene.transform, false);

            EventAggregator.SendMessage(new EnterRoomMessage { RoomName = roomName });
        }
    }
}