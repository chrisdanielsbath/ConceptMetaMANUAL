namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Models
{
    public enum BasicDataType
    {
        Binary, 
        Boolean, 
        Integer, 
        Date, 
        Decimal, 
        String, 
        Xml
    }
    public enum ConceptRefType { UniqueContainer, Identifying, Descriptive }
    public enum ConceptType
    {
        DataType, 
        Enumeration, 
        Object, 
        Scalar, 
        UniqueKey, 
        SubType
    }
    public enum ParentOrChildDirection { ToChild, ToParent }
    public enum PropagatingFieldType { BusinessKey, SurrogateKey }
    public enum RelationshipType
    {
        Reference, 
        ParentChild, 
        NestedObject, 
        DescriptiveReference, 
        Subtype, 
        UniqueChild, 
        PassThrough
    }
    public enum SelectorType { Dropdown, Searchable }
}