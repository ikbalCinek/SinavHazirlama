using Entities.Concrete;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace deneme
{
    class Program
    {
        public static void Main(string[] args)
        {

            //public static  Exam GetPost(string link)
            //{
            //    HtmlWeb yeniHtml = new HtmlWeb();

            //    string url =link;
            //    var doc = yeniHtml.Load(url);

            //    var exam = new Exam();
            //    List<string> con = new List<string>();

            //    HtmlNode collectionHead = doc.DocumentNode.SelectSingleNode(xpath: "//h1[@class='content-header__row content-header__hed']");


            //    HtmlNodeCollection collectionContent = doc.DocumentNode.SelectNodes(xpath: "//p[@class='paywall']");
            //    foreach (var item in collectionContent)
            //    {
            //        con.Add(item.InnerText);
            //    }

            //    string combindedString = string.Join(",", con);

            //    exam.Content = combindedString;
            //    exam.Title = collectionHead.InnerText;
            //    return exam;
            //}


           




        }
    }
}
