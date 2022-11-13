using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _6;
using _6.Models;
using Ass2_SE1634_Group6;

namespace User_MusicStore
{
    public partial class Login : Form
    {
        PrnProjectCuoiKy2Context _context = new();
        public Login()
        {
            InitializeComponent();
            _context = new PrnProjectCuoiKy2Context();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _context = new PrnProjectCuoiKy2Context();
            var users = _context.Users.Select(x => new {x.UserName, x.Password, x.Role });
            var user = users.Where(user => user.UserName.Equals(textBox1.Text) && user.Password.Equals(textBox2.Text));
            //User user1 = (User)users.Where(user => user.UserName.Equals(textBox1.Text) && user.Password.Equals(textBox2.Text));
            User user1 = (User)_context.Users.Find(textBox1.Text);
            if (user.Count() == 0)
            {
                MessageBox.Show("the member does not exist");
            }else if (user1.Role == 3)
            {
                MessageBox.Show("your account was baned from system");
            }
            else
            {
                UserNow.thisUser = user1;
                MessageBox.Show("Login sucessfully!!");          
                Form99 form1 = new Form99();
                form1.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register rgt = new Register();
            rgt.ShowDialog();
            
        }
    }
}
