using _13._IoC_And_Pragmatic_Programming_Principles.Stuff;

namespace _13._IoC_And_Pragmatic_Programming_Principles
{
    public class SpeakerDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int Expirience { get; set; }
        public string? BlogURL { get; set; }
        public WebBrowser? Browser { get; set; }
        public List<string> Certifications { get; set; }
        public string? Employer { get; set; }
        public int RegistrationFee { get; set; }
        public List<Session> Sessions { get; set; }

        public SpeakerDTO(
            string? firstName = null,
            string? lastName = null,
            string? email = null,
            int expirience = 0,
            string? blogUrl = null,
            WebBrowser? webBrowser = null,
            List<string>? certifications = null,
            string? employer = null,
            int? registrationFee = null,
            List<Session>? sessions = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Expirience = expirience;
            BlogURL = blogUrl;
            Browser = webBrowser;
            Certifications = certifications ?? [];
            Employer = employer;
            RegistrationFee = registrationFee ?? 0;
            Sessions = sessions ?? [];
        }
    }
}
