namespace EmployeeManagementAPI.Brokers.DataTimes
{
    sealed class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrentDateTime() =>
            DateTimeOffset.UtcNow;
    }
}