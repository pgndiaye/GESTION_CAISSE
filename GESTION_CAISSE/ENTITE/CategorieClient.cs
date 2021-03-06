﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTION_CAISSE.ENTITE
{
    class CategorieClient
    {
        public CategorieClient()
        {
            remises = new List<PlanRemise>();
        }

        public CategorieClient(long id)
        {
            this.id = id;
            remises = new List<PlanRemise>();
        }

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private String code;
        public String Code
        {
            get { return code; }
            set { code = value; }
        }

        private String designation;
        public String Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        private List<PlanRemise> remises;
        internal List<PlanRemise> Remises
        {
            get { return remises; }
            set { remises = value; }
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
