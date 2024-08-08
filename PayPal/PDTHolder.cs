using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;

namespace bandienthoai.PayPal
{
    public class PDTHolder
    {
        public double GrossTotal { get; set; }
        public int InvoiceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public string PayerFirstName { get; set; }
        public double PaymentFee { get; set; }
        public string BusinessEmail { get; set; }
        public string PayerMail { get; set; }
        public string TxToken { get; set; }
        public string PayerLastName { get; set; }
        public string ReceiverEmail { get; set; }

        public string ItemName { get; set; }
        public string Currency { get; set; }
        public string TransactionId { get; set; }
        public string SubcriberId { get; set; }

        public string Custom { get; set; }

        private  static string authorToken, txtoken, query, strResponse;
        public static PDTHolder Success(string tx)
        {
            authorToken = WebConfigurationManager.AppSettings["PDTToken"];
            txtoken = tx;
            query = string.Format("cmd=_notify-synch&tx={0}&at={1}",txtoken,authorToken);
            string url = WebConfigurationManager.AppSettings["PaypalSubmit"];
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = query.Length;
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(),System.Text.Encoding.ASCII);
            stOut.Write(query);
            stOut.Close();
            if (strResponse.StartsWith("SUCCESS"))
                return PDTHolder.Parse(strResponse);
            return null;
        }
        public static PDTHolder Parse(string postData)
        {
            String sKey, sValue;
            PDTHolder ph = new PDTHolder();
            try
            {
                String[] stringArray = postData.Split('\n');
                int i;
                for (i = 1; i < stringArray.Length - 1; i++)
                {
                    String[] stringArray1 = stringArray[i].Split('=');
                    sKey = stringArray1[0];
                    sValue = HttpUtility.UrlEncode(stringArray1[1]);
                    switch (sKey)
                    {
                        case "mc_gross":
                            ph.GrossTotal = Convert.ToDouble(sValue);
                            break;
                        case "invoice":
                            ph.InvoiceNumber = Convert.ToInt32(sValue);
                            break;
                        case "first_name":
                            ph.PayerFirstName = Convert.ToString(sValue);
                            break;
                        case "mc_fee":
                            ph.PaymentFee = Convert.ToDouble(sValue);
                            break;
                        case "business":
                            ph.BusinessEmail = Convert.ToString(sValue);
                            break;
                        case "payer_email":
                            ph.PayerMail = Convert.ToString(sValue);
                            break;
                        case "Tx Token":
                            ph.TxToken = Convert.ToString(sValue);
                            break;
                        case "receiver_email":
                            ph.ReceiverEmail = Convert.ToString(sValue);
                            break;
                        case "item_name":
                            ph.ItemName = Convert.ToString(sValue);
                            break;
                        case "mc_currency":
                            ph.Currency = Convert.ToString(sValue);
                            break;
                        case "txn_id":
                            ph.TransactionId = Convert.ToString(sValue);
                            break;
                        case "custom":
                            ph.Custom = Convert.ToString(sValue);
                            break;
                        case "subscr_id":
                            ph.SubcriberId = Convert.ToString(sValue);
                            break;
                    }
                }
                return ph;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}