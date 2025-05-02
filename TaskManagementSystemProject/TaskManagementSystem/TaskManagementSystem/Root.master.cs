using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using DevExpress.Web;

namespace TaskManagementSystem {
    public partial class Root : MasterPage {
        public bool EnableBackButton { get; set; }
        protected void Page_Load(object sender, EventArgs e) {
            if(!string.IsNullOrEmpty(Page.Header.Title))
                Page.Header.Title += " - ";
            Page.Header.Title = Page.Header.Title + "ASP.NET WebForms/MVC Responsive Web Application Template | DevExpress";
            Page.Header.DataBind();
            HideUnusedContent();

        }

        protected void HideUnusedContent() {
            LeftAreaMenu.Items[1].Visible = EnableBackButton;

            bool hasLeftPanelContent = HasContent(LeftPanelContent);
            LeftAreaMenu.Items.FindByName("ToggleLeftPanel").Visible = hasLeftPanelContent;
            LeftPanel.Visible = hasLeftPanelContent;

            bool hasRightPanelContent = HasContent(RightPanelContent);
            RightAreaMenu.Items.FindByName("ToggleRightPanel").Visible = hasRightPanelContent;
            RightPanel.Visible = hasRightPanelContent;

            bool hasPageToolbar = HasContent(PageToolbar);
            PageToolbarPanel.Visible = hasPageToolbar;
        }

        protected bool HasContent(Control contentPlaceHolder) {
            if(contentPlaceHolder == null) return false;

            ControlCollection childControls = contentPlaceHolder.Controls;
            if(childControls.Count == 0) return false;

            return true;
        }



       
    }
}