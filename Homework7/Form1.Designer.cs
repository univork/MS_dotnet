namespace Homework7
{
    partial class Form1
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
            gridProducts = new DataGridView();
            tbTitle = new TextBox();
            tbDescription = new RichTextBox();
            tbPrice = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cbCategory = new ComboBox();
            label4 = new Label();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)gridProducts).BeginInit();
            SuspendLayout();
            // 
            // gridProducts
            // 
            gridProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridProducts.Location = new Point(12, 265);
            gridProducts.Name = "gridProducts";
            gridProducts.RowHeadersWidth = 51;
            gridProducts.Size = new Size(823, 259);
            gridProducts.TabIndex = 0;
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(43, 22);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(769, 27);
            tbTitle.TabIndex = 1;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(43, 75);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(769, 46);
            tbDescription.TabIndex = 2;
            tbDescription.Text = "";
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(43, 146);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(769, 27);
            tbPrice.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, -1);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 4;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 52);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 5;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 123);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 6;
            label3.Text = "Price";
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(43, 196);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(769, 28);
            cbCategory.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(43, 173);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 8;
            label4.Text = "Category";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(43, 230);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(769, 29);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(847, 536);
            Controls.Add(btnAdd);
            Controls.Add(label4);
            Controls.Add(cbCategory);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPrice);
            Controls.Add(tbDescription);
            Controls.Add(tbTitle);
            Controls.Add(gridProducts);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gridProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gridProducts;
        private TextBox tbTitle;
        private RichTextBox tbDescription;
        private TextBox tbPrice;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cbCategory;
        private Label label4;
        private Button btnAdd;
    }
}
