using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class fiche_de_frais
    {
        private string Annee_mois;

        private int Quantite_repas_midi;
        private int Quantite_nuitee;
        private int Quantite_etape;
        private int Quantite_km;
        private string Situation;
        private DateTime DateModif_operation;
        private List<Frais_hors_forfait> Les_frais_hors_forfaits;


        private int Nb_justificatif;
        private float MontantHC;
        private string SituationHC;
        private DateTime DateModif_operationHC;

        public fiche_de_frais(string am, int qrm, int qn, int qe, int qk, string sit, DateTime dtop, int nbj, float mhc, string sithc, DateTime dtophc, List<Frais_hors_forfait> fhf)
        {
            this.Annee_mois = am;
            this.Quantite_repas_midi = qrm;
            this.Quantite_nuitee = qn;
            this.Quantite_etape = qe;
            this.Quantite_km = qk;
            this.Situation = sit;
            this.DateModif_operation = dtop;
            this.Nb_justificatif = nbj;
            this.MontantHC = mhc;
            this.SituationHC = sithc;
            this.DateModif_operationHC = dtophc;
            this.Les_frais_hors_forfaits = fhf;

        }
        public string getAnnee_mois()
        {
            return this.Annee_mois;
        }
        public int getQuantite_repas_midi()
        {
            return this.Quantite_repas_midi;
        }
        public int getQuantite_nuitee()
        {
            return this.Quantite_nuitee;
        }
        public int getQuantite_etape()
        {
            return this.Quantite_etape;
        }
        public int getQuantite_km()
        {
            return this.Quantite_km;
        }
        public string getSituation()
        {
            return this.Situation;
        }
        public DateTime getDateModif_operation()
        {
            return this.DateModif_operation;
        }
        public List<Frais_hors_forfait> getLes_frais_hors_forfaits()
        {
            return this.Les_frais_hors_forfaits;
        }
        public int getNb_justificatif()
        {
            return this.Nb_justificatif;
        }
        public float getMontantHC()
        {
            return this.MontantHC;
        }
        public DateTime getDateModif_operationHC()
        {
            return this.DateModif_operationHC;
        }
        public void setAnnee_mois(string am)
        {
            this.Annee_mois=am;
        }
        public void setQuantite_repas_midi(int qrm)
        {
            this.Quantite_repas_midi=qrm;
        }
        public void setQuantite_nuitee(int qn)
        {
            this.Quantite_nuitee=qn;
        }
        public void setQuantite_etape(int qe)
        {
            this.Quantite_etape=qe;
        }
        public void SetQuantite_km(int qk)
        {
            this.Quantite_km=qk;
        }
        public void getSituation(string sit)
        {
            this.Situation=sit;
        } 
        public void SetDateModif_operation(DateTime dtop)
        {
           this.DateModif_operation=dtop;
        }
        public void setLes_frais_hors_forfaits(List<Frais_hors_forfait> fhf)
        {
            this.Les_frais_hors_forfaits = fhf;
        }
        public void setNb_justificatif(int nbj)
        {
            this.Nb_justificatif= nbj;
        }
        public void setMontantHC(float mhc)
        {
            this.MontantHC = mhc;
        }
        public void setDateModif_operationHC(DateTime dtophc)
        {
            this.DateModif_operationHC=dtophc;
        }
    }
    
}
