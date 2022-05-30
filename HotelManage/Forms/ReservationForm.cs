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
    public partial class ReservationForm : Form
    {
        RoomController rc = null;
        public ReservationForm()
        {
            InitializeComponent();
            rc = new RoomController();
        }

        // Fill ComboBox KindOfRooms
        private void FillComboBoxKindOfRooms()
        {
            string roomSta = "RST1";
            string error = "";
            var rooms = rc.GetRoomsByRoomStatusId(roomSta, ref error);
            DataTable dt = Common.FillDataTable(rooms);
            if (dt != null)
            {
                CBRooms.DataSource = dt;
                CBRooms.DisplayMember = "Name";
                CBRooms.ValueMember = "Id";
            }
        }

        // Event handler
        private void ReservationForm_Load(object sender, EventArgs e)
        {
            this.FillComboBoxKindOfRooms();
        }
    }
}
