﻿using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using Acceso;

namespace FrontHP
{
    public class LdapAuthentication
    {
        private string _path;
        private string _filterAttribute;

        public LdapAuthentication(string path)
        {
            _path = path;
        }

        public bool IsAuthenticated(string domain, string username, string pwd)
        {
            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(_path,
            domainAndUsername, pwd);
            try
            {
                // Bind to the native AdsObject to force authentication. 
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
                // Update the new path to the user in the directory
                _path = result.Path;
                _filterAttribute = (String)result.Properties["cn"][0];
            }
            catch (Exception ex)
            {
                throw new Exception("Error Usuario inexistente. " + ex.Message);
            }
            return true;
        }

        public List<GruposAD> GetGroups()
        {
            DirectorySearcher search = new DirectorySearcher(_path);
            search.Filter = "(cn=" + _filterAttribute + ")";
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupNames = new StringBuilder();
            List<GruposAD> objGr = new List<GruposAD>();
            try
            {
                SearchResult result = search.FindOne();
                int propertyCount = result.Properties["memberOf"].Count;
                String dn;
                int equalsIndex, commaIndex;
                for (int propertyCounter = 0; propertyCounter < propertyCount;
                  propertyCounter++)
                {
                    GruposAD g = new GruposAD();
                    dn = (String)result.Properties["memberOf"][propertyCounter];
                    equalsIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalsIndex)
                    {
                        return null;
                    }

                    g.grupo = dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1);
                    objGr.Add(g);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los nombres de grupos. " + ex.Message);
            }
            //return groupNames.ToString();
            return objGr;
        }
    }
}
