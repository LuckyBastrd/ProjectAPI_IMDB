using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectAPI_IMDB.View
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                boxId.Visible = false;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchInput.Value;

            if (string.IsNullOrEmpty(searchText))
            {
                boxId.Visible = false;
            }

            else
            {
                boxId.Visible = true;
            }
        }
    }
}