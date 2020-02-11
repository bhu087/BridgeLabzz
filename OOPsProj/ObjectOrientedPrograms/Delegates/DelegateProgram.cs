using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms.Delegates
{
    public delegate void Message(string Designation);
    class DelegateProgram
    {
        public static void DelegatesPragram()
        {
            Managers manager = new Managers();
            TeamLeads teamLead = new TeamLeads();
            TeamMembers teamMember = new TeamMembers();
            ContractEmployees contractEmployee = new ContractEmployees();
            Message message = new Message(manager.ManagerList);
            message += teamLead.TeamLeadsList;
            message += teamMember.TeamMembersList;
            message += contractEmployee.ContractEmployeesList;
            message("HR");
        }
    }
}
