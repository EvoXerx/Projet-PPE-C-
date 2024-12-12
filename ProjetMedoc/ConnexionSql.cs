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

public class ConnexionSql
{
	private static ConnexionSql connexion = null;
	private MySqlConnection cnx;
	private string connString;
	/**
	* Constructeur privé car appelé par getInstance
	*/
	private ConnexionSql(string unProvider, string uneDataBase, string unUid, string
   unMdp)
	{
		Initialize(unProvider, uneDataBase, unUid, unMdp);
	}

	/**
	* Initialisation de la connexion avec les paramètres de connexion
	*/
	private void Initialize(string unProvider, string uneDataBase, string unUid, string
   unMdp)
	{
		try
		{
			connString = "SERVER=" + unProvider + ";" + "DATABASE=" +
			uneDataBase + ";" + "UID=" + unUid + ";" + "PASSWORD=" + unMdp + ";";
			try
			{
				cnx = new MySqlConnection(connString);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message);
		}
	}
	/**
	* méthode de création d'une instance de connexion si elle n'existe pas (singleton)
	*/
	public static ConnexionSql getInstance(string unProvider, string uneDataBase, string
   unUid, string unMdp)
	{
		try
		{
			if (connexion == null)
			{ // Premier appel
				connexion = new ConnexionSql(unProvider, uneDataBase, unUid, unMdp);
			}
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message);
		}
		return connexion;
	}
	/**
	* Récupération de la connexion
	*/
	public MySqlConnection getConnexion()
	{
		return (this.cnx);
	}
	/**
	* Ouverture de la connexion
	*/
	public void OpenConnexion()
	{
		try
		{
			cnx.Open();
		}
		catch (Exception e)
		{
			MessageBox.Show(e.Message);
		}
	}
	/**
	* Fermeture de la connexion
	*/
	public void CloseConnexion()
	{
		cnx.Close();
	}
	/**
	* Exécutiuon d'une requête
	*/
	public MySqlCommand reqExec(string req)
	{
		MySqlCommand mysqlCmd = new MySqlCommand(req, this.cnx);
		return (mysqlCmd);
	}
}
