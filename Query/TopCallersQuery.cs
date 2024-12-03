using ice_cdr.Types;

namespace ice_cdr.Query;

public class CallersWithMostCallsQuery
{
    public static List<CallerInfo> Execute(List<CallDetailRecord> callDetailRecords)
    {
        return callDetailRecords
            .GroupBy(cdr => cdr.Caller)
            .OrderByDescending(group => group.Count())
            .Select(group => new CallerInfo
            {
                Number = group.Key,
                CallCount = group.Count(),
                TotalDurationIncoming = group.Sum(cdr => cdr.Duration)
            })
            .ToList();
    }
}
