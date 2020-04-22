using LearnAspCoreBest.InterfaceRepositories;
using LearnAspCoreBest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspCoreBest.MockData
{
    public class MockLeadRepository : ILeadRepository
    {
        private List<Leads> _leadsList;
        public MockLeadRepository()
        {
            _leadsList = new List<Leads>()
            {
                new Leads() {Id= 1, Age= 23, Name="Fisayo", Profession="Software Engineer"},
                new Leads() {Id= 2, Age= 23, Name="Favour", Profession="Software Engineer"},
                new Leads() {Id= 3, Age= 23, Name="Doyinsola", Profession="Software Engineer"},
            };

        }
        public Leads GetLeads(int Id)
        {
            return _leadsList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
