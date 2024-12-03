using ice_cdr.Types;

namespace ice_cdr.Query;

public class TotalDurationToCallerQuery
{
    public static int Execute(List<CallDetailRecord> callDetailRecords, string receiver)
    {
        return callDetailRecords
            .Where(cdr => cdr.Receiver == receiver)
            .Sum(cdr => cdr.Duration);
    }
}