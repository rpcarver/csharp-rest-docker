using System;

/// <summary>
/// Implementation of UseType
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
    }
}