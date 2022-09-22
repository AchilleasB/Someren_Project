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
    public class SupervisorActivityDao : BaseDao
    {


        public List<Activity> GetAllActivities()
        {
            string query = "SELECT ActivityId, Description, StartDateTime, EndDateTime FROM [Activities]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        public List<Teacher> GetActivitySupervisors(int activityId)
        {
            //get the Ids of all supervisors
            string query = "SELECT LecturerId as teacherId FROM [Supervisors] WHERE ActivityId = @activityId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@activityId", activityId);
            List<int>supervisorIds=ReadTeacherIds(ExecuteSelectQuery(query, sqlParameters));

            List<Teacher> teachers = new List<Teacher>();

            //use the Ids to retrieve the teachers from the teachers table
            foreach (int id in supervisorIds) 
            {
                string teacherQuery = "SELECT teacherId, name, age FROM [Teachers] WHERE  teacherId= @TeacherID";
                SqlParameter[] sqlParameters2 = new SqlParameter[1];
                sqlParameters2[0] = new SqlParameter("@TeacherID", id);
                teachers.Add(ReadTeachers(ExecuteSelectQuery(teacherQuery, sqlParameters2))[0]);
            }
            return teachers;
        }
        public List<Teacher> GetAllNonSupervisors()
        {
            string teacherQuery = "SELECT teacherId, name, age FROM [Teachers]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            List<Teacher> teachers = ReadTeachers(ExecuteSelectQuery(teacherQuery, sqlParameters));
         
            return teachers;
        }
        public void AddSupervisor(int teacherId, int activityId) 
        {
            string query = "INSERT INTO Supervisors(SupervisorId, LecturerId, ActivityId) VALUES (@supervisorId,@teacherId,@activityId)";
            SqlParameter[] sqlParameters = new SqlParameter[3];
            int supervisorId = teacherId * 10 + activityId;
            sqlParameters[0] = new SqlParameter("@teacherId", teacherId);
            sqlParameters[1] = new SqlParameter("@activityId", activityId);
            sqlParameters[2] = new SqlParameter("@supervisorId", supervisorId);
            ExecuteEditQuery(query, sqlParameters);
        }
        public void DeleteSupervisor(int teacherId, int activityId)
        {
            string query = "DELETE FROM Supervisors WHERE LecturerId = @teacherId AND ActivityId =@activityId";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@teacherId", teacherId);
            sqlParameters[1] = new SqlParameter("@activityId", activityId);
            ExecuteEditQuery(query, sqlParameters);
        }
        public List<Teacher> ReadTeachers(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    Number = (int)dr["teacherID"],
                    Name = (string)dr["name"].ToString(),
                    Supervisor = (string)dr["age"]
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
        public List<int> ReadTeacherIds(DataTable dataTable)
        {
            List<int> ids = new List<int>();
            int id = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                id = ((int)row["teacherId"]);
                ids.Add(id);
            }
            
            return ids;
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
                    EndDateTime = (DateTime)dr["EndDateTime"],
                };
                activities.Add(activity);
            }
            return activities;
        }
        public void DeleteSupervisor(int supervisorId)
        {
            string query = "DELETE FROM [Drinks] WHERE DrinkId = @supervisorId";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@supervisorId", supervisorId);
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
