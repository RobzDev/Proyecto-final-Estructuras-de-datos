namespace Proyecto_final_Estructuras_de_datos
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            lBoxOptions = new ListBox();
            lblTitle = new Label();
            lblselectoption = new Label();
            SuspendLayout();
            // 
            // lBoxOptions
            // 
            lBoxOptions.BorderStyle = BorderStyle.None;
            lBoxOptions.FormattingEnabled = true;
            lBoxOptions.ItemHeight = 15;
            lBoxOptions.Items.AddRange(new object[] { "     Lists", "     Stacks", "    Queues", "  Binary Trees", "    Graphs", " Algorithms" });
            lBoxOptions.Location = new Point(97, 110);
            lBoxOptions.Name = "lBoxOptions";
            lBoxOptions.Size = new Size(83, 165);
            lBoxOptions.TabIndex = 0;
            lBoxOptions.SelectedIndexChanged += lBoxOptions_SelectedIndexChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Unispace", 27.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(3, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(318, 44);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Final Proyect";
            // 
            // lblselectoption
            // 
            lblselectoption.AutoSize = true;
            lblselectoption.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblselectoption.ForeColor = Color.Blue;
            lblselectoption.Location = new Point(74, 80);
            lblselectoption.Name = "lblselectoption";
            lblselectoption.Size = new Size(131, 18);
            lblselectoption.TabIndex = 2;
            lblselectoption.Text = "Select An Option";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 354);
            Controls.Add(lblselectoption);
            Controls.Add(lblTitle);
            Controls.Add(lBoxOptions);
            Name = "Main";
            Text = "Main";
            FormClosed += AnyFormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lBoxOptions;
        private Label lblTitle;
        private Label lblselectoption;
    }
}
