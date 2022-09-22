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
    public class ActivityStudentDao : BaseDao
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
                    StartDateTime = (DateTime)dr["StartDateTime"],
                    EndDateTime = (DateTime)dr["EndDateTime"]
                };
                activities.Add(activity);
            }
            return activities;
        }

        public List<Student> GetAllParticipants(Activity activity)
        {
            string query = "SELECT StudentName, StudentId  FROM [Students] WHERE StudentId IN (SELECT StudentId FROM [ActivityStudents] WHERE ActivityId =  @ActivityId)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.Id);
            return ReadParticipants(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<Student> GetAllNonParticipants(Activity activity)
        {
            string query = "SELECT StudentName, StudentId FROM [Students] WHERE StudentId NOT IN (SELECT StudentId FROM [ActivityStudents] WHERE ActivityId = @ActivityId)";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.Id);
            return ReadParticipants(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadParticipants(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    Number = (int)dr["StudentId"],
                    Name = (string)dr["StudentName"]
                };
                students.Add(student);
            }
            return students;
        }

        public void AddParticipants(Student student, Activity activity)
        {
            string query = "INSERT INTO [ActivityStudents] (ActivityId, StudentId) values(@ActivityId, @StudentId)";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.Id);
            sqlParameters[1] = new SqlParameter("@StudentId", student.Number);
            ExecuteEditQuery(query, sqlParameters);
        }

        public void RemoveParticipants(Student student, Activity activity)
        {
            string query = "DELETE FROM [ActivityStudents] WHERE  StudentId = @StudentId AND ActivityId = @ActivityId";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@ActivityId", activity.Id);
            sqlParameters[1] = new SqlParameter("@StudentId", student.Number);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
