using CountPad.Domain.States;

namespace CountPad.Domain.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public Status Status { get; set; }
    }
}
