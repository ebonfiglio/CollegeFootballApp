using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeFootballApp.Domain.Interfaces
{
    public interface IHeadToHeadCompetitor
    {
        [NotMapped]
        string Identifier { get; }
    }

}
