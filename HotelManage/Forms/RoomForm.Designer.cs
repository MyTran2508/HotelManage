namespace HotelManage.Forms
{
    partial class RoomForm
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
            this.TbDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnInsert = new System.Windows.Forms.Button();
            this.GridViewRooms = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TBName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBKindOfRom = new System.Windows.Forms.ComboBox();
            this.CBRoomStatus = new System.Windows.Forms.ComboBox();
            this.BtnReload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // TbDescription
            // 
            this.TbDescription.Location = new System.Drawing.Point(15, 338);
            this.TbDescription.Name = "TbDescription";
            this.TbDescription.Size = new System.Drawing.Size(279, 31);
            this.TbDescription.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(247, 31);
            this.label7.TabIndex = 48;
            this.label7.Text = "Ghi Chú";
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("Cascadia Code SemiBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.Location = new System.Drawing.Point(15, 508);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(274, 36);
            this.BtnBack.TabIndex = 47;
            this.BtnBack.Text = "Trở lại";
            this.BtnBack.UseVisualStyleBackColor = true;
            // 
            // BtnRemove
            // 
            this.BtnRemove.Location = new System.Drawing.Point(15, 443);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(132, 36);
            this.BtnRemove.TabIndex = 46;
            this.BtnRemove.Text = "Xóa";
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.Location = new System.Drawing.Point(162, 389);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(132, 36);
            this.BtnEdit.TabIndex = 45;
            this.BtnEdit.Text = "Chỉnh sửa";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnInsert
            // 
            this.BtnInsert.Location = new System.Drawing.Point(15, 389);
            this.BtnInsert.Name = "BtnInsert";
            this.BtnInsert.Size = new System.Drawing.Size(132, 36);
            this.BtnInsert.TabIndex = 44;
            this.BtnInsert.Text = "Thêm";
            this.BtnInsert.UseVisualStyleBackColor = true;
            // 
            // GridViewRooms
            // 
            this.GridViewRooms.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GridViewRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewRooms.Location = new System.Drawing.Point(325, 88);
            this.GridViewRooms.Name = "GridViewRooms";
            this.GridViewRooms.RowHeadersWidth = 51;
            this.GridViewRooms.RowTemplate.Height = 24;
            this.GridViewRooms.Size = new System.Drawing.Size(642, 456);
            this.GridViewRooms.TabIndex = 43;
            this.GridViewRooms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridViewRooms_CellClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(15, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 31);
            this.label5.TabIndex = 41;
            this.label5.Text = "Tình Trạng";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 31);
            this.label4.TabIndex = 39;
            this.label4.Text = "Loại Phòng";
            // 
            // TBName
            // 
            this.TBName.Location = new System.Drawing.Point(15, 146);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(279, 31);
            this.TBName.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 31);
            this.label3.TabIndex = 37;
            this.label3.Text = "Tên Phòng";
            // 
            // TBId
            // 
            this.TBId.Location = new System.Drawing.Point(15, 88);
            this.TBId.Name = "TBId";
            this.TBId.Size = new System.Drawing.Size(279, 31);
            this.TBId.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 31);
            this.label2.TabIndex = 35;
            this.label2.Text = "Mã Phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(354, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 44);
            this.label1.TabIndex = 34;
            this.label1.Text = "Quản Lý Phòng";
            // 
            // CBKindOfRom
            // 
            this.CBKindOfRom.FormattingEnabled = true;
            this.CBKindOfRom.Location = new System.Drawing.Point(15, 210);
            this.CBKindOfRom.Name = "CBKindOfRom";
            this.CBKindOfRom.Size = new System.Drawing.Size(279, 35);
            this.CBKindOfRom.TabIndex = 50;
            // 
            // CBRoomStatus
            // 
            this.CBRoomStatus.FormattingEnabled = true;
            this.CBRoomStatus.Location = new System.Drawing.Point(15, 278);
            this.CBRoomStatus.Name = "CBRoomStatus";
            this.CBRoomStatus.Size = new System.Drawing.Size(279, 35);
            this.CBRoomStatus.TabIndex = 51;
            // 
            // BtnReload
            // 
            this.BtnReload.Location = new System.Drawing.Point(162, 443);
            this.BtnReload.Name = "BtnReload";
            this.BtnReload.Size = new System.Drawing.Size(132, 36);
            this.BtnReload.TabIndex = 52;
            this.BtnReload.Text = "Tải Lại";
            this.BtnReload.UseVisualStyleBackColor = true;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 587);
            this.Controls.Add(this.BtnReload);
            this.Controls.Add(this.CBRoomStatus);
            this.Controls.Add(this.CBKindOfRom);
            this.Controls.Add(this.TbDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnRemove);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnInsert);
            this.Controls.Add(this.GridViewRooms);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Phòng";
            this.Load += new System.EventHandler(this.RoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnInsert;
        private System.Windows.Forms.DataGridView GridViewRooms;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBKindOfRom;
        private System.Windows.Forms.ComboBox CBRoomStatus;
        private System.Windows.Forms.Button BtnReload;
    }
}