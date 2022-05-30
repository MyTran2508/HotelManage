using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer.Controllers;

namespace HotelManage.Forms
{
    public partial class RoomForm : Form
    {

        KindOfRoomController kor = null;
        RoomController rc = null;
        RoomStatusController rsc = null;

        public RoomForm()
        {
            InitializeComponent();
            kor = new KindOfRoomController();
            rc = new RoomController();  
            rsc = new RoomStatusController();
        }

        // Get DataTable
        private DataTable GetDataTable(params string[] labels)
        {
            DataTable dt = new DataTable(); 
            foreach(var label in labels)
            {
                dt.Columns.Add(label, typeof(string));
            }
            return dt;
        }

        // Fill Data ComboBox (Kind Of Room, Room Status)
        private DataTable FillDataTable(dynamic s)
        {
            if(s != null)
            {
                string labelId = "Id", labelName = "Name";
                DataTable dt = GetDataTable(labelId, labelName);

                foreach (var k in s)
                {
                    dt.Rows.Add(k.Id, k.Name);
                }
                return dt;
            }
            return null;
        }

        // Fill ComboBox KindOfRooms
        private void FillComboBoxKindOfRooms()
        {
            var kindOfRooms = kor.GetAllKindOfRooms();
            DataTable dt = FillDataTable(kindOfRooms);
            if(dt != null)
            {
                CBKindOfRom.DataSource = dt;
                CBKindOfRom.DisplayMember = "Name"; 
                CBKindOfRom.ValueMember = "Id";  
            }
        }

        // Fill ComboBox RoomStatus
        private void FillComboBoxRoomStatus()
        {
            var roomSta = rsc.GetAllRoomsStatus();
            DataTable dt = FillDataTable(roomSta);
            if (dt != null)
            {
                CBRoomStatus.DataSource = dt;
                CBRoomStatus.DisplayMember = "Name";
                CBRoomStatus.ValueMember = "Id";
            }
        }

        // Fill Data Grid View
        private void FillDataGridViewRooms()
        {
            string error = "";
            var rooms = rc.GetAllRooms(ref error);
            if(rooms != null)
            {
                DataTable dt = GetDataTable(
                    "MP", 
                    "Loại Phòng",
                    "Tình Trạng", 
                    "Tên Phòng", 
                    "Ghi Chú");

                foreach (var ro in rooms)
                {
                    if (ro.KindOfRoom != null)
                    {
                        var kindOfRoom = ro.KindOfRoom.Name;
                        var roomStatus = ro.RoomStatus.Name;
                        dt.Rows.Add(ro.Id, kindOfRoom, roomStatus, ro.Name, ro.Description);
                    }
                }
                GridViewRooms.DataSource = dt;
                this.GridViewRooms.Columns[0].Width = 70;
                this.GridViewRooms.Columns[1].Width = 130;
                this.GridViewRooms.Columns[2].Width = 150;
                this.GridViewRooms.Columns[3].Width = 130;
            }
        }

        // Get Current Row Selected
        private int GetCurrentRowSelected()
        {
            int rowIndex = this.GridViewRooms.CurrentCell.RowIndex;
            return rowIndex;
        }

        // Get Value Of Cell
        private string GetValueOfCellGridView(int RowIndex, int CellIndex)
        {
            return this.GridViewRooms.
                Rows[RowIndex].Cells[CellIndex].
                Value.ToString().Trim();
        }

        // Get Value TextBox
        private string GetValueTextBox(TextBox tb)
        {
            return tb.Text.Trim();
        }

        // Get Value ComboBox
        private string GetValueComboBox(ComboBox cb)
        {
            return cb.SelectedValue.ToString().Trim();
        }

        private void FillTextBox()
        {
            int currentRow = this.GetCurrentRowSelected();
            TBId.Text = this.GetValueOfCellGridView(currentRow, 0);
            TBName.Text = this.GetValueOfCellGridView(currentRow, 3);
            TbDescription.Text = this.GetValueOfCellGridView(currentRow, 4);
        }

        // Form Load
        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.FillComboBoxKindOfRooms();
            this.FillComboBoxRoomStatus();
            this.FillDataGridViewRooms();
            this.FillTextBox();
            /* // Create Room Status
             rsc.InsertRoomStatus("RST1", "Trống");
             rsc.InsertRoomStatus("RST2", "Đang Sử Dụng");

             // Insert Kind Of Room
             kor.InsertKindOfRooms("KOR1", "Hạng A", 2, 500);
             kor.InsertKindOfRooms("KOR2", "Hạng B", 5, 700);
             kor.InsertKindOfRooms("KOR3", "Hạng C", 10, 1000);*/


            /*  rc.InsertRoom(ref error, "ROO2", k1, rs1, "102");
            //rc.InsertRoom(ref error, "ROO3", k1, rs1, "103");*/


            /*this.FillComboBoxKindOfRooms();
            this.FillComboBoxRoomStatus();
            this.FillDataGridViewRooms();*/
        }

        // Event handler
        // Remove Room
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current Index
                int rowIndex = this.GetCurrentRowSelected();
                // Get Id
                string Id = this.GetValueOfCellGridView(rowIndex, 0);

                // remove
                string error = "";
                bool isDeleted = rc.RemoveRoom(ref error, Id);
                if(isDeleted)
                {
                    this.FillDataGridViewRooms();
                }
                MessageBox.Show(error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Edit Room
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current Index
                int rowIndex = this.GetCurrentRowSelected();

                // Get Values
                string id = this.GetValueOfCellGridView(rowIndex, 0);
                string name = this.GetValueTextBox(TBName);
                string description = this.GetValueTextBox(TbDescription);
                string kindOfRoomId = this.GetValueComboBox(CBKindOfRom);
                string roomStatusId = this.GetValueComboBox(CBRoomStatus);

                string error = "";
                bool isUpdated = rc.UpdateRoom(ref error, id, kindOfRoomId, roomStatusId, name, description);
                if(isUpdated)
                {
                    this.FillDataGridViewRooms();
                    this.FillComboBoxKindOfRooms();
                    this.FillComboBoxRoomStatus();
                }
                MessageBox.Show(error);
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.FillTextBox();
        }
    }
}
