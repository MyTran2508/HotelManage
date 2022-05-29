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
using DTO.Entities;
using DTO;

namespace HotelManage.Forms
{
    public partial class ServiceForm : Form
    {
        // Make service controller
        ServiceController sc = null;
        public ServiceForm()
        {
            InitializeComponent();
            this.sc = new ServiceController();
        }

        // Create Datatable 
        private DataTable GetDataTable(List<Service> services)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã DV", typeof(string));
            table.Columns.Add("Tên Dịch Vụ", typeof(string));
            table.Columns.Add("Đơn Giá", typeof(string));

            foreach (var service in services)
            {
                table.Rows.Add(service.Id, service.Name, service.Price);
            }
           return table;
        }

        // Get datatable fill in DataGrid
        private void FillDataGrid()
        {
            string error = "";
            var services = sc.GetAllServices(ref error);

            // Return databale 
            var dt = this.GetDataTable(services);
            this.DataGridService.DataSource = dt;

            // Set Width Column (Tên Dịch Vụ) = 200
            this.DataGridService.Columns[1].Width = 200;
        }


        private void ClearAllTextBox()
        {
            TextBoxId.ResetText();
            TextBoxName.ResetText();
            TextBoxPrice.ResetText();
            TextBoxId.Focus();
        }

        private string GetValueOfCellDataGrid(int rowIndex, int columnIndex)
        {
            string value = DataGridService.
                Rows[rowIndex].Cells[columnIndex].
                Value.ToString();
            return value;
        }
       
        private void ServiceForm_Load(object sender, EventArgs e)
        {
            this.ClearAllTextBox();
            this.FillDataGrid();
        }

        private void DataGridService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = DataGridService.CurrentCell.RowIndex;
            // Get Value of current row
            string Id = GetValueOfCellDataGrid(rowIndex, 0);
            string Name = GetValueOfCellDataGrid(rowIndex, 1);
            string Price = GetValueOfCellDataGrid(rowIndex, 2);

            this.TextBoxId.Text = Id;
            this.TextBoxName.Text = Name;
            this.TextBoxPrice.Text = Price; 
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = TextBoxId.Text;
                string Name = TextBoxName.Text;
                float Price = float.Parse(TextBoxPrice.Text);

                string error = "";
                bool isCreated = sc.AddNewService(Id, Name, Price, ref error);
                if(isCreated)
                {
                    // Refresh Data
                    this.FillDataGrid();

                    // Clear Text Box If Insert success
                    this.ClearAllTextBox();
                }
                else
                {
                    MessageBox.Show("Thêm Không Thành Công");
                }
            }
            catch
            {
                MessageBox.Show("Đã Xảy Ra Lỗi, Vui Lòng Thử Lại");
            }

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            int rowIndex = DataGridService.CurrentCell.RowIndex;
            string Id = DataGridService.Rows[rowIndex].Cells[0].Value.ToString();

            string error = "";
            bool isDeleted = sc.RemoveServiceById(Id, ref error);
            if(isDeleted)
            {
                this.FillDataGrid();
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.ClearAllTextBox();
            this.FillDataGrid();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string Id = TextBoxId.Text;
                string Name = TextBoxName.Text;
                float Price = float.Parse(TextBoxPrice.Text);
                string error = "";
                bool isUpdated = sc.
                    UpdateServiceById(Id, Name, Price, ref error);

                if (isUpdated)
                {
                    this.ClearAllTextBox();
                    this.FillDataGrid();
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            catch
            {
                MessageBox.Show("Update Service failure!!!");
            }
            
            
        }
    }
}
