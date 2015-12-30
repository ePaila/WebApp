using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ePaila.Utility
{
    public class eXML
    {
        /// <summary>
        /// Parse Un Formatted XML to Fromatted XML String
        /// </summary>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public static string Parse(string strXML)
        {
            //trim first line space
            
            strXML.Trim();
            string formattedXml = XElement.Parse(strXML).ToString();
            return formattedXml;
        }
    }
}
