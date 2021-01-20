namespace QUANCOFFE
{
    partial class frmHoaDonPhaChe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDonPhaChe));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgHoaDonBan = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dtgCTHoaDonBan = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnHoanThanh = new DevComponents.DotNetBar.ButtonX();
            this.txtMaHoaDon = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.MaHoaDonBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTHoaDonBan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSanPham1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DongGia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDonBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTHoaDonBan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(568, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "HÓA ĐƠN PHA CHẾ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgHoaDonBan);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 154);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 469);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa Đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgCTHoaDonBan);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(816, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 469);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết";
            // 
            // dtgHoaDonBan
            // 
            this.dtgHoaDonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHoaDonBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHoaDonBan,
            this.MaNhanVien,
            this.TenNhanVien1,
            this.NgayLap,
            this.TenKhachHang,
            this.TongTien});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHoaDonBan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgHoaDonBan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtgHoaDonBan.Location = new System.Drawing.Point(17, 19);
            this.dtgHoaDonBan.Name = "dtgHoaDonBan";
            this.dtgHoaDonBan.Size = new System.Drawing.Size(618, 444);
            this.dtgHoaDonBan.TabIndex = 3;
            this.dtgHoaDonBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHoaDonBan_CellClick);
            // 
            // dtgCTHoaDonBan
            // 
            this.dtgCTHoaDonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCTHoaDonBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTHoaDonBan1,
            this.MaSanPham1,
            this.SoLuong1,
            this.DongGia1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgCTHoaDonBan.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgCTHoaDonBan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtgCTHoaDonBan.Location = new System.Drawing.Point(25, 19);
            this.dtgCTHoaDonBan.Name = "dtgCTHoaDonBan";
            this.dtgCTHoaDonBan.Size = new System.Drawing.Size(493, 444);
            this.dtgCTHoaDonBan.TabIndex = 4;
            this.dtgCTHoaDonBan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCTHoaDonBan_CellContentClick);
            // 
            // btnHoanThanh
            // 
            this.btnHoanThanh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHoanThanh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHoanThanh.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoanThanh.Location = new System.Drawing.Point(647, 629);
            this.btnHoanThanh.Name = "btnHoanThanh";
            this.btnHoanThanh.Size = new System.Drawing.Size(205, 100);
            this.btnHoanThanh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHoanThanh.Symbol = "";
            this.btnHoanThanh.TabIndex = 5;
            this.btnHoanThanh.Text = "Hoàn Thành";
            this.btnHoanThanh.TextColor = System.Drawing.Color.Black;
            this.btnHoanThanh.Click += new System.EventHandler(this.btnHoanThanh_Click);
            // 
            // txtMaHoaDon
            // 
            // 
            // 
            // 
            this.txtMaHoaDon.Border.Class = "TextBoxBorder";
            this.txtMaHoaDon.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMaHoaDon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDon.Location = new System.Drawing.Point(697, 173);
            this.txtMaHoaDon.Name = "txtMaHoaDon";
            this.txtMaHoaDon.Size = new System.Drawing.Size(104, 22);
            this.txtMaHoaDon.TabIndex = 6;
            this.txtMaHoaDon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MaHoaDonBan
            // 
            this.MaHoaDonBan.DataPropertyName = "MaHoaDonBan";
            this.MaHoaDonBan.HeaderText = "Mã";
            this.MaHoaDonBan.Name = "MaHoaDonBan";
            this.MaHoaDonBan.Width = 80;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // TenNhanVien1
            // 
            this.TenNhanVien1.DataPropertyName = "TenNhanVien1";
            this.TenNhanVien1.HeaderText = "Tên Nhân Viên";
            this.TenNhanVien1.Name = "TenNhanVien1";
            this.TenNhanVien1.Width = 120;
            // 
            // NgayLap
            // 
            // 
            // 
            // 
            this.NgayLap.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window;
            this.NgayLap.BackgroundStyle.Class = "DataGridViewDateTimeBorder";
            this.NgayLap.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgayLap.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText;
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày Lập";
            this.NgayLap.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgayLap.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgayLap.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.NgayLap.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.NgayLap.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.NgayLap.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NgayLap.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên Khách Hàng";
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Width = 150;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.TongTien.DefaultCellStyle = dataGridViewCellStyle1;
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            // 
            // MaCTHoaDonBan1
            // 
            this.MaCTHoaDonBan1.DataPropertyName = "MaCTHoaDonBan1";
            this.MaCTHoaDonBan1.HeaderText = "Mã";
            this.MaCTHoaDonBan1.Name = "MaCTHoaDonBan1";
            // 
            // MaSanPham1
            // 
            this.MaSanPham1.DataPropertyName = "MaSanPham1";
            this.MaSanPham1.HeaderText = "Sản Phẩm";
            this.MaSanPham1.Name = "MaSanPham1";
            this.MaSanPham1.Width = 150;
            // 
            // SoLuong1
            // 
            this.SoLuong1.DataPropertyName = "SoLuong1";
            this.SoLuong1.HeaderText = "Số Lượng";
            this.SoLuong1.Name = "SoLuong1";
            // 
            // DongGia1
            // 
            this.DongGia1.DataPropertyName = "DongGia1";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.DongGia1.DefaultCellStyle = dataGridViewCellStyle3;
            this.DongGia1.HeaderText = "Đơn Giá";
            this.DongGia1.Name = "DongGia1";
            this.DongGia1.Width = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(709, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mã Hóa Đơn";
            // 
            // frmHoaDonPhaChe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 740);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaHoaDon);
            this.Controls.Add(this.btnHoanThanh);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHoaDonPhaChe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHoaDonPhaChe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHoaDonPhaChe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDonBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCTHoaDonBan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dtgHoaDonBan;
        private DevComponents.DotNetBar.Controls.DataGridViewX dtgCTHoaDonBan;
        private DevComponents.DotNetBar.ButtonX btnHoanThanh;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDonBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien1;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTHoaDonBan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DongGia1;
        private System.Windows.Forms.Label label2;
    }
}