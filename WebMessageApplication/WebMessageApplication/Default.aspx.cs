using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMessageApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClearMessages_Click(object sender, EventArgs e)
        {
            using (MessageDatabaseEntities db = new MessageDatabaseEntities())
            {
                var allMessages = from a in db.Messages
                                  select a;

                foreach (var b in allMessages)
                {
                    db.Messages.Remove(b);
                }
                db.SaveChanges();
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}