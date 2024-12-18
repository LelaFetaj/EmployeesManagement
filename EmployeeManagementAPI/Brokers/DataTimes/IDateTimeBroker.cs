namespace EmployeeManagementAPI.Brokers.DataTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrentDateTime();
    }
}