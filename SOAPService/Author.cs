using System.Runtime.Serialization;

namespace SOPSService;

// this class is not used, it just to show datacontract attributes
[DataContract]
public class Author
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string FirstName { get; set; }
    [DataMember]
    public string LastName { get; set; }
    [DataMember]
    public string Address { get; set; }
}

public static class Constants
{
    public const string SoapServiceUrl = "https://localhost:7180/";
}
