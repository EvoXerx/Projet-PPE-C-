using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {

        private String prenom;
        private String description;
        public Form3(String prenom, String description)
        {
            InitializeComponent();
            this.prenom = prenom;
            this.description = description;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lb2.Text = "Bonjour " + prenom + " vous êtes " + description;
        }

        private void deconnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
