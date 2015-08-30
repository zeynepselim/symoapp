using Microsoft.Azure.Mobile.Server;

namespace symoapp.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public string Details { get; set; }

        public bool Complete { get; set; }
    }
}