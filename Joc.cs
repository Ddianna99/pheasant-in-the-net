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
    public partial class Joc : Form
    {
        public Manager gameManager;
        public Joc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameManager.Turn(textBox1.Text);
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameManager.Stuck();
            textBox1.Clear();
        }

        private void Joc_Load(object sender, EventArgs e)
        {
            gameManager.Initialize(label1, label3, label5);
        }
    }
}
