//todo make good

public class AddRegistrationController
{
    public Event EventToRegister { get; set; }
    public Member Member { get; set; }

    public AddRegistrationController(Event eventToRegister, Member member)
    {
        EventToRegister = eventToRegister;
        Member = member;
    }

    public void Register()
    {
        EventToRegister.Registrations.Add(new Registration(Member, EventToRegister));
    }
}