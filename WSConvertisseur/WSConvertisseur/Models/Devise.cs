using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSConvertisseur.Models
{
    public class Devise
    {
        public int id { get; set; }
        public String nom_devise { get; set; }
        public double taux { get; set; }

        public Devise()
        {

        }

        public Devise(int id, String nom_devise, double taux)
        {
            this.id = id;
            this.nom_devise = nom_devise;
            this.taux = taux;
        }


    }
}