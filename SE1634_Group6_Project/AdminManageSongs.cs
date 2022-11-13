using _6.Models;

namespace ProjectPRN211
{
    public partial class AdminManageSongs : Form
    {
        private readonly PrnProjectCuoiKy2Context _context;
        public AdminManageSongs()
        {
            InitializeComponent();
            _context = new PrnProjectCuoiKy2Context();
            //cbGenre.DataSource = _context.Songs.ToList();
            //cbGenre.DisplayMember = ""
            dataGridView1.DataSource = _context.Songs.ToList();
            dataGridView1.Columns["AuthorNavigation"].Visible = false;
            dataGridView1.Columns["ListSongs"].Visible = false;
            int count = dataGridView1.Columns.Count;
            DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            {
                Text = "Hide",
                Name = "Hide",
                UseColumnTextForButtonValue = true
            };
            dataGridView1.Columns.Insert(count, btnDetail);
        }
        void bindGrid()
        {
            dataGridView1.DataSource = _context.Songs.ToList();
            //dataGridView1.Columns["AuthorNavigation"].Visible = false;
            //dataGridView1.Columns["ListNumbers"].Visible = false;
            //int count = dataGridView1.Columns.Count;
            //DataGridViewButtonColumn btnDetail = new DataGridViewButtonColumn
            //{
            //    Text = "Hide",
            //    Name = "Hide",
            //    UseColumnTextForButtonValue = true
            //};
            //dataGridView1.Columns.Insert(count, btnDetail);
        }
        void bindGirdSearch(string name)
        {
           
                var songs =_context.Songs.Where(a => a.Name.Contains(name)).ToList();
            dataGridView1.DataSource = songs;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Hide"].Index)
            {
                int songNumber = (int)dataGridView1.Rows[e.RowIndex].Cells["SongNumber"].Value;
                Song song = _context.Songs.Find(songNumber);
                if(song.IsHide == true)
                {
                    song.IsHide = false;
                }
                else
                {
                    song.IsHide = true;
                }
                _context.Songs.Update(song);
                _context.SaveChanges();
                bindGrid();
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    AdminManageUsers form2 = new AdminManageUsers();
        //    form2.ShowDialog();
        //}

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            bindGirdSearch(name);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSongs form3 = new AddSongs();
            DialogResult dr = form3.ShowDialog();
            if (dr == DialogResult.OK)
                bindGrid();
        }
    }
}