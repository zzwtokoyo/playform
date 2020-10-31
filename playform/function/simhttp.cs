using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace playform.function
{
    /// <summary>
    /// 模拟http 接收数据
    /// </summary>
    public class simhttp
    {
        public static void httpPostRequestHandle()
        {
            try
            {
                while (true)
                {
                    HttpListenerContext requestContext = publicfunction.g_httpPostRequest.GetContext();
                    Thread threadsub = new Thread(new ParameterizedThreadStart((requestcontext) =>
                    {
                        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                        HttpListenerContext request = (HttpListenerContext)requestcontext;
                        //获取Post请求中的参数和值帮助类
                        HttpListenerPostParaHelper httppost = new HttpListenerPostParaHelper(request);
                        //获取Post过来的参数和数据
                        List<HttpListenerPostValue> lst = httppost.GetHttpListenerPostValue();
                        //bool ibool = true;
                        foreach (var key in lst)
                        {
                            string RtnValue = Encoding.UTF8.GetString(key.datas).Replace("\r\n", "");
                            if (key.name == "capturepic")
                            {
                                publicfunction.g_HttpGetStatus = true;
                                publicfunction.g_HttpGetParams = RtnValue;
                                publicfunction.g_CallMode = (int)OCXPlayAttrubute.capturepic;
                                publicfunction.rebootTimer();
                            }
                            else if (key.name.Equals("startlnk"))
                            {
                                int i = 0;
                                publicfunction.g_HttpGetStatus = true;
                                publicfunction.g_HttpGetParams = RtnValue;
                                publicfunction.g_CallMode = (int)OCXPlayAttrubute.startlnkapp;
                                publicfunction.rebootTimer();
                                i++;
                                Console.WriteLine("请求次数:" + i.ToString());
                            }
                            //response
                            request.Response.StatusCode = 200;
                            request.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                            request.Response.ContentType = "application/json";
                            requestContext.Response.ContentEncoding = Encoding.UTF8;
                            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(new { success = "true", msg = "提交成功", context = (new { result = "success" }) }));
                            request.Response.ContentLength64 = buffer.Length;
                            var output = request.Response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            output.Close();
                        }
                    }));
                    threadsub.Start(requestContext);
                    Thread.Sleep(200);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
