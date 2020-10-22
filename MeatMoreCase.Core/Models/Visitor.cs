using System.ComponentModel.DataAnnotations;

namespace MeatMoreCase.Core.Models
{
    public class Visitor
    {
        private int _visitorId;
        private string _lastName;
        private string _firstName;
        private VisitType _visitType;
        private string _companyName;
        private string _licensePlate;

        public int VisitorId
        {
            get { return _visitorId; }
            set { _visitorId = value; }
        }

        [Required]
        [Display(Name = "Last name")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [Required]
        [Display(Name = "First name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [Required]
        public VisitType VisitType
        {
            get { return _visitType; }
            set { _visitType = value; }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public string LicensePlate
        {
            get { return _licensePlate; }
            set { _licensePlate = value; }
        }

        public bool HasCompany => !string.IsNullOrEmpty(CompanyName);
    }
}
