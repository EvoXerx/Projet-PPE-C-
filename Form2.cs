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
            maRequete = maConnexionSql.reqExec("Select avoir.quantite from forfait INNER JOIN avoir ON avoir.id_forfait = forfait.id_forfait where avoir.matricule = 'SCH/189-02' and avoir.annee_mois = '2024/10' and forfait.libelle = 'Repas au midi'");
            MySqlDataReader nomReader = maRequete.ExecuteReader();
            nomReader.Read();
            int Nbrepas = nomReader.GetInt16(0);
            nomReader.Close();
            maRequete = maConnexionSql.reqExec("Select avoir.quantite from forfait INNER JOIN avoir ON avoir.id_forfait = forfait.id_forfait where avoir.matricule = 'SCH/189-02' and avoir.annee_mois = '2024/10' and forfait.libelle = 'nuitee'");
            MySqlDataReader nomReader2 = maRequete.ExecuteReader();
            nomReader2.Read();
            int Nbnuitee = nomReader2.GetInt16(0);
            nomReader2.Close();
            maRequete = maConnexionSql.reqExec("Select avoir.quantite from forfait INNER JOIN avoir ON avoir.id_forfait = forfait.id_forfait where avoir.matricule = 'SCH/189-02' and avoir.annee_mois = '2024/10' and forfait.libelle = 'etape'");
            MySqlDataReader nomReader3 = maRequete.ExecuteReader();
            nomReader3.Read();
            int Nbetape = nomReader3.GetInt16(0);
            nomReader3.Close();
            maRequete = maConnexionSql.reqExec("Select avoir.quantite from forfait INNER JOIN avoir ON avoir.id_forfait = forfait.id_forfait where avoir.matricule = 'SCH/189-02' and avoir.annee_mois = '2024/10' and forfait.libelle = 'KM'");
            MySqlDataReader nomReader4 = maRequete.ExecuteReader();
            nomReader4.Read();
            int Nbkm = nomReader4.GetInt16(0);
            nomReader4.Close();
            maRequete = maConnexionSql.reqExec("Select etat_fiche_de_frais.description, fiche_frais.date_modif  from fiche_frais INNER JOIN etat_fiche_de_frais ON fiche_frais.id_etat_fiche_de_frais = etat_fiche_de_frais.id_etat_fiche_de_frais where fiche_frais.matricule = 'SCH/189-02' and fiche_frais.annee_mois = '2024/10'");
            MySqlDataReader nomReader5 = maRequete.ExecuteReader();
            nomReader5.Read();
            string Situation = nomReader5.GetString(0);
            DateTime Dateop = nomReader5.GetDateTime(1);
            nomReader5.Close();

            

            DataTable fiche_frais= new DataTable();
            // Ajout des titres des colonnes de la DataTable
            fiche_frais.Columns.Add("Repas Midi");
            fiche_frais.Columns.Add("Nuitée");
            fiche_frais.Columns.Add("Etape");
            fiche_frais.Columns.Add("Km");
            fiche_frais.Columns.Add("Situation");
            fiche_frais.Columns.Add("Date opération");

            maRequete = maConnexionSql.reqExec("Select hors_forfait.annee_mois, hors_forfait.libelleHF, hors_forfait.prix, etat_fiche_de_frais.description, hors_forfait.date_hf from hors_forfait JOIN fiche_frais ON hors_forfait.annee_mois = fiche_frais.annee_mois and hors_forfait.matricule = fiche_frais.matricule INNER JOIN etat_fiche_de_frais ON fiche_frais.id_etat_fiche_de_frais = etat_fiche_de_frais.id_etat_fiche_de_frais where fiche_frais.matricule =" + matricule + " and fiche_frais.annee_mois =" + dtp1);
            MySqlDataReader nomReader6 = maRequete.ExecuteReader();
            nomReader6.Read();
            string Hdate = nomReader6.GetString(0);
            string Hdescription = nomReader6.GetString(1);
            float Hmontant = nomReader6.GetFloat(2);
            string Hsituation = nomReader6.GetString(3);
            DateTime Hdateop = nomReader6.GetDateTime(4);
            nomReader6.Close();

            DataTable hors_forfait = new DataTable();
            hors_forfait.Columns.Add("Date");
            hors_forfait.Columns.Add("Libellé");
            hors_forfait.Columns.Add("Montant");
            hors_forfait.Columns.Add("Situation");
            hors_forfait.Columns.Add("Date opération");






            DataRow nomLigne = fiche_frais.NewRow();
                // Récupération de la valeur d’un champ selon son type et son ordre dans la requête
                nomLigne[0] = Nbrepas;
                nomLigne[1] = Nbnuitee;
                nomLigne[2] = Nbetape;
                nomLigne[3] = Nbkm;
                nomLigne[4] = Situation;
                nomLigne[5] = Dateop;
                fiche_frais.Rows.Add(nomLigne);
            

                dataGridView1.DataSource = fiche_frais;



            DataRow nomColonne = hors_forfait.NewRow();
            // Récupération de la valeur d’un champ selon son type et son ordre dans la requête
            nomColonne[0] = Hdate;
            nomColonne[1] = Hdescription;
            nomColonne[2] = Hmontant;
            nomColonne[3] = Hsituation;
            nomColonne[4] = Hdateop;
            hors_forfait.Rows.Add(nomColonne);

            dataGridView2.DataSource = hors_forfait;



        }
  
    }
}
