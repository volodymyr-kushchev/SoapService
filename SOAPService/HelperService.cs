using System.ServiceModel;

namespace SOPSService;

[ServiceContract(Namespace = Constants.SoapServiceUrl)]
public interface IHelperService
{
    [OperationContract]
    string GetBinaryRepresentation(int inputValue);
}

public class HelperService : IHelperService
{
    public string GetBinaryRepresentation(int inputValue)
    {
        Console.WriteLine(inputValue.ToString());
        return IntToBinaryString(inputValue);
    }

    private string IntToBinaryString(int number)
    {
        return Convert.ToString(number, 2);
    }
}
