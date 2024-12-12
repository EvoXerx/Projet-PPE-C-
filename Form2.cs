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
    public partial class Form2 : Form
    {
        private String prenom;
        private String matricule;
        private string provider = "localhost";
        private string dataBase = "medoc2";
        private string uid = "root";
        private string mdp = "";
        private ConnexionSql maConnexionSql;
        private MySqlCommand maRequete; 
        
        public Form2(String prenom, String matricule)
        {
            InitializeComponent();

            this.prenom = prenom;
            this.matricule = matricule;
            
            
        }






        private void Form2_Load_1(object sender, EventArgs e)
        {
            lb1.Text = "Bonjour " + prenom ;
            dtp1.Format = DateTimePickerFormat.Custom;
            dtp1.CustomFormat = "MM/yyyy";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void decconexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            maConnexionSql = ConnexionSql.getInstance("localhost", "medoc2", "root", "");
            maConnexionSql.OpenConnexion();
            maRequete = maConnexionSql.reqExec("Select * from fiche_frais INNER JOIN hors_forfait ON fiche_frais.annee_mois=hors_forfait.annee_mois and fiche_frais.matricule=hors_forfait.matricule  INNER JOIN avoir ON fiche_frais.annee_mois=avoir.annee_mois and fiche_frais.matricule=avoir.matricule and fiche_frais INNER JOIN forfait ON avoir.id_forfait=forfait.id_forfait INNER JOIN etat_fiche_de_frais ON fiche_frais.id_etat_fiche_de_frais=etat_fiche_de_frais.id_etat_fiche_de_frais  where annee_mois='"+dtp1.Value+"'");
            MySqlDataReader nomReader = maRequete.ExecuteReader();
            DataTable fiche_frais= new DataTable();
            // Ajout des titres des colonnes de la DataTable
            fiche_frais.Columns.Add("Repas Midi");
            fiche_frais.Columns.Add("Nuitée");
            fiche_frais.Columns.Add("Etape");
            fiche_frais.Columns.Add("Km");
            fiche_frais.Columns.Add("Situation");
            fiche_frais.Columns.Add("Date opération");
       


            while (nomReader.Read())
            {
                DataRow nomLigne = fiche_frais.NewRow();
                // Récupération de la valeur d’un champ selon son type et son ordre dans la requête
                nomLigne[0] = nomReader.GetString(0);
                nomLigne[1] = nomReader.GetString(1);
                nomLigne[2] = nomReader.GetString(2);
                nomLigne[3] = nomReader.GetString(3);
                nomLigne[4] = nomReader.GetString(4);
                fiche_frais.Rows.Add(nomLigne);
            }

                nomDataGridView.DataSource = fiche_frais;
        }
  
    }
}
