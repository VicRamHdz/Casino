using System;
namespace Cheeteye.Models
{
    public class LanguageModel : BaseModel
    {
        public string Id
        {
            get;
            set;
        }

        public string Language
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var target = obj as LanguageModel;
            if (target == null)
                return false;

            return this.Id == target.Id;
        }
    }
}
