using Microsoft.Azure.Mobile.Server;

namespace symoapp.DataObjects
{
    public class Person : EntityData
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }
    }
}