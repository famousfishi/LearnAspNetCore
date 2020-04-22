using LearnAspCoreBest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspCoreBest.InterfaceRepositories
{
    public interface ILeadRepository
    {
        Leads GetLeads(int Id);
    }
}
