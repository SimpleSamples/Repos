using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SamplesSite
{
    public partial class ReorderListTutorial : System.Web.UI.Page
    {
        ModelTutorials db = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new ModelTutorials();
        }

        public IQueryable<AJAX> GetData()
        {
            return db.AJAXes;
        }

        public void UpdateItem(int id)
        {
            AJAX item = null;
            item = db.AJAXes.Find(id);
            if (item == null)
            {
                ModelState.AddModelError("",
                  String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
            }
        }
    }
}