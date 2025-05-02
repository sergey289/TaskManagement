using DevExpress.Web;
using DevExpress.Web.Data;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaskManagementSystem.Service;

namespace TaskManagementSystem
{
    public partial class Main : System.Web.UI.Page
    {

        private TaskManagementSystemService _taskManagementSystemService;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _taskManagementSystemService = new TaskManagementSystemService();

                if (!IsPostBack)
                {
                    InitializeForm();
                }

            }
            catch (Exception  ex)
            {

            }
        }

        private void BindGrid()
        {
            DataSet res = _taskManagementSystemService.GetAllTasks();

            if(res != null  && res.Tables.Count >0 )
            {
                ASPxGridView1.DataSource = res.Tables[0];   
                 ViewState["GridDataSource"] = res.Tables[0];
            }

            ASPxGridView1.DataBind();
        }

        private void InitializeForm()
        {
            BindGrid();
        }

        private void InitializeStatusComboBox()
        {
            var statusColumn = ASPxGridView1.Columns["StatusName"] as GridViewDataComboBoxColumn;

            DataSet statusData = _taskManagementSystemService.GetStatuses();

            if (statusColumn != null && statusData != null)
            {
                statusColumn.PropertiesComboBox.DataSource = statusData.Tables.Count > 0 ? statusData.Tables[0] : null;
                statusColumn.PropertiesComboBox.TextField = "Name";
                statusColumn.PropertiesComboBox.ValueField = "Status_Id";
            }
        }

        protected void ASPxGridView1_RowInserting(object sender, ASPxDataInsertingEventArgs e)
        {
            try
            {
                string title = e.NewValues["Title"]?.ToString();
                string description = e.NewValues["Description"]?.ToString();
                int statusTypeID = Convert.ToInt32(e.NewValues["StatusName"]);
                string createdBy = e.NewValues["CreatedBy"]?.ToString();
                string assignedTo  = e.NewValues["AssignedTo"]?.ToString();

               _taskManagementSystemService.AddNewTask(title, description, statusTypeID, createdBy, assignedTo);

                e.Cancel = true;
                BindGrid();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxGridView1_RowUpdating(object sender, ASPxDataUpdatingEventArgs e)
        {
            try
            {

                int taskId = Convert.ToInt32(e.Keys["Task_Id"]);
                string title = e.NewValues["Title"]?.ToString();
                string description = e.NewValues["Description"]?.ToString();
                int? statusTypeID = Convert.ToInt32(e.NewValues["StatusName"]);
                string createdBy = e.NewValues["CreatedBy"]?.ToString();
                string assignedTo = e.NewValues["AssignedTo"]?.ToString();

               _taskManagementSystemService.UpdateTask(taskId,title, description, statusTypeID, createdBy, assignedTo);

                e.Cancel = true;
                ASPxGridView1.CancelEdit();
                BindGrid();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxGridView1_RowDeleting(object sender, ASPxDataDeletingEventArgs e)
        {
            try
            {
                int taskId = Convert.ToInt32(e.Keys["Task_Id"]);

                _taskManagementSystemService.DeleteTask(taskId);

                e.Cancel = true;
                BindGrid();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            try
            {
                   
                if (ViewState["GridDataSource"] != null)
                {
                    ASPxGridView1.DataSource = ViewState["GridDataSource"];
                }

            }catch(Exception ex) 
            { 
            
            }
        }

        protected void ASPxGridView1_InitNewRow(object sender, ASPxDataInitNewRowEventArgs e)
        {

            InitializeStatusComboBox();
        }

        protected void ASPxGridView1_StartRowEditing(object sender, ASPxStartRowEditingEventArgs e)
        {
            try
            {
                InitializeStatusComboBox();

            }catch(Exception ex) 
            { 
            }           
        }

        protected void ASPxGridView1_HeaderFilterFillItems(object sender, ASPxGridViewHeaderFilterEventArgs e)
        {
            try
            {

                if (e.Column.FieldName == "Title")
                {
                    var dt = (DataTable)ViewState["GridDataSource"];
                    var titles = dt.AsEnumerable()
                                 .Select(r => r["Title"]?.ToString())
                                 .Where(t => !string.IsNullOrEmpty(t))
                                 .Distinct();

                    foreach (var title in titles)
                    {
                        e.Values.Add(new FilterValue(title, title));
                    }
                }

            }
            catch(Exception ex)
            {

            }
        }

        protected void ASPxGridView1_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e)
        {

            try
            {

                if (ViewState["GridDataSource"] == null) return;

                DataTable data = (DataTable)ViewState["GridDataSource"];
                string columnName = e.Column.FieldName;
                string filterValue = e.Value.ToString();

                if (!string.IsNullOrEmpty(filterValue))
                {
                    string escapedValue = filterValue.Replace("'", "''");
                    data.DefaultView.RowFilter = $"[{columnName}] LIKE '%{escapedValue}%'";
                }
                else
                {
                    data.DefaultView.RowFilter = string.Empty;
                }

                ASPxGridView1.DataSource = data.DefaultView;
                ASPxGridView1.DataBind();


            }
            catch (Exception ex)
            {

            }         
        }

        protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                // Handle dynamic filtering callbacks
                string[] parameters = e.Parameters.Split('|');
                string columnName = parameters[0];
                string filterValue = parameters[1];

                GridViewDataColumn column = ASPxGridView1.Columns[columnName] as GridViewDataColumn;
                if (column != null)
                {
                    ASPxGridView1.AutoFilterByColumn(column, filterValue);
                }
            }
            catch (Exception ex)
            {

            }
       
        }     
    }
}