namespace QUANCOFFE
{
    partial class frmHoaDonBan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoaDonBan));
            this.label1 = new System.Windows.Forms.Label();
            this.dtgHoaDonBan = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.MaHoaDonBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhanVien1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtNgayKetThuc = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtNgayBatDau = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.btnXoaHoaDon = new DevComponents.DotNetBar.ButtonX();
            this.btnThongKe = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDonBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayKetThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBatDau)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(549, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(364, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "HÓA ĐƠN BÁN";
            // 
            // dtgHoaDonBan
            // 
            this.dtgHoaDonBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHoaDonBan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHoaDonBan,
            this.TenNhanVien1,
            this.MaNhanVien,
            this.TenKhachHang,
            this.NgayLap,
            this.TongTien,
            this.GhiChu});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgHoaDonBan.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgHoaDonBan.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtgHoaDonBan.Location = new System.Drawing.Point(26, 25);
            this.dtgHoaDonBan.Name = "dtgHoaDonBan";
            this.dtgHoaDonBan.Size = new System.Drawing.Size(935, 439);
            this.dtgHoaDonBan.TabIndex = 1;
            this.dtgHoaDonBan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgHoaDonBan_CellClick);
            // 
            // MaHoaDonBan
            // 
            this.MaHoaDonBan.DataPropertyName = "MaHoaDonBan";
            this.MaHoaDonBan.HeaderText = "Mã";
            this.MaHoaDonBan.Name = "MaHoaDonBan";
            // 
            // TenNhanVien1
            // 
            this.TenNhanVien1.DataPropertyName = "TenNhanVien1";
            this.TenNhanVien1.HeaderText = "Nhân Viên";
            this.TenNhanVien1.Name = "TenNhanVien1";
            this.TenNhanVien1.Width = 150;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 130;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên Khách Hàng";
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Width = 150;
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
            this.NgayLap.CustomFormat = "dd/MM/yyyy";
            this.NgayLap.DataPropertyName = "NgayLap";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.NgayLap.DefaultCellStyle = dataGridViewCellStyle1;
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
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.TongTien.DefaultCellStyle = dataGridViewCellStyle2;
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Width = 120;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 200;
            // 
            // dtNgayKetThuc
            // 
            // 
            // 
            // 
            this.dtNgayKetThuc.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtNgayKetThuc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayKetThuc.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtNgayKetThuc.ButtonDropDown.Visible = true;
            this.dtNgayKetThuc.IsPopupCalendarOpen = false;
            this.dtNgayKetThuc.Location = new System.Drawing.Point(850, 140);
            // 
            // 
            // 
            this.dtNgayKetThuc.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNgayKetThuc.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayKetThuc.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtNgayKetThuc.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtNgayKetThuc.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtNgayKetThuc.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgayKetThuc.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtNgayKetThuc.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtNgayKetThuc.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtNgayKetThuc.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtNgayKetThuc.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayKetThuc.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.dtNgayKetThuc.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtNgayKetThuc.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNgayKetThuc.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtNgayKetThuc.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgayKetThuc.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtNgayKetThuc.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayKetThuc.MonthCalendar.TodayButtonVisible = true;
            this.dtNgayKetThuc.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtNgayKetThuc.Name = "dtNgayKetThuc";
            this.dtNgayKetThuc.Size = new System.Drawing.Size(150, 20);
            this.dtNgayKetThuc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtNgayKetThuc.TabIndex = 3;
            // 
            // dtNgayBatDau
            // 
            // 
            // 
            // 
            this.dtNgayBatDau.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtNgayBatDau.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayBatDau.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtNgayBatDau.ButtonDropDown.Visible = true;
            this.dtNgayBatDau.IsPopupCalendarOpen = false;
            this.dtNgayBatDau.Location = new System.Drawing.Point(535, 140);
            // 
            // 
            // 
            this.dtNgayBatDau.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNgayBatDau.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayBatDau.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtNgayBatDau.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtNgayBatDau.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtNgayBatDau.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgayBatDau.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtNgayBatDau.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtNgayBatDau.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtNgayBatDau.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtNgayBatDau.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayBatDau.MonthCalendar.DisplayMonth = new System.DateTime(2020, 7, 1, 0, 0, 0, 0);
            this.dtNgayBatDau.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.dtNgayBatDau.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.dtNgayBatDau.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtNgayBatDau.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtNgayBatDau.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtNgayBatDau.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtNgayBatDau.MonthCalendar.TodayButtonVisible = true;
            this.dtNgayBatDau.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.dtNgayBatDau.Name = "dtNgayBatDau";
            this.dtNgayBatDau.Size = new System.Drawing.Size(150, 20);
            this.dtNgayBatDau.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtNgayBatDau.TabIndex = 4;
            // 
            // btnXoaHoaDon
            // 
            this.btnXoaHoaDon.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoaHoaDon.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoaHoaDon.Location = new System.Drawing.Point(198, 668);
            this.btnXoaHoaDon.Name = "btnXoaHoaDon";
            this.btnXoaHoaDon.Size = new System.Drawing.Size(80, 50);
            this.btnXoaHoaDon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXoaHoaDon.Symbol = "";
            this.btnXoaHoaDon.TabIndex = 5;
            this.btnXoaHoaDon.Text = "Xóa Hóa Đơn";
            this.btnXoaHoaDon.TextColor = System.Drawing.Color.Black;
            this.btnXoaHoaDon.Click += new System.EventHandler(this.btnXoaHoaDon_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThongKe.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThongKe.Location = new System.Drawing.Point(1074, 117);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(80, 50);
            this.btnThongKe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThongKe.Symbol = "";
            this.btnThongKe.TabIndex = 6;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.TextColor = System.Drawing.Color.Black;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(429, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Từ Ngày :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(728, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Đến Ngày :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgHoaDonBan);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(172, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 470);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống Kê";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(276, 117);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(80, 50);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 10;
            this.buttonX1.Text = "Xem Tất Cả";
            this.buttonX1.TextColor = System.Drawing.Color.Black;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(1053, 668);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 50);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.Symbol = "";
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextColor = System.Drawing.Color.Black;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmHoaDonBan
            // 
            this.AcceptButton = this.btnThongKe;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 740);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoaHoaDon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtNgayBatDau);
            this.Controls.Add(this.dtNgayKetThuc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1, 0);
            this.Name = "frmHoaDonBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn Bán";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHoaDonBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgHoaDonBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayKetThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgayBatDau)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dtgHoaDonBan;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtNgayKetThuc;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtNgayBatDau;
        private DevComponents.DotNetBar.ButtonX btnXoaHoaDon;
        private DevComponents.DotNetBar.ButtonX btnThongKe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDonBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhanVien1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private DevComponents.DotNetBar.ButtonX btnThoat;
    }
}