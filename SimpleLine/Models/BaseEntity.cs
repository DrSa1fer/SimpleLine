using SimpleLineLibrary.Extentions.Strings;

namespace SimpleLineLibrary.Models
{
    internal abstract class BaseEntity
    {
        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        private readonly string _name;
        private readonly string _description;

        public BaseEntity(string name, string desc, bool checkName = true, bool checkDesc = true)
        {
            if (checkName)
            {
                name.ThrowIfWrongTokenName();
            }
            if (checkDesc)
            {
                desc.ThrowIfWrongTextLength();
            }
            

            _name = name;
            _description = desc;
        }
    }
}
