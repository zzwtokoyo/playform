using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace playform
{
    internal class HttpHelper
    {
    }

    /// <summary>
    /// HttpListenner监听Post请求参数值实体
    /// </summary>
    public class HttpListenerPostValue
    {
        public string name;
        public byte[] datas;
    }

    public class HttpGetOrPostParaHelper
    {
        /// <summary>
        /// 发送http post请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">查询参数集合</param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, IDictionary<string, string> parameters, int timeout = 60000)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;//创建请求对象
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";//请求方式
            request.ContentType = "application/x-www-form-urlencoded";//链接类型
            request.Timeout = timeout;

            //如果需要POST数据
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = Encoding.GetEncoding("utf-8").GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            var resultStream = (request.GetResponse() as HttpWebResponse);
            string result = "";
            //获取响应内容
            using (StreamReader reader = new StreamReader(resultStream.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// post方法（使用该方法请求Api时，Api中参数前需要加[FromBody]）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="PostData">post数据对象</param>
        /// <param name="timeout">超时时间，默认为60000毫秒（1分钟）</param>
        /// <returns></returns>
        public static string PostHttpResponse(string url, Object PostData, int timeout = 60000)
        {
            HttpWebRequest request = null;
            //HTTPSQ请求
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = timeout;

            //如果需要POST数据
            string str = JsonConvert.SerializeObject(PostData);
            byte[] data = Encoding.GetEncoding("utf-8").GetBytes(str);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var resultStream = (request.GetResponse() as HttpWebResponse);
            string result = "";
            //获取响应内容
            using (StreamReader reader = new StreamReader(resultStream.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            JObject jo = (JObject)JsonConvert.DeserializeObject(result);
            return jo["flag"].ToString();
        }

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="timeout">超时时间，默认为60000毫秒（1分钟）</param>
        /// <returns></returns>
        public static string GetHttpResponse(string url, int timeout = 60000)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";
            request.UserAgent = null;
            request.Timeout = timeout;

            //往头部加入自定义验证信息
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }
    }

    /// <summary>
    /// 获取Post请求中的参数和值帮助类
    /// </summary>
    public class HttpListenerPostParaHelper
    {
        private HttpListenerContext request;

        public HttpListenerPostParaHelper(HttpListenerContext request)
        {
            this.request = request;
        }

        /// <summary>
        /// 获取Post过来的参数和数据
        /// </summary>
        /// <returns></returns>
        public List<HttpListenerPostValue> GetHttpListenerPostValue()
        {
            HttpListenerPostValue data = new HttpListenerPostValue();
            List<HttpListenerPostValue> HttpListenerPostValueList = new List<HttpListenerPostValue>();
            try
            {
                if (request.Request.ContentType.Length > 20 &&
                    string.Compare(request.Request.ContentType, "application/x-www-form-urlencoded", true) == 0)
                {
                    //接收并读取POST过来的数据流
                    StreamReader reader = new StreamReader(request.Request.InputStream);
                    string temp = reader.ReadToEnd();
                    if (!temp.Contains("="))
                    {
                        data.name = temp;
                        data.datas = Encoding.UTF8.GetBytes("");
                    }
                    else
                    {
                        data.name = temp.Split('=')[0].ToString();
                        data.datas = Encoding.UTF8.GetBytes(temp.Substring(data.name.Length + 1));
                    }
                    HttpListenerPostValueList.Add(data);
                }
                return HttpListenerPostValueList;
            }
            catch (Exception ex)
            {
                data.name = "tabindex";
                data.datas = Encoding.UTF8.GetBytes(ex.Message.ToString());
                return null;
            }
        }
    }
}
