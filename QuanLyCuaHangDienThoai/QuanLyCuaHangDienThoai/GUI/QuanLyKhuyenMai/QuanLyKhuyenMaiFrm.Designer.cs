namespace QuanLyCuaHangDienThoai.GUI.QuanLyKhuyenMai
{
    partial class QuanLyKhuyenMaiFrm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.refreshBtn = new System.Windows.Forms.Button();
            this.timKiemBtn = new System.Windows.Forms.Button();
            this.timKiemKMtxt = new System.Windows.Forms.TextBox();
            this.KhuyenMaiListView = new System.Windows.Forms.ListView();
            this.themBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // refreshBtn
            // 
            this.refreshBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.Location = new System.Drawing.Point(897, 10);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(116, 31);
            this.refreshBtn.TabIndex = 12;
            this.refreshBtn.Text = "Làm mới";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // timKiemBtn
            // 
            this.timKiemBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timKiemBtn.Location = new System.Drawing.Point(298, 10);
            this.timKiemBtn.Name = "timKiemBtn";
            this.timKiemBtn.Size = new System.Drawing.Size(86, 31);
            this.timKiemBtn.TabIndex = 11;
            this.timKiemBtn.Text = "Tìm";
            this.timKiemBtn.UseVisualStyleBackColor = true;
            this.timKiemBtn.Click += new System.EventHandler(this.timKiemBtn_Click);
            // 
            // timKiemKMtxt
            // 
            this.timKiemKMtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timKiemKMtxt.Location = new System.Drawing.Point(10, 10);
            this.timKiemKMtxt.Name = "timKiemKMtxt";
            this.timKiemKMtxt.Size = new System.Drawing.Size(280, 30);
            this.timKiemKMtxt.TabIndex = 10;
            // 
            // KhuyenMaiListView
            // 
            this.KhuyenMaiListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KhuyenMaiListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KhuyenMaiListView.FullRowSelect = true;
            this.KhuyenMaiListView.HideSelection = false;
            this.KhuyenMaiListView.Location = new System.Drawing.Point(10, 54);
            this.KhuyenMaiListView.Margin = new System.Windows.Forms.Padding(10);
            this.KhuyenMaiListView.MultiSelect = false;
            this.KhuyenMaiListView.Name = "KhuyenMaiListView";
            this.KhuyenMaiListView.Size = new System.Drawing.Size(1001, 471);
            this.KhuyenMaiListView.TabIndex = 13;
            this.KhuyenMaiListView.UseCompatibleStateImageBehavior = false;
            this.KhuyenMaiListView.View = System.Windows.Forms.View.Details;
            this.KhuyenMaiListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.KhuyenMaiListView_ColumnClick);
            this.KhuyenMaiListView.SizeChanged += new System.EventHandler(this.KhuyenMaiListView_SizeChanged);
            this.KhuyenMaiListView.Click += new System.EventHandler(this.KhuyenMaiListView_Click);
            // 
            // themBtn
            // 
            this.themBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.themBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themBtn.Location = new System.Drawing.Point(10, 535);
            this.themBtn.Margin = new System.Windows.Forms.Padding(0);
            this.themBtn.Name = "themBtn";
            this.themBtn.Size = new System.Drawing.Size(85, 35);
            this.themBtn.TabIndex = 14;
            this.themBtn.Text = "Thêm";
            this.themBtn.UseVisualStyleBackColor = true;
            this.themBtn.Click += new System.EventHandler(this.themBtn_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(104, 535);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cập nhật";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(200, 535);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Xóa";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuanLyKhuyenMaiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.themBtn);
            this.Controls.Add(this.KhuyenMaiListView);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.timKiemBtn);
            this.Controls.Add(this.timKiemKMtxt);
            this.Name = "QuanLyKhuyenMaiFrm";
            this.Size = new System.Drawing.Size(1029, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button timKiemBtn;
        private System.Windows.Forms.TextBox timKiemKMtxt;
        private System.Windows.Forms.ListView KhuyenMaiListView;
        private System.Windows.Forms.Button themBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
