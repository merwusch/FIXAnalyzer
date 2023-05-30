using System.Windows.Forms;

namespace FIXAnalyzer
{
    partial class Form1
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
            if( disposing && (components != null) )
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
            this.combo_acc = new System.Windows.Forms.ComboBox();
            this.combo_ordID = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fixPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grid2 = new System.Windows.Forms.DataGridView();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Col_ordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ordType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ordStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_trdMatchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ordQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_px = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_sym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_timeInForce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_leavesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_History = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Hst_orderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_ordType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_ordStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_trdMatchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_side = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_px = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_sym = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_timeF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_leavesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hst_fillQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_acc
            // 
            this.combo_acc.FormattingEnabled = true;
            this.combo_acc.Location = new System.Drawing.Point(722, 27);
            this.combo_acc.Name = "combo_acc";
            this.combo_acc.Size = new System.Drawing.Size(121, 21);
            this.combo_acc.TabIndex = 0;
            this.combo_acc.SelectedIndexChanged += new System.EventHandler(this.combo_acc_SelectedIndexChanged);
            // 
            // combo_ordID
            // 
            this.combo_ordID.FormattingEnabled = true;
            this.combo_ordID.Location = new System.Drawing.Point(849, 27);
            this.combo_ordID.Name = "combo_ordID";
            this.combo_ordID.Size = new System.Drawing.Size(121, 21);
            this.combo_ordID.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(976, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(719, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Account";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(846, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Order ID";
            // 
            // txt_fixPath
            // 
            this.txt_fixPath.Location = new System.Drawing.Point(25, 15);
            this.txt_fixPath.Name = "txt_fixPath";
            this.txt_fixPath.Size = new System.Drawing.Size(329, 20);
            this.txt_fixPath.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(20, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1161, 608);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.grid);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.combo_acc);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.combo_ordID);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1153, 582);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "End Of Day";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1057, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "clear\r\n";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grid2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1153, 582);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grid2
            // 
            this.grid2.AllowUserToAddRows = false;
            this.grid2.AllowUserToDeleteRows = false;
            this.grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hst_orderID,
            this.Hst_acc,
            this.Hst_ordType,
            this.Hst_ordStatus,
            this.Hst_trdMatchId,
            this.Hst_side,
            this.Hst_Qty,
            this.Hst_px,
            this.Hst_sym,
            this.Hst_timeF,
            this.Hst_leavesQty,
            this.Hst_fillQty});
            this.grid2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid2.Location = new System.Drawing.Point(0, 54);
            this.grid2.Name = "grid2";
            this.grid2.ReadOnly = true;
            this.grid2.RowHeadersWidth = 10;
            this.grid2.Size = new System.Drawing.Size(1151, 470);
            this.grid2.TabIndex = 9;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_ordID,
            this.Col_acc,
            this.Col_ordType,
            this.Col_ordStatus,
            this.Col_trdMatchId,
            this.Col_side,
            this.Col_ordQty,
            this.Col_px,
            this.Col_sym,
            this.Col_timeInForce,
            this.Col_leavesQty,
            this.Col_History});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid.Location = new System.Drawing.Point(0, 54);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 10;
            this.grid.Size = new System.Drawing.Size(1151, 470);
            this.grid.TabIndex = 8;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // Col_ordID
            // 
            this.Col_ordID.HeaderText = "OrderID";
            this.Col_ordID.Name = "Col_ordID";
            this.Col_ordID.ReadOnly = true;
            this.Col_ordID.Width = 140;
            // 
            // Col_acc
            // 
            this.Col_acc.HeaderText = "Account";
            this.Col_acc.Name = "Col_acc";
            this.Col_acc.ReadOnly = true;
            // 
            // Col_ordType
            // 
            this.Col_ordType.HeaderText = "Order Type";
            this.Col_ordType.Name = "Col_ordType";
            this.Col_ordType.ReadOnly = true;
            this.Col_ordType.Width = 90;
            // 
            // Col_ordStatus
            // 
            this.Col_ordStatus.HeaderText = "Order Status";
            this.Col_ordStatus.Name = "Col_ordStatus";
            this.Col_ordStatus.ReadOnly = true;
            this.Col_ordStatus.Width = 90;
            // 
            // Col_trdMatchId
            // 
            this.Col_trdMatchId.HeaderText = "Trade Match ID";
            this.Col_trdMatchId.Name = "Col_trdMatchId";
            this.Col_trdMatchId.ReadOnly = true;
            this.Col_trdMatchId.Width = 130;
            // 
            // Col_side
            // 
            this.Col_side.HeaderText = "Side";
            this.Col_side.Name = "Col_side";
            this.Col_side.ReadOnly = true;
            this.Col_side.Width = 60;
            // 
            // Col_ordQty
            // 
            this.Col_ordQty.HeaderText = "Order Quantity";
            this.Col_ordQty.Name = "Col_ordQty";
            this.Col_ordQty.ReadOnly = true;
            this.Col_ordQty.Width = 50;
            // 
            // Col_px
            // 
            this.Col_px.HeaderText = "Price";
            this.Col_px.Name = "Col_px";
            this.Col_px.ReadOnly = true;
            this.Col_px.Width = 80;
            // 
            // Col_sym
            // 
            this.Col_sym.HeaderText = "Symbol";
            this.Col_sym.Name = "Col_sym";
            this.Col_sym.ReadOnly = true;
            // 
            // Col_timeInForce
            // 
            this.Col_timeInForce.HeaderText = "Time in Force";
            this.Col_timeInForce.Name = "Col_timeInForce";
            this.Col_timeInForce.ReadOnly = true;
            this.Col_timeInForce.Width = 120;
            // 
            // Col_leavesQty
            // 
            this.Col_leavesQty.HeaderText = "Leaves Quantity";
            this.Col_leavesQty.Name = "Col_leavesQty";
            this.Col_leavesQty.ReadOnly = true;
            this.Col_leavesQty.Width = 80;
            // 
            // Col_History
            // 
            this.Col_History.HeaderText = "History";
            this.Col_History.Name = "Col_History";
            this.Col_History.ReadOnly = true;
            this.Col_History.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Col_History.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Col_History.Text = "History";
            this.Col_History.UseColumnTextForButtonValue = true;
            this.Col_History.Width = 80;
            // 
            // Hst_orderID
            // 
            this.Hst_orderID.HeaderText = "OrderID";
            this.Hst_orderID.Name = "Hst_orderID";
            this.Hst_orderID.ReadOnly = true;
            this.Hst_orderID.Width = 120;
            // 
            // Hst_acc
            // 
            this.Hst_acc.HeaderText = "Account";
            this.Hst_acc.Name = "Hst_acc";
            this.Hst_acc.ReadOnly = true;
            // 
            // Hst_ordType
            // 
            this.Hst_ordType.HeaderText = "Order Type";
            this.Hst_ordType.Name = "Hst_ordType";
            this.Hst_ordType.ReadOnly = true;
            this.Hst_ordType.Width = 80;
            // 
            // Hst_ordStatus
            // 
            this.Hst_ordStatus.HeaderText = "Order Status";
            this.Hst_ordStatus.Name = "Hst_ordStatus";
            this.Hst_ordStatus.ReadOnly = true;
            this.Hst_ordStatus.Width = 80;
            // 
            // Hst_trdMatchId
            // 
            this.Hst_trdMatchId.HeaderText = "Trade Match ID";
            this.Hst_trdMatchId.Name = "Hst_trdMatchId";
            this.Hst_trdMatchId.ReadOnly = true;
            this.Hst_trdMatchId.Width = 130;
            // 
            // Hst_side
            // 
            this.Hst_side.HeaderText = "Side";
            this.Hst_side.Name = "Hst_side";
            this.Hst_side.ReadOnly = true;
            this.Hst_side.Width = 50;
            // 
            // Hst_Qty
            // 
            this.Hst_Qty.HeaderText = "Order Quantity";
            this.Hst_Qty.Name = "Hst_Qty";
            this.Hst_Qty.ReadOnly = true;
            this.Hst_Qty.Width = 60;
            // 
            // Hst_px
            // 
            this.Hst_px.HeaderText = "Price";
            this.Hst_px.Name = "Hst_px";
            this.Hst_px.ReadOnly = true;
            // 
            // Hst_sym
            // 
            this.Hst_sym.HeaderText = "Symbol";
            this.Hst_sym.Name = "Hst_sym";
            this.Hst_sym.ReadOnly = true;
            // 
            // Hst_timeF
            // 
            this.Hst_timeF.HeaderText = "Time in Force";
            this.Hst_timeF.Name = "Hst_timeF";
            this.Hst_timeF.ReadOnly = true;
            this.Hst_timeF.Width = 150;
            // 
            // Hst_leavesQty
            // 
            this.Hst_leavesQty.HeaderText = "Leaves Quantity";
            this.Hst_leavesQty.Name = "Hst_leavesQty";
            this.Hst_leavesQty.ReadOnly = true;
            this.Hst_leavesQty.Width = 80;
            // 
            // Hst_fillQty
            // 
            this.Hst_fillQty.HeaderText = "Fill Quantity";
            this.Hst_fillQty.Name = "Hst_fillQty";
            this.Hst_fillQty.ReadOnly = true;
            this.Hst_fillQty.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1210, 661);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_fixPath);
            this.Name = "Form1";
            this.Text = "FIX Analyzer";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ComboBox combo_acc;
        private System.Windows.Forms.ComboBox combo_ordID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_fixPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.DataGridView grid2;
        private Button button3;
        public DataGridView grid;
        private DataGridViewTextBoxColumn Col_ordID;
        private DataGridViewTextBoxColumn Col_acc;
        private DataGridViewTextBoxColumn Col_ordType;
        private DataGridViewTextBoxColumn Col_ordStatus;
        private DataGridViewTextBoxColumn Col_trdMatchId;
        private DataGridViewTextBoxColumn Col_side;
        private DataGridViewTextBoxColumn Col_ordQty;
        private DataGridViewTextBoxColumn Col_px;
        private DataGridViewTextBoxColumn Col_sym;
        private DataGridViewTextBoxColumn Col_timeInForce;
        private DataGridViewTextBoxColumn Col_leavesQty;
        private DataGridViewButtonColumn Col_History;
        private DataGridViewTextBoxColumn Hst_orderID;
        private DataGridViewTextBoxColumn Hst_acc;
        private DataGridViewTextBoxColumn Hst_ordType;
        private DataGridViewTextBoxColumn Hst_ordStatus;
        private DataGridViewTextBoxColumn Hst_trdMatchId;
        private DataGridViewTextBoxColumn Hst_side;
        private DataGridViewTextBoxColumn Hst_Qty;
        private DataGridViewTextBoxColumn Hst_px;
        private DataGridViewTextBoxColumn Hst_sym;
        private DataGridViewTextBoxColumn Hst_timeF;
        private DataGridViewTextBoxColumn Hst_leavesQty;
        private DataGridViewTextBoxColumn Hst_fillQty;
    }
}