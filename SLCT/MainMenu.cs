using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLCT
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;   
            this.StartPosition = FormStartPosition.Manual; 
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            CategoryMenu categoryMenu = new CategoryMenu();

            categoryMenu.StartPosition = FormStartPosition.Manual;
            categoryMenu.Location = this.Location;
            categoryMenu.Size = this.Size;
            categoryMenu.WindowState = this.WindowState;

            categoryMenu.Show();
            this.Hide();
        }
    }
}
