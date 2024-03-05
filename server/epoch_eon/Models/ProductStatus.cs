namespace EpochEon.Models
{
    public enum ProductStatus
    {
        [StringValue("DRAFTED")]
        DRAFTED,
        [StringValue("PUBLISHED")]
        PUBLISHED,
        [StringValue("HIDDEN")]
        HIDDEN,
    }

    public class StringValueAttribute : Attribute
    {
        public string Value { get; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }


}
