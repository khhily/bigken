using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApplication1
{
    /// <summary>
    /// WeimobHandler 的摘要说明
    /// </summary>
    public class WeimobHandler : IHttpHandler
    {
        //填写你的TOKEN
        private static string token = "";

        public void ProcessRequest(HttpContext context)
        {
            //微盟加密签名
            string signature = context.Request.QueryString["signature"];
            //时间戳
            string timestamp = context.Request.QueryString["timestamp"];
            //随机数
            string nonce = context.Request.QueryString["nonce"];
            //随机数
            string echostr = context.Request.QueryString["echostr"];

            string signatureNew = SHA(timestamp, nonce, token);

            if (signature == signatureNew)
            {
                context.Response.Write(echostr);
            }
            else
            {
                context.Response.Write("error happened");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public static string SHA(string timestamp,
            string nonce,
            string token)
        {
            string[] source = { timestamp, nonce, token };
            Array.Sort(source);
            string sourceStr = string.Join("", source);
            SHA1 sha = new SHA1CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(sourceStr);
            byte[] dataHashed = sha.ComputeHash(dataToHash);
            string targetSign = BitConverter.ToString(dataHashed).Replace("-", "");
            return targetSign.ToLower();
        }
    }
}