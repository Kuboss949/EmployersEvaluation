namespace OcenaPracowniczaLys.Models;

public class OperationResult
{
    public string Status { get; set; }
    public string Message { get; set; }

    public bool IsSuccess()
    {
        return Status.Equals("Success", StringComparison.OrdinalIgnoreCase);
    }
}