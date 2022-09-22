using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class SupervisorActivityService
    {
        SupervisorActivityDao SupervisorActivitydb;

        public SupervisorActivityService()
        {
            SupervisorActivitydb = new SupervisorActivityDao();
        }

        public List<Activity> GetAllActivities()
        {
            List<Activity> activities = SupervisorActivitydb.GetAllActivities();
            return activities;
        }
        public List<Teacher> GetAllActivitySupervisors(int activityId)
        {
            List<Teacher> supervisors = SupervisorActivitydb.GetActivitySupervisors(activityId);
            return supervisors;
        }
        public List<Teacher> GetAllNonSupervisors()
        {
            List<Teacher> nonSupervisors = SupervisorActivitydb.GetAllNonSupervisors();
            return nonSupervisors;
        }
        public void AddSupervisor(int supervisorId, int activityId)
        {
            SupervisorActivitydb.AddSupervisor(supervisorId, activityId);
        }
        public void DeleteSupervisor(int supervisorId, int activityId) 
        {
            SupervisorActivitydb.DeleteSupervisor(supervisorId, activityId);
        }
    }
}

