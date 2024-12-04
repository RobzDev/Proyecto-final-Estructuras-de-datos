namespace Proyecto_final_Estructuras_de_datos.Forms
{
    partial class ListsForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBoxInput = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            btnInserAt = new Button();
            btnRemove = new Button();
            cbListsOptions = new ComboBox();
            btnContains = new Button();
            btnGetAt = new Button();
            btnListElements = new TextBox();
            SuspendLayout();
            // 
            // txtBoxInput
            // 
            txtBoxInput.Location = new Point(223, 57);
            txtBoxInput.Name = "txtBoxInput";
            txtBoxInput.Size = new Size(157, 23);
            txtBoxInput.TabIndex = 0;
            txtBoxInput.TextChanged += txtBoxInput_TextChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(99, 88);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(61, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(190, 118);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(78, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Remove At";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(288, 89);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(59, 23);
            btnClear.TabIndex = 3;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnInserAt
            // 
            btnInserAt.Location = new Point(99, 117);
            btnInserAt.Name = "btnInserAt";
            btnInserAt.Size = new Size(73, 23);
            btnInserAt.TabIndex = 4;
            btnInserAt.Text = "Insert At";
            btnInserAt.UseVisualStyleBackColor = true;
            btnInserAt.Click += btnInserAt_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(190, 89);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(66, 23);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // cbListsOptions
            // 
            cbListsOptions.FormattingEnabled = true;
            cbListsOptions.Items.AddRange(new object[] { "Simple", "Circular", "Doubly", "Doubly Circular" });
            cbListsOptions.Location = new Point(96, 56);
            cbListsOptions.Name = "cbListsOptions";
            cbListsOptions.Size = new Size(121, 23);
            cbListsOptions.TabIndex = 6;
            cbListsOptions.SelectedIndexChanged += cbListsOptions_SelectedIndexChanged;
            // 
            // btnContains
            // 
            btnContains.Location = new Point(288, 118);
            btnContains.Name = "btnContains";
            btnContains.Size = new Size(81, 23);
            btnContains.TabIndex = 7;
            btnContains.Text = "Contains";
            btnContains.UseVisualStyleBackColor = true;
            btnContains.Click += btnContains_Click;
            // 
            // btnGetAt
            // 
            btnGetAt.Location = new Point(375, 118);
            btnGetAt.Name = "btnGetAt";
            btnGetAt.Size = new Size(59, 23);
            btnGetAt.TabIndex = 8;
            btnGetAt.Text = "Get At";
            btnGetAt.UseVisualStyleBackColor = true;
            btnGetAt.Click += btnGetAt_Click;
            // 
            // btnListElements
            // 
            btnListElements.Location = new Point(596, 56);
            btnListElements.Name = "btnListElements";
            btnListElements.Size = new Size(157, 23);
            btnListElements.TabIndex = 10;
            // 
            // ListsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnListElements);
            Controls.Add(btnGetAt);
            Controls.Add(btnContains);
            Controls.Add(cbListsOptions);
            Controls.Add(btnRemove);
            Controls.Add(btnInserAt);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtBoxInput);
            Name = "ListsForm";
            Text = "ListsForm";
            FormClosed += AnyFormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxInput;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnClear;
        private Button btnInserAt;
        private Button btnRemove;
        private ComboBox cbListsOptions;
        private Button btnContains;
        private Button btnGetAt;
        private TextBox btnListElements;
    }
}