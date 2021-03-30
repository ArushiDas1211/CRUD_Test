
using CRUD_Test.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Test.Page
{
    class Employee_TestPage
    {

        RestClient client;
        string url;
        RestRequest req;
        RestResponse response;
      



        public void setReq()
        {

            url = "http://dummy.restapiexample.com/api/v1";
            client = new RestClient();


        }
       
        private void setURL(string reqTyp)
        {
            if (reqTyp.ToLower().Equals("get"))
            {
                req = new RestRequest(Method.GET);
              



            }
            else if (reqTyp.ToLower().Equals("post"))
            {
                req = new RestRequest(Method.POST);
                url += "/create";
                client = new RestClient(url);
            }
            else if (reqTyp.ToLower().Equals("put"))
                req = new RestRequest(Method.PUT);
            else if (reqTyp.ToLower().Equals("patch"))
                req = new RestRequest(Method.PATCH);
            else if (reqTyp.ToLower().Equals("delete"))
            {
                req = new RestRequest(Method.DELETE);

            }

            

        }


       
        public void GetRequest(string p0)
        {

            try {
                setURL(p0);
                url += "/employees";
                client.BaseUrl = new Uri(url);


            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public int GetResponse()
        {
            try
            {

                var content = client.Execute(req);
                
                if(content.Content.Length<=0)
                    throw new Exception("No data found");
               
                
                return (int)content.StatusCode;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void VerifyRequestDetails(DataTable data)
        {
            try
            {
                var res=  client.Execute(req);

                
                string str = res.Content;
                
                 var deserial = new JsonDeserializer();
                 var output= deserial.Deserialize<Dictionary<string,string>>(res);

               // JObject bitlyObject = JObject.Parse(res.Content);
               var empDetails= JsonConvert.DeserializeObject<EmployeeJson> (output["data"]);

                //Console.Write(res.Content.);
                if (str.Equals(null))
                    throw new Exception("No Details found");




                //var chk = output["employee_name"];
                foreach (DataRow row in data.Rows)
                {
                    if (!row["employee_name"].ToString().Equals(empDetails.employee_name))
                        throw new Exception("Incorrect details received");
                }



            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //public Task<EmployeeJson> ExecuteAsyncPara<EmployeeJson>(RestRequest request) where EmployeeJson : new()
        //{
            
        //    var taskCompletionSource = new TaskCompletionSource<EmployeeJson>();
          
            
        //    client.ExecuteAsync<EmployeeJson>(req, (res) => taskCompletionSource.SetResult(res.Data));
        //    return taskCompletionSource.Task;
        //}
        public void GetRequestParam(string p0, int p1)
        {
            try
            {
                
                setURL(p0);
                if (p0.Equals("GET"))
                {
                    url += "/employee/" + p1.ToString();
                    client.BaseUrl = new Uri(url);
                }
                if (p0.Equals("DELETE"))
                {
                    url += "/delete/" + p1.ToString();
                    client.BaseUrl = new Uri(url);
                }
                // req.AddUrlSegment("id", p1.ToString());



            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void CreateUser(string reqType,string json)
        {
            try
            {
                setURL(reqType);
                req.AddJsonBody(JsonConvert.DeserializeObject<EmployeeJson>(json));
                

            }
            catch(Exception ex)
            {
                throw ex;
                


            }
        }

        public string GetResponseMessage()
        {
            try
            {
                var res = client.Execute(req);
                var deserial = new JsonDeserializer();
                var output = deserial.Deserialize<Dictionary<string, string>>(res);

                // JObject bitlyObject = JObject.Parse(res.Content);
                return (output["message"].ToString());
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
