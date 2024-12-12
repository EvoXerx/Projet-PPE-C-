using MySql.Data.MySqlClient;
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

    public partial class Form1 : Form
    {
        private string Provider = "localhost";
        private string DataBase = "medoc2";
        private string Uid = "root";
        private string Mdp = "";
        private ConnexionSql maConnexionSql;
        private MySqlCommand maRequete;
        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      
  

        private void button1_Click(object sender, EventArgs e)
        {
            maConnexionSql = ConnexionSql.getInstance("localhost", "medoc2", "root", "");
            
            maConnexionSql.OpenConnexion();
            maRequete = maConnexionSql.reqExec("Select prenom, description from personnel INNER JOIN fonction ON fonction.id_fonction=personnel.id_fonction where login = '" + test(tb1.Text) + "' and mdp ='"+ test(tb2.Text) +"'");
            MySqlDataReader nomReader = maRequete.ExecuteReader();
            
            
            if (nomReader.HasRows )
            {
                nomReader.Read();
                // Récupération de la valeur d’un champ selon son type et son ordre dans la requête
                String prenom = nomReader.GetString(0);
                String description = nomReader.GetString(1);
               
               if (description == "Visiteur"){
                    Form2 f2 = new Form2(prenom, description);
                    f2.ShowDialog();
                    this.Hide();

                   

                }
               else if (description == "Comptable")
                {
                    Form3 f3 = new Form3(prenom, description);
                    f3.ShowDialog();
                    this.Hide();

                }

                else
                {
                    MessageBox.Show("Vous n'êtes pas éligible à l'application!");
                }

            }
            else 
            {
                MessageBox.Show("Erreur login/mot de passe. Connexion impossible!");
            }
            nomReader.Close();
            maConnexionSql.CloseConnexion();


        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {

        }
        private string test(string txt)
        {

            return txt.Replace("'", "''");
        }

    }
}
