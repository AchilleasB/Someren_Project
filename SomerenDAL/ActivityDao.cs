using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class ActivityDao : BaseDao
    {


        public List<Activity> GetAllActivities()
        {
            string query = "SELECT ActivityId, Description, StartDateTime, EndDateTime FROM [Activities]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    Id = (int)dr["ActivityId"],
                    Description = (string)dr["Description"],
                    StartDateTime = (DateTime)dr["startDateTime"],
                    EndDateTime = (DateTime)dr["EndDateTime"]
                };

                activities.Add(activity);
            }

            return activities;
        }

        public Activity GetActivityById(int activityId)
        {
            string query = "SELECT ActivityId, Description, StartDateTime, EndDateTime FROM [Activities] WHERE ActivityId = @ActivityId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityId", activityId);
            return ReadTables(ExecuteSelectQuery(query, sqlParameters))[0];
        }

        public void CreateActivity(Activity activity)
        {
            string query = "INSERT INTO Activities(Description, StartDateTime, EndDateTime) values(@Description, @StartDateTime, @EndDateTime)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@Description", activity.Description);
            sqlParameters[1] = new SqlParameter("@StartDateTime", activity.StartDateTime);
            sqlParameters[2] = new SqlParameter("@EndDateTime", activity.EndDateTime);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void UpdateActivity(Activity activity)
        {
            string query = "UPDATE [Activities] SET description = @Description, StartDateTime = @StartDateTime, EndDateTime = @EndDateTime WHERE ActivityId = @ActivityId";
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.Id);
            sqlParameters[1] = new SqlParameter("@Description", activity.Description);
            sqlParameters[2] = new SqlParameter("@StartDateTime", activity.StartDateTime);
            sqlParameters[3] = new SqlParameter("@EndDateTime", activity.EndDateTime);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void DeleteActivity(int activityId)
        {
            string query = "DELETE FROM [Activities] WHERE ActivityId = @ActivityId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityId", activityId);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
