using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AttribDemo
{
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct , AllowMultiple = true)]
    public sealed class CodeReviewAttribute : Attribute
    {
        private string _name;
        private DateTime _reviewDate;
        private bool _approved;

        public string Name => _name;
        public DateTime ReviewDate => _reviewDate;
        public bool Approved => _approved;

        public CodeReviewAttribute(string name, string reviewDate, bool approved)
        {
            _name = name;
            _reviewDate = DateTime.ParseExact(reviewDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            _approved = approved;
        }
    }
}
