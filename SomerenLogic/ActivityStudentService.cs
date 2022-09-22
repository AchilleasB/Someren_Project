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
    public class ActivityStudentService
    {
        ActivityStudentDao activStudentdb;

        public ActivityStudentService()
        {
            activStudentdb = new ActivityStudentDao();
        }

        public List<Activity> GetActivities()
        {
            return activStudentdb.GetAllActivities();
        }

        public List<Student> GetParticipants(Activity activity)
        {
            return activStudentdb.GetAllParticipants(activity);
        }

        public List<Student> GetNonParticipants(Activity activity)
        {
            return activStudentdb.GetAllNonParticipants(activity);
        }

        public void AddParticipant(Student student, Activity activity)
        {
            activStudentdb.AddParticipants(student, activity);
        }

        public void RemoveParticipant(Student student, Activity activity)
        {
            activStudentdb.RemoveParticipants(student, activity);
        }
    }
}
