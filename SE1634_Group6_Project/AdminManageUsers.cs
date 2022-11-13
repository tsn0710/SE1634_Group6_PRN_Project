using _6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPRN211
{
    public partial class AdminManageUsers : Form
    {
        private readonly PrnProjectCuoiKy2Context _context;

        public AdminManageUsers()
        {
            InitializeComponent();
            _context = new PrnProjectCuoiKy2Context();
            dataGridView1.DataSource = _context.Users.ToList();
            dataGridView1.Columns["Lists"].Visible = false;
            dataGridView1.Columns["Songs"].Visible = false;
            int count = dataGridView1.Columns.Count;
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Text = "Ban",
                Name = "Ban",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnDetail);
        }
        void bindGrid()
        {
            dataGridView1.DataSource = _context.Users.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Ban"].Index)
            {
                string userName = dataGridView1.Rows[e.RowIndex].Cells["userName"].Value.ToString();
                User user = _context.Users.Find(userName);
                if (user.Role != 1)
                {
                    if (user.Role == 2)
                    {
                        user.Role = 3;
                    }else if (user.Role == 3)
                    {
                        user.Role = 2;
                    }
                    else
                    {
                        user.Role = 3;
                    }

                    _context.Users.Update(user);
                    _context.SaveChanges();
                }
                bindGrid();
            }
        }
        void bindGirdSearch(string userName)
        {

            var songs = _context.Users.Where(a => a.UserName.Contains(userName)).ToList();
            dataGridView1.DataSource = songs;
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    //string userName = txtUserName.Text;
        //    //bindGirdSearch(userName);
        //}

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            bindGirdSearch(userName);
        }
    }
}
