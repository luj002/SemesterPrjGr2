public interface IEventRepository
{
    public void ChangeInformation(ProjectEnums.EventChangeType ECT, string changeString);
    public void AddAttendee(Member givenMember);
    public void RemoveAttendee(Member givenMember);
}