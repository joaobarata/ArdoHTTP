using Ardo.ArdoHTTP.Structures;
using OutSystems.ExternalLibraries.SDK;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using Tavis.UriTemplates;

namespace Ardo.ArdoHTTP
{
    public class ArdoHTTP : IArdoHTTP
    {

        private static readonly HttpClient client = new HttpClient();
        public string GetHeader(string Name, IEnumerable<HttpHeader> Headers)
        {

            foreach (var header in Headers)
            {
                if(header.Name == Name)
                {
                    return header.Value;
                }
            }

            return string.Empty;
        }
        /// <summary>
        /// Perform an HTTP DELETE request.
        /// </summary>
        public void HTTPDelete(string URL, out string Status, out int Status_Code, out IEnumerable<HttpHeader> Response_Headers, out string Response, IEnumerable<HttpHeader>? Headers, string? Username, string? Password)
        {
            processRequest(HttpMethod.Delete, URL, Headers, Username, Password, string.Empty, string.Empty, out Status, out Status_Code, out Response_Headers, out Response);
        }
        /// <summary>
        /// Perform an HTTP GET request.
        /// </summary>
        public void HTTPGet(string URL, out string Status, out int Status_Code, out IEnumerable<HttpHeader> Response_Headers, out string Response, IEnumerable<HttpHeader>? Headers, string? Username, string? Password)
        {
            processRequest(HttpMethod.Get, URL, Headers, Username, Password, string.Empty, string.Empty, out Status, out Status_Code, out Response_Headers, out Response);
        }
        /// <summary>
        /// Perform an HTTP HEAD request.
        /// </summary>
        public void HTTPHead(string URL, out string Status, out int Status_Code, out IEnumerable<HttpHeader> Response_Headers, IEnumerable<HttpHeader>? Headers, string? Username, string? Password)
        {
            processRequest(HttpMethod.Head, URL, Headers, Username?? string.Empty, Password ?? string.Empty, string.Empty, string.Empty, out Status, out Status_Code, out Response_Headers, out string _);
        }
        /// <summary>
        /// Perform an HTTP PATCH request.
        /// </summary>
        public void HTTPPatch(string URL, string Data, string Content_Type, out string Status, out int Status_Code, out IEnumerable<HttpHeader> Response_Headers, out string Response, IEnumerable<HttpHeader>? Headers, string? Username, string? Password)
        {
            processRequest(HttpMethod.Patch, URL, Headers, Username, Password, Data, Content_Type, out Status, out Status_Code, out Response_Headers, out Response);
        }
        /// <summary>
        /// Perform an HTTP POST request.
        /// </summary>
        public void HTTPPost(string URL, string Data, string Content_Type, out string Status, out int Status_Code, out IEnumerable<HttpHeader> Response_Headers, out string Response, IEnumerable<HttpHeader>? Headers, string? Username, string? Password)
        {
            processRequest(HttpMethod.Post, URL, Headers, Username, Password, Data, Content_Type, out Status, out Status_Code, out Response_Headers, out Response);
        }
        /// <summary>
        /// Perform an HTTP PUT request.
        /// </summary>
        public void HTTPPut(string URL, string Data, string Content_Type, out string Status, out int Status_Code, out IEnumerable<HttpHeader> Response_Headers, out string Response, IEnumerable<HttpHeader>? Headers, string? Username, string? Password)
        {
            processRequest(HttpMethod.Put, URL, Headers, Username, Password, Data, Content_Type, out Status, out Status_Code, out Response_Headers, out Response);
        }

        public string URLTemplate(string Template, IEnumerable<TemplateVar> Variables)
        {
            UriTemplate template = new(Template);

            foreach (TemplateVar myVar in Variables)
            {
                template.SetParameter(myVar.Name, myVar.Value);
            }

            return template.Resolve();
        }

        private void processRequest(HttpMethod method, string URL, IEnumerable<HttpHeader>? Headers, string? Username, string? Password, string? data, string? contentType, out string Status, out int Status_Code, out IEnumerable<HttpHeader> Response_Headers, out string ResponseContent)
        {

            HttpRequestMessage request = new();

            request.RequestUri = new Uri(URL);

            request.Method = method;

            if (request.Method == HttpMethod.Patch || request.Method == HttpMethod.Post || request.Method == HttpMethod.Put ) {

                request.Content = new StringContent(data?? string.Empty, Encoding.UTF8, contentType ?? "text/plain");
            }

            

            bool removeAuthHeader = true;

            if (Headers != null) {
                foreach (var header in Headers)
                {
                    switch (header.Name)
                    {
                        // special snowflake headers
                        case "Range":
                            /*RangeHeaderValue rangeHeader = RangeHeaderValue.Parse(header.Value);
                            foreach (var range in rangeHeader.Ranges)
                            {
                                long from = range.From ?? 0;
                                long to = range.To ?? 0;
                                client.DefaultRequestHeaders.Add(header.Name, AddRange(rangeHeader.Unit, from, to);
                            }*/
                            break;
                        case "Content-Type":
                        case "Connection":
                        case "Transfer-Encoding":
                        case "Host": // auto-set
                        case "Date": // auto-set
                        case "Content-Length":
                        case "Timeout":
                        case "NoPreAuth":
                        case "NoAutoCompression":
                            break;
                        case "Authorization":
                            removeAuthHeader = false;
                            break;
                        default:
                            request.Headers.Add(header.Name,header.Value);
                            break;
                    }
                }
            }

            if (removeAuthHeader)
            {
                client.DefaultRequestHeaders.Remove("Authorization");
                request.Headers.Remove("Authorization");
            }

            if (Username != null && Username != string.Empty && Password != null && Password !=string.Empty) {
                request.Headers.Add("Authorization", "Basic " + Encode64(Username+":"+ Password));
            }
            

            try
            {
                using HttpResponseMessage response = client.Send(request);

               

                using var reader = new StreamReader(response.Content.ReadAsStream());


                ResponseContent = reader.ReadToEnd();
                Status_Code = (int)response.StatusCode;
                Status = response.ReasonPhrase!.ToString();

                var h = response.Headers.Concat(response.Content.Headers);
                Response_Headers = Enumerable.Empty<HttpHeader>();

                foreach (var hh in h)
                {
                    Response_Headers = Response_Headers.Append(new HttpHeader(hh.Key, hh.Value.First()));
                } 
            }
            catch (HttpRequestException e)
            {
                throw e;

            }

        }
        private static string Encode64(string input)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }
    }
}