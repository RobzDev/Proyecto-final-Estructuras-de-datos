using Proyecto_final_Estructuras_de_datos.Forms;

namespace Proyecto_final_Estructuras_de_datos
{
    public partial class Main : zBase
    {
        public Main()
        {
            InitializeComponent();
            

        }
       
        

        private void lBoxOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (lBoxOptions.SelectedIndex)
              {
                    case 0:
                       ListsForm listsForm = new ListsForm();
                       listsForm.Show();
                       this.Hide();
                    break;
                    case 1:
                        StacksForm stacksForm = new StacksForm();
                        stacksForm.Show();
                       this.Hide();
                        break;
                    case 2:
                        QueuesForm queuesForm = new QueuesForm();
                        queuesForm.Show();
                        this.Hide();
                       break;
                    case 3:
                        TreesForm treesForm = new TreesForm();
                        treesForm.Show();
                        this.Hide();
                         break;
                    case 4:
                        GraphsForm graphsForm = new GraphsForm();
                        graphsForm.Show();
                         this.Hide();
                         break;
                    case 5:
                        AlgorithmsForm algorithmsForm = new AlgorithmsForm();
                        algorithmsForm.Show();
                         this.Hide();
                        break;
                }
            }

        
    }

}
