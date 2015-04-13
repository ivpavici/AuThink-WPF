using System.Collections.Generic;

namespace AuThink.Desktop.Core.Entities
{
    public class Child
    {
        public Child 
        (
            int id,
            string firstname,
            string lastname,
            string profilePictureUrl,

            List<Test> tests
        )
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.ProfilePictureUrl = profilePictureUrl;
            this.Tests = tests;
        }
        public int Id { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string ProfilePictureUrl { get; private set; }

        public List<Test> Tests { get; private set; }
    }
}
