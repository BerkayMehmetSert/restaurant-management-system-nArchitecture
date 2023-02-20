using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.Crews.Constants
{
    public static class CrewMessages
    {
        public const string CrewUsernameAlreadyExists = "Crew username already exists";
        public const string CrewNotFoundById = "Crew not found by id";
        public const string CrewListEmpty = "Crew list is empty";

        public const string CrewNameIsRequired = "Crew name is required";
        public const string CrewNameMinimumLength = "Crew name minimum length is 2";
        public const string CrewContactIsRequired = "Crew contact is required";
        public const string CrewAddressIsRequired = "Crew address is required";
        public const string CrewUsernameIsRequired = "Crew username is required";
        public const string CrewUsernameMinimumLength = "Crew username minimum length is 4";
        public const string CrewPasswordIsRequired = "Crew password is required";
        public const string CrewPasswordMinimumLength = "Crew password minimum length is 4";

    }
}
