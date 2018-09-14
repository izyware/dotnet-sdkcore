using System;
using System.Net;
using Newtonsoft.Json;

namespace Izyware
{
    public class Outcome<T>
    {
        public bool success { get; set; }
        public int statusCode { get; set; }
        public T data { get; set; }
        public string reason { get; set; }

        public Outcome(bool success, T data)
        {
            this.success = success;
            this.data = data;
        }

        public Outcome(string reason)
        {
            this.success = false;
            this.reason = reason;
        }
    }

    public class ConfigJson
    {
        public static Outcome<T> loadById<T>(string id)
        {
            if (String.IsNullOrEmpty(id) || id == "NULL") return new Izyware.Outcome<T>("Id is not specified");
            try
            {
                T obj = JsonConvert.DeserializeObject<T>(System.IO.File.ReadAllText(id));
                return new Izyware.Outcome<T>(true, obj);
            } 
            catch(Exception e)
            {
                return new Izyware.Outcome<T>(e.Message);
            }
        }
    }
}
