namespace ice_cdr.Types;

// TODO: refactor this to be a class of the restructured data, so that all three queries can be retrieved without using linq three time
// - number
// - numCallsSent
// - numCallsReceived
// - totalDurationSent
// - totalDurationReceived

public class CallerInfo
{
    public string Number { get; set; }
    public int CallCount { get; set; }
    public int TotalDurationIncoming { get; set; }

    public CallerInfo(string number, int callCount, int totalDurationIncoming)
    {
        Number = number;
        CallCount = callCount;
        TotalDurationIncoming = totalDurationIncoming;
    }
}
