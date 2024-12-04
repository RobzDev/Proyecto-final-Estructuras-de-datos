using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_final_Estructuras_de_datos.Forms
{
    public partial class zBase : Form
    {
        public zBase()
        {
           
            this.FormClosed += AnyFormClosed; 
        }
        protected void AnyFormClosed(object sender, FormClosedEventArgs e)
        {
          
            if (sender is Form form && form is not Main)
            {
                Main mainForm = Application.OpenForms["Main"] as Main;
                if (mainForm != null)
                {
                    mainForm.Show();
                }
            }
        }
    }
}
