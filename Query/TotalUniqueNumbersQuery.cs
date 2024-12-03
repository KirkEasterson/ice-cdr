using ice_cdr.Types;

namespace ice_cdr.Query;

public class TotalUniqueNumbersQuery
{
    public static int Execute(List<CallDetailRecord> callDetailRecords)
    {
        return callDetailRecords
            .SelectMany(cdr => new[] { cdr.Caller, cdr.Receiver })
            .Distinct()
            .Count();
    }
}