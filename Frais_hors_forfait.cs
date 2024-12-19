using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Frais_hors_forfait
    {
        private DateTime DateHF;
        private string Libelle;
        private float Montant;
        private string SituationHF;
        private DateTime Datemodif_operationHF;
        public Frais_hors_forfait(DateTime dhf, string lbl, float mt, string sitHF, DateTime doHF)
        {
            this.DateHF = dhf;
            this.Libelle = lbl;
            this.Montant = mt;
            this.SituationHF = sitHF;
            this.Datemodif_operationHF = doHF;
        }

        public DateTime getDateHF()
        {
            return this.DateHF;
        }
        public string getLibelle()
        {
            return this.Libelle;
        }
        public float getMontant()
        {
            return this.Montant;
        }
        public string getSituationHF()
        {
            return this.SituationHF;
        }
        public DateTime getDate_operationHF()
        {
            return this.Datemodif_operationHF;

        }
        public void setDateHF(DateTime dhf)
        {
            this.DateHF = dhf;
        }
        public void setLibelle(string lbl)
        {
            this.Libelle = lbl;
        }
        public void setMontant(float mt)
        {
            this.Montant = mt;
        }
        public void setSituationHF(string sitHF)
        {
            this.SituationHF = sitHF;
        }
        public void setDatemodif_operationHF(DateTime dohf)
        {
            this.Datemodif_operationHF = dohf;
        }
    }
    }
