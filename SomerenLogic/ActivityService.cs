using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using SomerenDAL;
using System.Windows.Forms;

namespace SomerenLogic
{
    public class ActivityService
    {
        ActivityDao activitydb;

        public ActivityService()
        {
            activitydb = new ActivityDao();
        }

        public List<Activity> GetActivities()
        {
            return activitydb.GetAllActivities();
        }

        public Activity GetActivity(int activityId)
        {
            return activitydb.GetActivityById(activityId);
        }

        public void AddActivity(Activity activity)
        {
            activitydb.CreateActivity(activity);
        }

        public void UpdateActivity(Activity activity)
        {
            activitydb.UpdateActivity(activity);
        }

        public void DeleteActivity(int activityId)
        {
            activitydb.DeleteActivity(activityId);
        }

        // validate activity start and end datetime
        public bool IsValidActivityDate(DateTime startDate, DateTime endDate)
        {
            // check if start datetime AND end datetime are in the future
            bool isFuture = DateTime.Compare(startDate, DateTime.Now) > 0 && DateTime.Compare(endDate, DateTime.Now) > 0;

            // check if start datetime is earlier than end datetime
            bool isEarlier = DateTime.Compare(startDate, endDate) < 0;

            return isFuture && isEarlier;
        }
    }
}
