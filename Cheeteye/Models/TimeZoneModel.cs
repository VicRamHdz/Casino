using System;
namespace Cheeteye.Models
{
    public class TimeZoneModel : BaseModel
    {
        public string Id { get; set; }
        public string TimeZoneName { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var target = obj as TimeZoneModel;
            if (target == null)
                return false;

            return this.Id == target.Id;
        }
    }
}
