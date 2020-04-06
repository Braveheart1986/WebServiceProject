using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Xml.XmlConfiguration;
using Newtonsoft.Json;

namespace WebServiceProject2
{
    /// <summary>
    /// Description résumée de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public int Fibonacci(int n)
        {
            if (n < 1 || n > 100)
            {
                return -1;
            }
            else
            {
                int[] Fib = new int[n + 1];
                Fib[0] = 0;
                Fib[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    Fib[i] = Fib[i - 2] + Fib[i - 1];
                }
                return Fib[n];
            }
        }
        [WebMethod]
        public string XmlToJson(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                string jsonText = JsonConvert.SerializeXmlNode(doc);
                return jsonText;
            }
            catch
            {
                return "Bad Xml format";
            }
        }
    }
}