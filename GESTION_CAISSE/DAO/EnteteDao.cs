﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using GESTION_CAISSE.ENTITE;
using GESTION_CAISSE.TOOLS;

namespace GESTION_CAISSE.DAO
{
    class EnteteDao
    {
        public static Entete getOneEntete(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_entete_doc_vente where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Entete a = new Entete();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Etat = lect["etat"].ToString();
                        a.DateEntete = Convert.ToDateTime((lect["date_entete"] != null) ? (!lect["date_entete"].ToString().Trim().Equals("") ? lect["date_entete"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.Creneau = (lect["creneau"] != null
                            ? (!lect["creneau"].ToString().Trim().Equals("")
                            ? BLL.CreneauBll.One(Convert.ToInt64(lect["creneau"].ToString()))
                            : new Creneau())
                            : new Creneau());
                        a.FacturesRegle = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_REGLE + "'");
                        foreach(Facture f in a.FacturesRegle){
                            a.Montant += f.MontantTTC;
                        }
                        a.FacturesEnAttente = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_EN_ATTENTE + "'");
                        foreach (Facture f in a.FacturesEnAttente)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.FacturesEnCours = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_EN_COURS + "'");
                        foreach (Facture f in a.FacturesEnCours)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.Commandes = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_BCV + "' and statut = '" + Constantes.ETAT_VALIDE + "'");
                        foreach (Facture f in a.Commandes)
                        {
                            a.Montant += f.MontantAvance;
                        }
                        a.Update = true;
                    }
                    lect.Close();
                }
                return a;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static Entete getOneEntete(Creneau creneau, DateTime date)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_com_entete_doc_vente where date_entete = '" + date + "' and creneau = " + creneau.Id;
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                Entete a = new Entete();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Etat = lect["etat"].ToString();
                        a.DateEntete = Convert.ToDateTime((lect["date_entete"] != null) ? (!lect["date_entete"].ToString().Trim().Equals("") ? lect["date_entete"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.Creneau = (lect["creneau"] != null
                            ? (!lect["creneau"].ToString().Trim().Equals("")
                            ? BLL.CreneauBll.One(Convert.ToInt64(lect["creneau"].ToString()))
                            : new Creneau())
                            : new Creneau());
                        a.FacturesRegle = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_REGLE + "'");
                        foreach (Facture f in a.FacturesRegle)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.FacturesEnAttente = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_EN_ATTENTE + "'");
                        foreach (Facture f in a.FacturesEnAttente)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.FacturesEnCours = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_EN_COURS + "'");
                        foreach (Facture f in a.FacturesEnCours)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.Commandes = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_BCV + "' and statut = '" + Constantes.ETAT_VALIDE + "'");
                        foreach (Facture f in a.Commandes)
                        {
                            a.Montant += f.MontantAvance;
                        }
                        a.Update = true;
                    }
                    lect.Close();
                }
                return a;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        private static long getCurrent()
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select id from yvs_com_entete_doc_vente where creneau = " + Constantes.Creneau.Id + " order by id desc limit 1";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                long id = 0;
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        id = Convert.ToInt64(lect["id"].ToString());
                    }
                    lect.Close();
                }
                return id;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return 0;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static Entete getAjoutEntete(Entete a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string insert = "insert into yvs_com_entete_doc_vente"
                                + "(creneau, date_entete, etat)"
                                + "values (" + Constantes.Creneau.Id + ", " + DateTime.Now + ", " + Constantes.ETAT_EN_ATTENTE + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                a.Id = getCurrent();
                return a;
            }
            catch
            {
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static bool getUpdateEntete(Entete a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string update = "";
                NpgsqlCommand Ucmd = new NpgsqlCommand(update, con);
                Ucmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Messages.Exception(e);
                return false;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static bool getDeleteEntete(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string delete = "";
                NpgsqlCommand Ucmd = new NpgsqlCommand(delete, con);
                Ucmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                Messages.Exception(e);
                return false;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }

        public static List<Entete> getListEntete(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<Entete> l = new List<Entete>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        Entete a = new Entete();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Etat = lect["etat"].ToString();
                        a.DateEntete = Convert.ToDateTime((lect["date_entete"] != null) ? (!lect["date_entete"].ToString().Trim().Equals("") ? lect["date_entete"].ToString().Trim() : "00/00/0000") : "00/00/0000");
                        a.Creneau = (lect["creneau"] != null
                            ? (!lect["creneau"].ToString().Trim().Equals("")
                            ? BLL.CreneauBll.One(Convert.ToInt64(lect["creneau"].ToString()))
                            : new Creneau())
                            : new Creneau());
                        a.FacturesRegle = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_REGLE + "'");
                        foreach (Facture f in a.FacturesRegle)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.FacturesEnAttente = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_EN_ATTENTE + "'");
                        foreach (Facture f in a.FacturesEnAttente)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.FacturesEnCours = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_FV + "' and statut = '" + Constantes.ETAT_EN_COURS + "'");
                        foreach (Facture f in a.FacturesEnCours)
                        {
                            a.Montant += f.MontantTTC;
                        }
                        a.Commandes = BLL.FactureBll.Liste("select * from yvs_com_doc_ventes where entete_doc = "
                            + a.Id + " and type_doc = '" + Constantes.TYPE_BCV + "' and statut = '" + Constantes.ETAT_VALIDE + "'");
                        foreach (Facture f in a.Commandes)
                        {
                            a.Montant += f.MontantAvance;
                        }
                        a.Update = true;
                        l.Add(a);
                    }
                    lect.Close();
                }
                return l;
            }
            catch (NpgsqlException e)
            {
                Messages.Exception(e);
                return null;
            }
            finally
            {
                Connexion.Deconnection(con);
            }
        }
    }
}
