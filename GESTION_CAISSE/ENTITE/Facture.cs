﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    public class Facture
    {
        public Facture()
        {
            contenus = new List<Contenu>();
            Remises = new List<RemiseFacture>();
        }

        public Facture(long id)
        {
            this.id = id;
            contenus = new List<Contenu>();
            Remises = new List<RemiseFacture>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String numPiece;
        public String NumPiece
        {
            get { return numPiece; }
            set { numPiece = value; }
        }

        private String numDoc;
        public String NumDoc
        {
            get { return numDoc; }
            set { numDoc = value; }
        }

        private Client client = new Client();
        internal Client Client
        {
            get { return client; }
            set { client = value; }
        }

        private CategorieComptable categorie = new CategorieComptable();
        internal CategorieComptable Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        private Entete entete = new Entete();
        internal Entete Entete
        {
            get { return entete; }
            set { entete = value; }
        }

        private DateTime heureDoc = DateTime.Now;
        public DateTime HeureDoc
        {
            get { return heureDoc; }
            set { heureDoc = value; }
        }

        private List<Contenu> contenus;
        internal List<Contenu> Contenus
        {
            get { return contenus; }
            set { contenus = value; }
        }

        private List<RemiseFacture> remises;
        internal List<RemiseFacture> Remises
        {
            get { return remises; }
            set { remises = value; }
        }

        private String statut;
        public String Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        private double montantHT;
        public double MontantHT
        {
            get { return montantHT; }
            set { montantHT = value; }
        }

        private double montantTTC;
        public double MontantTTC
        {
            get { return montantTTC; }
            set { montantTTC = value; }
        }

        private double montantAvance;
        public double MontantAvance
        {
            get { return montantAvance; }
            set { montantAvance = value; }
        }

        private double montantReste;
        public double MontantReste
        {
            get { return montantReste; }
            set { montantReste = value; }
        }

        private double montantRemise;
        public double MontantRemise
        {
            get { return montantRemise; }
            set { montantRemise = value; }
        }

        private double montantRistourne;
        public double MontantRistourne
        {
            get { return montantRistourne; }
            set { montantRistourne = value; }
        }

        private double montantCommission;
        public double MontantCommission
        {
            get { return montantCommission; }
            set { montantCommission = value; }
        }

        private double montantTaxe;
        public double MontantTaxe
        {
            get { return montantTaxe; }
            set { montantTaxe = value; }
        }

        private Facture documentLie;
        internal Facture DocumentLie
        {
            get { return documentLie; }
            set { documentLie = value; }
        }

        private bool solde;
        public bool Solde
        {
            get { return solde; }
            set { solde = value; }
        }

        private bool update;
        public bool Update
        {
            get { return update; }
            set { update = value; }
        }

        private bool select;
        public bool Select
        {
            get { return select; }
            set { select = value; }
        }

        private bool new_;
        public bool New_
        {
            get { return new_; }
            set { new_ = value; }
        }
    }
}
