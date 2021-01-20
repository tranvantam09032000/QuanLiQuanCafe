namespace QUANCOFFE
{
    partial class frmQuanLy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLy));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.HoaDonBanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HoaDonNhapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyNhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanPhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThongTinCaNhanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DoiMatKhauToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HoaDonBanToolStripMenuItem,
            this.HoaDonNhapToolStripMenuItem,
            this.QuanLyNhanVienToolStripMenuItem,
            this.sanPhamToolStripMenuItem,
            this.ThongTinCaNhanToolStripMenuItem,
            this.DoiMatKhauToolStripMenuItem1,
            this.dangXuatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HoaDonBanToolStripMenuItem
            // 
            this.HoaDonBanToolStripMenuItem.Name = "HoaDonBanToolStripMenuItem";
            this.HoaDonBanToolStripMenuItem.Size = new System.Drawing.Size(133, 23);
            this.HoaDonBanToolStripMenuItem.Text = "HÓA ĐƠN BÁN";
            this.HoaDonBanToolStripMenuItem.Click += new System.EventHandler(this.HoaDonBanToolStripMenuItem_Click);
            // 
            // HoaDonNhapToolStripMenuItem
            // 
            this.HoaDonNhapToolStripMenuItem.Name = "HoaDonNhapToolStripMenuItem";
            this.HoaDonNhapToolStripMenuItem.Size = new System.Drawing.Size(143, 23);
            this.HoaDonNhapToolStripMenuItem.Text = "HÓA ĐƠN NHẬP";
            this.HoaDonNhapToolStripMenuItem.Click += new System.EventHandler(this.HoaDonNhapToolStripMenuItem_Click);
            // 
            // QuanLyNhanVienToolStripMenuItem
            // 
            this.QuanLyNhanVienToolStripMenuItem.Name = "QuanLyNhanVienToolStripMenuItem";
            this.QuanLyNhanVienToolStripMenuItem.Size = new System.Drawing.Size(185, 23);
            this.QuanLyNhanVienToolStripMenuItem.Text = "QUẢN LÝ NHÂN VIÊN";
            this.QuanLyNhanVienToolStripMenuItem.Click += new System.EventHandler(this.qUẢNLÝNHÂNVIÊNToolStripMenuItem_Click);
            // 
            // sanPhamToolStripMenuItem
            // 
            this.sanPhamToolStripMenuItem.Name = "sanPhamToolStripMenuItem";
            this.sanPhamToolStripMenuItem.Size = new System.Drawing.Size(105, 23);
            this.sanPhamToolStripMenuItem.Text = "SẢN PHẨM";
            this.sanPhamToolStripMenuItem.Click += new System.EventHandler(this.sanPhamToolStripMenuItem_Click);
            // 
            // ThongTinCaNhanToolStripMenuItem
            // 
            this.ThongTinCaNhanToolStripMenuItem.Name = "ThongTinCaNhanToolStripMenuItem";
            this.ThongTinCaNhanToolStripMenuItem.Size = new System.Drawing.Size(188, 23);
            this.ThongTinCaNhanToolStripMenuItem.Text = "THÔNG TIN CÁ NHÂN";
            this.ThongTinCaNhanToolStripMenuItem.Click += new System.EventHandler(this.tHÔNGTINCÁNHÂNToolStripMenuItem_Click);
            // 
            // dangXuatToolStripMenuItem
            // 
            this.dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            this.dangXuatToolStripMenuItem.Size = new System.Drawing.Size(115, 23);
            this.dangXuatToolStripMenuItem.Text = "ĐĂNG XUẤT";
            this.dangXuatToolStripMenuItem.Click += new System.EventHandler(this.dangXuatToolStripMenuItem_Click);
            // 
            // DoiMatKhauToolStripMenuItem1
            // 
            this.DoiMatKhauToolStripMenuItem1.Name = "DoiMatKhauToolStripMenuItem1";
            this.DoiMatKhauToolStripMenuItem1.Size = new System.Drawing.Size(142, 23);
            this.DoiMatKhauToolStripMenuItem1.Text = "ĐỔI MẬT KHẨU";
            this.DoiMatKhauToolStripMenuItem1.Click += new System.EventHandler(this.DoiMatKhauToolStripMenuItem1_Click);
            // 
            // frmQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 450);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HoaDonBanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuanLyNhanVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sanPhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThongTinCaNhanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangXuatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HoaDonNhapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DoiMatKhauToolStripMenuItem1;
    }
}