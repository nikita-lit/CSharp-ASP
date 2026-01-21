using Microsoft.AspNetCore.Identity;

namespace School.Models
{
    public class Registration
    {
        public int ID { get; set; }

        public string Staatus { get; set; }

        public int TrainingID { get; set; }
        public virtual Training Training { get; set; }

        public string StudentUserID { get; set; }
        public virtual IdentityUser StudentUser { get; set; }
    }
}
