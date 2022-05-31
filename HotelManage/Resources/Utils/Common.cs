using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManage.Resources.Utils
{
    public class Common
    {

        // Fill Data ComboBox (Kind Of Room, Room Status)
        public static DataTable FillDataTable(dynamic s)
        {
            if (s != null)
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

        // Get DataTable
        public static DataTable GetDataTable(params string[] labels)
        {
            DataTable dt = new DataTable();
            foreach (var label in labels)
            {
                dt.Columns.Add(label, typeof(string));
            }
            return dt;
        }

        // Get Current Row Selected
        public static int GetCurrentRowSelected(DataGridView dgv)
        {
            try
            {
                if(dgv.CurrentCell != null)
                {
                    int rowIndex = dgv.CurrentCell.RowIndex;
                    return rowIndex;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
            
        }

        // Get Value Of Cell
        public static string GetValueOfCellGridView
        (
            DataGridView dgv, 
            int RowIndex, 
            int CellIndex
        )
        {
            return dgv.
                Rows[RowIndex].Cells[CellIndex].
                Value.ToString().Trim();
        }

        // Get Value TextBox
        public static string GetValueTextBox(TextBox tb)
        {
            return tb.Text.Trim();
        }

        // Get Value ComboBox
        public static string GetValueComboBox(ComboBox cb)
        {
            return cb.SelectedValue.ToString().Trim();
        }
    }
}
