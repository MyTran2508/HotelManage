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

namespace HotelManage
{
    public partial class RoomStatusForm : Form
    {
        RoomStatusController rsc = null;
        
        public RoomStatusForm()
        {
            InitializeComponent();
            rsc = new RoomStatusController();
        }

        private void ClearAllTextBox()
        {
            TBId.ResetText();
            TBName.ResetText();
            TBId.Focus();
        }

        // Get datatable fill in DataGrid
        private void FillDataGrid()
        {
            var rs = rsc.GetAllRoomsStatus();
            if (rs != null)
            {
                DataTable dt = Common.GetDataTable("Mã TT", "Tên TT");
                if(dt != null)
                {
                    foreach (var r in rs)
                    {
                        dt.Rows.Add(r.Id, r.Name);
                    }
                    GridViewRoomStatus.DataSource = dt;
                    /*this.GridViewRooms.Columns[0].Width = 70;
                    this.GridViewRooms.Columns[1].Width = 130;
                    this.GridViewRooms.Columns[2].Width = 150;
                    this.GridViewRooms.Columns[3].Width = 130;*/
                }
                
            }
        }



        private void RoomStatusForm_Load(object sender, EventArgs e)
        {
            this.ClearAllTextBox();
            this.FillDataGrid();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = TBId.Text;
                string Name = TBName.Text;

                string error = "";
                bool isCreated = rsc.InsertRoomStatus(Id, Name, ref error);
                if (isCreated)
                {
                    // Refresh Data
                    this.FillDataGrid();

                    // Clear Text Box If Insert success
                    this.ClearAllTextBox();
                }
                MessageBox.Show(error);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = TBId.Text;
                string Name = TBName.Text;
                string error = "";
                bool isUpdated = rsc.
                    UpdateRoomStatusById(Id, Name, ref error);

                if (isUpdated)
                {
                    this.ClearAllTextBox();
                    this.FillDataGrid();
                }
                    MessageBox.Show(error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewRoomStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get Value of current row
            int rowIndex = Common.GetCurrentRowSelected(this.GridViewRoomStatus);
            if(rowIndex != -1)
            {
                string Id = Common.
                    GetValueOfCellGridView(GridViewRoomStatus, rowIndex, 0);
                string Name = Common.
                    GetValueOfCellGridView(GridViewRoomStatus, rowIndex, 1);

                this.TBId.Text = Id;
                this.TBName.Text = Name;
            }
           
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            // Get Value of current row
            int rowIndex = Common.GetCurrentRowSelected(this.GridViewRoomStatus);
            if (rowIndex != -1)
            {
                string Id = Common.
                    GetValueOfCellGridView(GridViewRoomStatus, rowIndex, 0);
                string error = "";
                bool isDeleted = rsc.RemoveRoomStatusById(Id, ref error);
                if (isDeleted)
                {
                    this.FillDataGrid();
                }
                MessageBox.Show(error);
            }
        }
    }
}
