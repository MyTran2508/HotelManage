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
using HotelManage.Resources.Utils;

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


        // Fill ComboBox KindOfRooms
        private void FillComboBoxKindOfRooms()
        {
            var kindOfRooms = kor.GetAllKindOfRooms();
            DataTable dt = Common.FillDataTable(kindOfRooms);
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
            DataTable dt = Common.FillDataTable(roomSta);
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
                DataTable dt = Common.GetDataTable(
                    "Mã TT", 
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

        private void FillTextBox()
        {
            int currentRow = Common.GetCurrentRowSelected(this.GridViewRooms);
            if(currentRow != -1)
            {
                TBId.Text = Common.
                GetValueOfCellGridView(this.GridViewRooms, currentRow, 0);
                TBName.Text = Common.
                    GetValueOfCellGridView(this.GridViewRooms, currentRow, 3);
                TbDescription.Text = Common.
                    GetValueOfCellGridView(this.GridViewRooms, currentRow, 4);
            }
        }

        // Form Load
        private void RoomForm_Load(object sender, EventArgs e)
        {
            this.FillComboBoxKindOfRooms();
            this.FillComboBoxRoomStatus();
            this.FillDataGridViewRooms();
            this.FillTextBox();
        }

        // Event handler
        // Remove Room
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                // Get current Index
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewRooms);
                // Get Id
                string Id = Common.
                    GetValueOfCellGridView(this.GridViewRooms, rowIndex, 0);

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
                int rowIndex = Common.GetCurrentRowSelected(this.GridViewRooms);

                // Get Values
                string id = Common.
                    GetValueOfCellGridView(this.GridViewRooms, rowIndex, 0);
                string name = Common.GetValueTextBox(TBName);
                string description = Common.GetValueTextBox(TbDescription);
                string kindOfRoomId = Common.GetValueComboBox(CBKindOfRom);
                string roomStatusId = Common.GetValueComboBox(CBRoomStatus);

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

        private void BtnInsert_Click(object sender, EventArgs e)
        {

        }
    }
}
