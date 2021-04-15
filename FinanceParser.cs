using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace financeParse
{
    public class FinanceParser
    {
        private IWebDriver driver;

        public FinanceParser()
        {
            driver = GetDriver();
        }

        ~FinanceParser()
        {
            driver.Close();
        }

        private IWebDriver GetDriver()
        {
            var options = new FirefoxOptions();
            options.AddArguments(new List<string>() { "-headless", "-disable-gpu" });
            return new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        }

        public JToken GetPrice(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var result = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                return ((JObject)JsonConvert.DeserializeObject(result)).SelectToken("data");
            }

        }

        public Dictionary<string, string> GetTable(string url)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            driver.Navigate().GoToUrl(url);
            var divs = driver.FindElements(By.TagName("dl"))[0].FindElements(By.TagName("div"));


            for (int i = 0; i < divs.Count; i++)
            {
                data.Add(divs[i].FindElement(By.TagName("dt")).Text, Regex.Match(divs[i].FindElement(By.TagName("dd")).Text.Replace("%", ""), @"^[^(]*").Value);
            }
            return data;

        }
    }
}
