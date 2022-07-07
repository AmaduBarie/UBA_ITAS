using System;
using System.DirectoryServices;

namespace NRA_ITAS
{
    public class UserAuthentication
    {
        public Boolean AuthenticeViaAD(String Username, String Password, String Domain, String LdapPath)
        {
            String domainAndUsername = Domain + @"\" + Username;
            DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, Password);
            try
            {
                // Bind to the native AdsObject to force authentication.
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + Username + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}