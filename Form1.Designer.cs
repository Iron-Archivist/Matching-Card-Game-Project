namespace Matching_Card_Game_Project
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
            panel1 = new Panel();
            GameWindow = new TableLayoutPanel();
            button1 = new Button();
            DifficultySelect = new ListBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(GameWindow);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(886, 893);
            panel1.TabIndex = 0;
            // 
            // GameWindow
            // 
            GameWindow.AutoSize = true;
            GameWindow.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            GameWindow.ColumnCount = 2;
            GameWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            GameWindow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            GameWindow.Dock = DockStyle.Fill;
            GameWindow.Location = new Point(0, 0);
            GameWindow.Name = "GameWindow";
            GameWindow.RowCount = 2;
            GameWindow.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            GameWindow.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            GameWindow.Size = new Size(884, 891);
            GameWindow.TabIndex = 0;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Location = new Point(12, 1033);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DifficultySelect
            // 
            DifficultySelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            DifficultySelect.FormattingEnabled = true;
            DifficultySelect.ItemHeight = 15;
            DifficultySelect.Items.AddRange(new object[] { "Easy", "Medium", "Hard" });
            DifficultySelect.Location = new Point(12, 933);
            DifficultySelect.Name = "DifficultySelect";
            DifficultySelect.Size = new Size(120, 94);
            DifficultySelect.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(692, 995);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 1079);
            Controls.Add(label1);
            Controls.Add(DifficultySelect);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "`";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel GameWindow;
        private Button button1;
        private ListBox DifficultySelect;
        private Label label1;
    }
}
