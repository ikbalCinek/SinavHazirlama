using CodeHollow.FeedReader;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DataAccess.Concrete
{
    public class ExamDal : BaseDal<Exam>, IExamDal
    {
        private readonly ExamContext context;
        public ExamDal(ExamContext context) : base(context)
        {
            this.context = context;
        }


        public IEnumerable<Exam> GetLatestFivePosts()
        {
            List<Exam> exams = new List<Exam>();
           
            //string urll = "http:wired.com/feed/rss";
            ////var strUrl = FeedReader.GetFeedUrlsFromUrl(urll);
            //var feed = FeedReader.ReadAsync(new Uri(urll).ToString());
            //var xdoc = XDocument.Parse(feed.Result.OriginalDocument);
            //var xnamespace = xdoc.Root.GetDefaultNamespace();

            //foreach (var item in feed.Result.Items)
            //{
            //    var baseFeedItem = item.SpecificItem;
            //    string thumbnail = null;
            //    if (baseFeedItem.Element.Descendants().Any(x=>x.Name.LocalName==xnamespace + "thumbnail"))
            //    {
            //        Exam exam = new Exam();

            //        exam.Url = baseFeedItem.Element.Descendants().First(x => x.Name.LocalName == xnamespace + "thumbnail").Attribute("link").Value;
            //        exam.CreatedDate = DateTime.Parse(baseFeedItem.Element.Descendants().First(x => x.Name.LocalName == xnamespace + "thumbnail").Attribute("pubDate").Value);
            //        exams.Add(exam);
                  
            //    }
               
            //}
            //return exams;








            //string url = "http:wired.com/feed/rss";
            //feed
            //XDocument doc = new XDocument();
            //doc = XDocument.Load(url);
            //var items = (from x in doc.Descendants("item")
            //             select new
            //             {

            //                 link = x.Element("link").Value,
            //                 pubDate = x.Element("pubDate").Value,
            //             }
            //             );


            //if (items != null)
            //{
            //    foreach (var i in items)
            //    {
            //        Exam f = new Exam
            //        {

            //            Url = i.link,
            //            CreatedDate = i.pubDate,

            //        };

            //        feeds.Add(f);
            //    }
            //}

            //return feeds;



            //XDocument feedXML = XDocument.Load(url);

            //var feeds = (from fed in feedXML.Descendants("item")
            //            select new Exam
            //            {
            //                CreatedDate = (DateTime)fed.Element("pubDate"),
            //                Url = fed.Element("link").Value,

            //            }).ToList().Take(5);

            //return feeds;



            //using (var client=new WebClient())
            //{
            //    string rssData = client.DownloadString("http:wired.com/feed/rss");
            //    XDocument xmlDocument = XDocument.Parse(rssData);
            //    var feedData = (from x in xmlDocument.Descendants("item")
            //                    select new Exam
            //                    {
            //                        Url = (string)x.Element("link"),
            //                        CreatedDate = (string)x.Element("pubDate")
            //                    }).ToList().Take(5);

            //    return feedData;
            //}


            //string url = "http://wired.com/feed/rss";
            //XmlReader xmlReader = XmlReader.Create(url);
            //SyndicationFeed fed = SyndicationFeed.Load(xmlReader);
            //xmlReader.Close();
            //foreach (var item in fed.Items)
            //{
            //    Console.WriteLine(item.Links[0].Uri);
            //}


            string url = "http://wired.com/feed/rss";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed fed = SyndicationFeed.Load(reader);
            reader.Close();
            return (from itm in fed.Items
                    select new Exam
                    {
                        Url = itm.Links[0].Uri.ToString(),
                        CreatedDate = itm.PublishDate.ToString(),


                    }).ToList().Take(5);


        }



        public Exam GetPost(Exam exam)
        {
            HtmlWeb yeniHtml = new HtmlWeb();

            string url = exam.Url;
            var doc = yeniHtml.Load(url);


            List<string> con = new List<string>();

            HtmlNode collectionHead = doc.DocumentNode.SelectSingleNode(xpath: "//h1[@class='content-header__row content-header__hed']");





            HtmlNodeCollection collectionContent = doc.DocumentNode.SelectNodes(xpath: "//p[@class='paywall']");

            if (collectionContent != null)
            {
                foreach (var item in collectionContent)
                {
                    if (item!=null)
                    {
                        con.Add(item.InnerText); 
                    }
                } 
            }
           

            string combindedString = string.Join(",", con);

            exam.Content = combindedString;
            exam.Title = collectionHead.InnerText;
            return exam;

        }



    }
}
