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

namespace Ass2_SE1634_Group6
{
    public partial class Register : Form
    {
        private  PrnProjectCuoiKy2Context _context = new();
        public List<User> users = new();
        public Register()
        {
            InitializeComponent();
            textBox1.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void Register_Load(object sender, EventArgs e)
        {
            //textBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();
            Boolean userExist = false;

            User Account = new()
            {
                UserName = user,
                Password = pass,
                Role=2,
            };
            users.Add(Account);
            //kiem tra du kieu trung lap

            //neu trung lap
            _context = new PrnProjectCuoiKy2Context();
            users = _context.Users.Where(x => true).ToList();
            foreach (User u in users)
            {
                if(u.UserName == user)
                {
                    userExist = true;
                    MessageBox.Show("This name has taken, please choose other name");

                }
            }   
            if (userExist == false)
            {
                MessageBox.Show("Create Account success");
                textBox1.Text = user + "/" + pass;
                _context.Users.Add(Account);
                //tao favorite list cho cai account nay
                _context.Lists.Add(new List() { Author = Account.UserName, Title = "falorite list" });
                _context.SaveChanges();
                this.Close();
            }

            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
