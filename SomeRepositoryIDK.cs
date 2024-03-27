using _13._IoC_And_Pragmatic_Programming_Principles.Stuff;
namespace _13._IoC_And_Pragmatic_Programming_Principles
{
    public class SomeServiceIDK
    {

        private readonly IRepository _repository;

        private readonly List<string> _domains = ["aol.com", "hotmail.com", "prodigy.com", "CompuServe.com"];

        private readonly List<string> _companies = ["Microsoft", "Google", "Fog Creek Software", "37Signals"];

        private readonly List<string> _technologies = ["Cobol", "Punch Cards", "Commodore", "VBScript"];

        public SomeServiceIDK(IRepository repository)
        {
            _repository = repository;
        }

        public int? RegisterSpeaker(SpeakerDTO speaker)
        {

            if (string.IsNullOrWhiteSpace(speaker.FirstName))
                throw new ArgumentNullException("First Name is required");

            if (string.IsNullOrWhiteSpace(speaker.LastName))
                throw new ArgumentNullException("Last Name is required");

            if (string.IsNullOrWhiteSpace(speaker.Email))
                throw new ArgumentNullException("Email is required");

            if (speaker.Expirience < 10 ||
                speaker.BlogURL is null ||
                speaker.Certifications.Count <= 3 ||
                !_companies.Contains(speaker?.Employer))
            {
                string emailDomain = speaker.Email.Split('@').Last();

                if (_domains.Contains(emailDomain) ||
                    (speaker.Browser?.Name == WebBrowser.BrowserName.InternetExplorer && speaker.Browser.MajorVersion < 9))
                    throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
            }

            if (speaker.Sessions.Count < 0)
                throw new ArgumentException("Can't register speaker with no sessions to present.");

            foreach (Session session in speaker.Sessions)
            {
                session.Approved = _technologies.All(tech => !session.Title.Contains(tech) && !session.Description.Contains(tech));

/*                foreach (string tech in _technologies)
                {
                    
                    if (session.Title.Contains(tech) || session.Description.Contains(tech))
                    {
                        session.Approved = false;
                        break;
                    }
                    else
                    {
                        session.Approved = true;
                    }
                }*/
            }

            if (speaker.Sessions.All(session => !session.Approved))
                throw new NoSessionsApprovedException("No sessions approved.");

            speaker.RegistrationFee = CalculateRegistrationFee(speaker);

            try
            {
                return _repository.SaveSpeaker(speaker);
            } 
            catch (Exception ex) {
                throw;
            }
        }
        public int CalculateRegistrationFee(SpeakerDTO speaker)
        {
            if (speaker.Expirience <= 1)
                return 500;

            if (speaker.Expirience >= 2 && speaker.Expirience <= 3)
                return 250;

            if (speaker.Expirience >= 4 && speaker.Expirience <= 5)
                return 100;

            if (speaker.Expirience >= 6 && speaker.Expirience <= 9)
                return 50;

            return 0;
        }

        #region Custom Exceptions
        public class SpeakerDoesntMeetRequirementsException : Exception
        {
            public SpeakerDoesntMeetRequirementsException(string message)
                : base(message)
            {
            }

            public SpeakerDoesntMeetRequirementsException(string format, params object[] args)
                : base(string.Format(format, args)) { }
        }

        public class NoSessionsApprovedException : Exception
        {
            public NoSessionsApprovedException(string message)
                : base(message)
            {
            }
        }
        #endregion
    }
}
