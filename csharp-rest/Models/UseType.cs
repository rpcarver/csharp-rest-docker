using System;

/// <summary>
/// Implementation of UseType, Unique by Id
/// </summary>
namespace bos.Models
{

    public class UseType
    {
        public UseType()
        {
        }

        public UseType(int useTypeId, string name, string description)
        {
            UseTypeId = useTypeId;
            Name = name;
            Description = description;
        }

        public int UseTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            var type = obj as UseType;
            return type != null &&
                   UseTypeId == type.UseTypeId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UseTypeId);
        }
    }
}