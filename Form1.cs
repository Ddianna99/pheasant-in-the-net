using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fazan
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Joc game = new Joc();
            game.gameManager = new Manager(false);
            
            this.Hide();
            game.Show();

        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Joc game = new Joc();
            game.gameManager = new Manager(true);

            this.Hide();
            game.Show();
        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }
    }
}
