using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TaskManagementSystem.Data;

namespace TaskManagementSystem.Service
{
    public class TaskManagementSystemService: ITaskManagementSystemService
    {

        private SQL _sql;

        public TaskManagementSystemService()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _sql = new SQL(connectionString);
        }

        public DataSet GetAllTasks()
        {
            DataSet ds;

            ds = _sql.ExecuteProcedure("Proc_Get_All_Tasks");

            return ds;
        }

        public DataSet GetStatuses()
        {

            DataSet ds;

            ds = _sql.ExecuteProcedure("Proc_Get_Statuses");

            return ds;

        }

        public void AddNewTask(string title,string description, int statusTypeID,string createdBy,string assignedTo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@Status_Id", statusTypeID),
                new SqlParameter("@CreatedBy", createdBy),
                new SqlParameter("@AssignedTo", assignedTo),
            };

            _sql.ExecuteProcedure("Proc_Add_New_Task", parameters);
        }

        public void UpdateTask(int taskID, string title, string description, int? statusTypeID, string createdBy, string assignedTo)
        {
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@TaskId", taskID),
               new SqlParameter("@Title", title),
               new SqlParameter("@Description", description),
               new SqlParameter("@Status_Id", statusTypeID),
               new SqlParameter("@CreatedBy", createdBy),
               new SqlParameter("@AssignedTo", assignedTo),
            };

            _sql.ExecuteProcedure("Proc_Update_Task", parameters);
        }

        public void DeleteTask(int taskID)
        {
          List<SqlParameter> parameters = new List<SqlParameter>
          {
             new SqlParameter("@TaskId", taskID)          
          };

            _sql.ExecuteProcedure("Proc_Delete_Task", parameters);
        }

      
    }
}