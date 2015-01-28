using Assets.Scripts.Interfaces;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts
{
    public class GoToRoom : MonoBehaviour, IClickable
    {
        public string RoomName;

        public void Click()
        {
            var scene = GameObject.Find("Scene");
            var newRoom = (GameObject)(Instantiate(Resources.Load("Prefabs/Rooms/{0}".ToFormat(RoomName))));

            foreach (var t in scene.GetComponentsInChildren<Transform>())
                if (t.gameObject.GetInstanceID() != scene.GetInstanceID())
                    Destroy(t.gameObject);

            newRoom.transform.SetParent(scene.transform, false);
        }
    }
}