using ice_cdr.Types;

namespace ice_cdr.Query;

public class CallersWithMostCallsQuery
{
    public static List<CallerInfo> Execute(List<CallDetailRecord> callDetailRecords)
    {
        return callDetailRecords
            .GroupBy(cdr => cdr.Caller)
            .OrderByDescending(group => group.Count())
            .Select(group => new CallerInfo(
                group.Key,
                group.Count(),
                group.Sum(cdr => cdr.Duration)
            ))
            .ToList();
    }
}