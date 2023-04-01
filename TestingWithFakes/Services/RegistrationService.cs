using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithFakes.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public RegistrationStatus Register(string email)
        {
            if (AlreadyRegistered(email)) 
                return RegistrationStatus.AlreadyRegistered;
            return RegistrationStatus.Ok;
        }

        public bool AlreadyRegistered(string email)
        {
            return _userRepository.UserExists(email);
        }
    }
}
