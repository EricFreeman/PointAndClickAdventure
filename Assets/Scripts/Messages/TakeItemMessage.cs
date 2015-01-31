using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Messages
{
    public class TakeItemMessage
    {
        public IItem Item { get; set; }
    }
}