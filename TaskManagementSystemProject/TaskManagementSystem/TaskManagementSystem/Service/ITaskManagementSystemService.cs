using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Service
{
    internal interface ITaskManagementSystemService
    {

        DataSet GetAllTasks();

        DataSet GetStatuses();

        void AddNewTask(string title, string description, int statusTypeID, string createdBy, string assignedTo);

        void UpdateTask(int taskID, string title, string description, int? statusTypeID, string createdBy, string assignedTo);

        void DeleteTask(int taskID);
    }
}
