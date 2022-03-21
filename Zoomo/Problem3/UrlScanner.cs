using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Zoomo.Problem3
{
    public static class UrlScanner
    {
        public static UrlResponseModel ScanHtmlFile(string filePath)
        {
            Stopwatch timer = new();

            if (!(filePath.EndsWith(".html") || filePath.EndsWith(".HTML")))
            {
                throw new FileFormatNotCorrectException("File not valid HTML.");
            }

            var response = new UrlResponseModel();
            var document = new HtmlDocument();
            document.Load(filePath);

            timer.Start();
            var allLinks = GetAllLinksInDocument(document);
            Parallel.ForEach(allLinks,  link =>
            {
                if (  CheckIfUrlExists(link))
                {
                    response.LinksWorking++;
                    response.LinksWorkingList ??= new List<string>();
                    response.LinksWorkingList.Add(link);
                }
                else
                {
                    response.LinksNotWorking++;
                    response.LinksNotWorkingList ??= new List<string>();
                    response.LinksNotWorkingList.Add(link);
                }
            });
            timer.Stop();

            response.TimeElapsed = timer.Elapsed;
            return response;
        }

        private static IEnumerable<string> GetAllLinksInDocument(HtmlDocument document)
        {
            if (document == null)
                return null;
            
            var allLinks = new List<string>();
            var linkNodes = document.DocumentNode.SelectNodes("//a[@href]").ToList(); 
            linkNodes.AddRange(document.DocumentNode.SelectNodes("//link[@href]").ToList());
            
            foreach (var node in linkNodes)
            {
                allLinks.AddRange(node.Attributes.AsEnumerable().Where(att => att.Name == "href")
                    .Select(att => att.Value));
            }

            return allLinks.Distinct().ToList();
        }

        private static bool CheckIfUrlExists(string url)
        {
            try
            {
                if (WebRequest.Create(url) is HttpWebRequest request)
                {
                    request.Method = "GET";
                    request.UserAgent = "TEST_C#_APPLICATION";
                    
                    var response = request.GetResponse() as HttpWebResponse;
                    
                    Console.WriteLine("Checking: {0}", url);
                    
                    var status = response?.StatusCode;

                    return status is HttpStatusCode.OK or HttpStatusCode.MovedPermanently or HttpStatusCode.Found
                        or HttpStatusCode.SeeOther or HttpStatusCode.NotModified or HttpStatusCode.UseProxy
                        or HttpStatusCode.TemporaryRedirect
                        or HttpStatusCode.PermanentRedirect;
                }

                return false;
            }
            catch (WebException e)
            {
                using var response = e.Response;
                var httpResponse = (HttpWebResponse) response;
                Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                return httpResponse.StatusCode is HttpStatusCode.Moved or HttpStatusCode.Redirect;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}