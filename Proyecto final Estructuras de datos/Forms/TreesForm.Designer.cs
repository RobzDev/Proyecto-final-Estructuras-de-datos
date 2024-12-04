namespace Proyecto_final_Estructuras_de_datos.Forms
{
    partial class TreesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Creator = new Button();
            txtbx_array = new TextBox();
            cbOrder = new ComboBox();
            btnContains = new Button();
            btndelete = new Button();
            btnInsert = new Button();
            btnView = new Button();
            pbTree = new PictureBox();
            btnDrop = new Button();
            ((System.ComponentModel.ISupportInitialize)pbTree).BeginInit();
            SuspendLayout();
            // 
            // btn_Creator
            // 
            btn_Creator.Location = new Point(409, 61);
            btn_Creator.Name = "btn_Creator";
            btn_Creator.Size = new Size(113, 27);
            btn_Creator.TabIndex = 0;
            btn_Creator.Text = "Create Tree";
            btn_Creator.UseVisualStyleBackColor = true;
            btn_Creator.Click += btn_Creator_Click;
            // 
            // txtbx_array
            // 
            txtbx_array.Location = new Point(347, 32);
            txtbx_array.Name = "txtbx_array";
            txtbx_array.Size = new Size(263, 23);
            txtbx_array.TabIndex = 1;
            // 
            // cbOrder
            // 
            cbOrder.FormattingEnabled = true;
            cbOrder.Items.AddRange(new object[] { "In Order ", "Pre Order ", "Post Order" });
            cbOrder.Location = new Point(616, 32);
            cbOrder.Name = "cbOrder";
            cbOrder.Size = new Size(123, 23);
            cbOrder.TabIndex = 4;
            cbOrder.TabStop = false;
            cbOrder.Text = "Select Order";
            cbOrder.SelectedIndexChanged += cbOrder_SelectedIndexChanged;
            // 
            // btnContains
            // 
            btnContains.Location = new Point(528, 61);
            btnContains.Name = "btnContains";
            btnContains.Size = new Size(105, 27);
            btnContains.TabIndex = 5;
            btnContains.Text = "Search";
            btnContains.UseVisualStyleBackColor = true;
            btnContains.Click += btnContains_Click;
            // 
            // btndelete
            // 
            btndelete.Location = new Point(639, 61);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(77, 27);
            btndelete.TabIndex = 6;
            btndelete.Text = "Delete";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(304, 61);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(99, 27);
            btnInsert.TabIndex = 7;
            btnInsert.Text = "Insert number";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(722, 61);
            btnView.Name = "btnView";
            btnView.Size = new Size(108, 27);
            btnView.TabIndex = 8;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // pbTree
            // 
            pbTree.Anchor = AnchorStyles.None;
            pbTree.Location = new Point(39, 118);
            pbTree.Name = "pbTree";
            pbTree.Size = new Size(1034, 525);
            pbTree.TabIndex = 11;
            pbTree.TabStop = false;
            // 
            // btnDrop
            // 
            btnDrop.Location = new Point(221, 61);
            btnDrop.Name = "btnDrop";
            btnDrop.Size = new Size(77, 27);
            btnDrop.TabIndex = 12;
            btnDrop.Text = "Drop Tree";
            btnDrop.UseVisualStyleBackColor = true;
            btnDrop.Click += btnDrop_Click;
            // 
            // TreesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 692);
            Controls.Add(btnDrop);
            Controls.Add(pbTree);
            Controls.Add(btnView);
            Controls.Add(btnInsert);
            Controls.Add(btndelete);
            Controls.Add(btnContains);
            Controls.Add(cbOrder);
            Controls.Add(txtbx_array);
            Controls.Add(btn_Creator);
            Name = "TreesForm";
            Text = "Binary Trees";
            ((System.ComponentModel.ISupportInitialize)pbTree).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Creator;
        private TextBox txtbx_array;
        private ComboBox cbOrder;
        private Button btnContains;
        private Button btndelete;
        private Button btnInsert;
        private Button btnView;
        private PictureBox pbTree;
        private Button btnDrop;
    }
}