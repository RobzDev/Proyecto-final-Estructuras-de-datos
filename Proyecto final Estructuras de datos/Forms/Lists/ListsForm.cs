using Proyecto_final_Estructuras_de_datos.Forms.Lists;
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
    public partial class ListsForm : zBase
    {


        private ILinkedList<int> currentList;




        public ListsForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!IsListSelected())
            {
                return;
            }

            //try to add the value to the list if not possible show a message
            try
            {
                currentList.Add(Convert.ToInt32(txtBoxInput.Text));
                //display a message if the value was added and clear the textbox
                MessageBox.Show("Value added");
                txtBoxInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void cbListsOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedList = cbListsOptions.SelectedItem.ToString();

            switch (selectedList)
            {
                case "Simple":
                    currentList = new SimpleLinkedList<int>();
                    break;
                case "Circular":
                    currentList = new CircularLinkedList<int>();
                    break;
                case "Doubly":
                    currentList = new DoublyLinkedList<int>();
                    break;
                case "Doubly Circular":
                    currentList = new DoublyCircularLinkedList<int>();
                    break;
            }
        }
        //create a method to check if there's a selected list
        private bool IsListSelected()
        {
            if (currentList == null)
            {
                MessageBox.Show("Please select a list");
                return false;
            }
            return true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!IsListSelected())
            {
                return;
            }

            try
            {
                currentList.Remove(Convert.ToInt32(txtBoxInput.Text));
                //display a message if the value was removed
                MessageBox.Show("Value removed");
                txtBoxInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (!IsListSelected())
            {
                return;
            }

            currentList.Clear();
            txtBoxInput.Clear();
        }

        private void btnInserAt_Click(object sender, EventArgs e)
        {
            if (!IsListSelected())
            {
                return;
            }

            try
            {
                string[] input = txtBoxInput.Text.Split(',');
                //cast the strting array to an int array
                int[] values = Array.ConvertAll(input, int.Parse);





                currentList.InsertAt(values[0], values[1]);
                MessageBox.Show("Value inserted at position" + txtBoxInput.Text);
                txtBoxInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!IsListSelected())
            {
                return;
            }

            try
            {
                
                currentList.RemoveAt(Convert.ToInt32(txtBoxInput.Text));
                MessageBox.Show("Value removed at position" + txtBoxInput.Text);
                txtBoxInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnContains_Click(object sender, EventArgs e)
        {
            if (!IsListSelected())
            {
                return;
            }

            try
            {
                if (currentList.Contains(Convert.ToInt32(txtBoxInput.Text)))
                {
                    MessageBox.Show("The value is in the list");
                    txtBoxInput.Clear();
                }
                else
                {
                    MessageBox.Show("The value is not in the list");
                    txtBoxInput.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetAt_Click(object sender, EventArgs e)
        {
            if (!IsListSelected())
            {
                return;
            }


            try
            {
                MessageBox.Show(currentList.GetAt(Convert.ToInt32(txtBoxInput.Text)).ToString());
                //display a message saying the value at the position



                txtBoxInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void txtBoxInput_TextChanged(object sender, EventArgs e)
        {

            string elements = DisplayElements(currentList.ToArray());
            //display the elements of the list in the textbox txtListElements
            if (currentList != null)
            {
                btnListElements.Text = elements;
            }




        }

        //create a generic method to display the elements of the list
        private string DisplayElements<T>(T[] elements)
        {
            //create a string to store the elements of the list
            string elementsString = "";

            //iterate through the elements of the list and add them to the string
            foreach (T element in elements)
            {
                elementsString += element + " ";
            }

            return elementsString;
            
        }
    }
}
