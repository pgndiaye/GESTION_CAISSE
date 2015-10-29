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
    class ModelReferenceDao
    {
        public static ModelReference getOneModelReference(long id)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_modele_reference where id = " + id + "";
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ModelReference a = new ModelReference();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Prefix = lect["prefix"].ToString();
                        a.Module = lect["module"].ToString();
                        a.Separateur = lect["separateur"].ToString();
                        a.Taille = (Int32)((lect["taille"] != null) ? (!lect["taille"].ToString().Trim().Equals("") ? lect["taille"] : 0) : 0);
                        a.Jour = (Boolean)((lect["jour"] != null) ? (!lect["jour"].ToString().Trim().Equals("") ? lect["jour"] : false) : false);
                        a.Mois = (Boolean)((lect["mois"] != null) ? (!lect["mois"].ToString().Trim().Equals("") ? lect["mois"] : false) : false);
                        a.Annee = (Boolean)((lect["annee"] != null) ? (!lect["annee"].ToString().Trim().Equals("") ? lect["annee"] : false) : false);
                        a.Element = (lect["element"] != null
                            ? (!lect["element"].ToString().Trim().Equals("")
                            ? BLL.ElementReferenceBll.One(Convert.ToInt64(lect["element"].ToString()))
                            : new ElementReference())
                            : new ElementReference());
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

        public static ModelReference getOneModelReference(ElementReference element)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                String search = "select * from yvs_base_modele_reference where element = " + element.Id + " and societe = " + Constantes.Societe.Id;
                NpgsqlCommand Lcmd = new NpgsqlCommand(search, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                ModelReference a = new ModelReference();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Prefix = lect["prefix"].ToString();
                        a.Module = lect["module"].ToString();
                        a.Separateur = lect["separateur"].ToString();
                        a.Taille = (Int32)((lect["taille"] != null) ? (!lect["taille"].ToString().Trim().Equals("") ? lect["taille"] : 0) : 0);
                        a.Jour = (Boolean)((lect["jour"] != null) ? (!lect["jour"].ToString().Trim().Equals("") ? lect["jour"] : false) : false);
                        a.Mois = (Boolean)((lect["mois"] != null) ? (!lect["mois"].ToString().Trim().Equals("") ? lect["mois"] : false) : false);
                        a.Annee = (Boolean)((lect["annee"] != null) ? (!lect["annee"].ToString().Trim().Equals("") ? lect["annee"] : false) : false);
                        a.Element = (lect["element"] != null
                            ? (!lect["element"].ToString().Trim().Equals("")
                            ? BLL.ElementReferenceBll.One(Convert.ToInt64(lect["element"].ToString()))
                            : new ElementReference())
                            : new ElementReference());
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
                String search = "select id from yvs_base_modele_reference order by id desc limit 1";
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

        public static ModelReference getAjoutModelReference(ModelReference a)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                string insert = "";
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

        public static bool getUpdateModelReference(ModelReference a)
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

        public static bool getDeleteModelReference(long id)
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

        public static List<ModelReference> getListModelReference(String query)
        {
            NpgsqlConnection con = Connexion.Connection();
            try
            {
                List<ModelReference> l = new List<ModelReference>();
                NpgsqlCommand Lcmd = new NpgsqlCommand(query, con);
                NpgsqlDataReader lect = Lcmd.ExecuteReader();
                if (lect.HasRows)
                {
                    while (lect.Read())
                    {
                        ModelReference a = new ModelReference();
                        a.Id = Convert.ToInt64(lect["id"].ToString());
                        a.Prefix = lect["prefix"].ToString();
                        a.Module = lect["module"].ToString();
                        a.Separateur = lect["separateur"].ToString();
                        a.Taille = (Int32)((lect["taille"] != null) ? (!lect["taille"].ToString().Trim().Equals("") ? lect["taille"] : 0) : 0);
                        a.Jour = (Boolean)((lect["jour"] != null) ? (!lect["jour"].ToString().Trim().Equals("") ? lect["jour"] : false) : false);
                        a.Mois = (Boolean)((lect["mois"] != null) ? (!lect["mois"].ToString().Trim().Equals("") ? lect["mois"] : false) : false);
                        a.Annee = (Boolean)((lect["annee"] != null) ? (!lect["annee"].ToString().Trim().Equals("") ? lect["annee"] : false) : false);
                        a.Element = (lect["element"] != null
                            ? (!lect["element"].ToString().Trim().Equals("")
                            ? BLL.ElementReferenceBll.One(Convert.ToInt64(lect["element"].ToString()))
                            : new ElementReference())
                            : new ElementReference());
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
