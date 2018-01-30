using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Reflection;

namespace MLang
{
    public class MLanguage
    {
        public static string GetString(string Id)
        {
            //LangResource.Culture = new CultureInfo(SettingInfo.Default.CurrentLang);
            return LangResource.ResourceManager.GetString(Id, Thread.CurrentThread.CurrentCulture);
        }

        public static string CurrentLang
        {
            get
            {
                return SettingInfo.Default.CurrentLang; 
            }
            set
            {
                SettingInfo.Default.CurrentLang = value;
                SettingInfo.Default.Save();
            }
        }
    }
}
