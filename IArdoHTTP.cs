using Ardo.ArdoHTTP.Structures;
using OutSystems.ExternalLibraries.SDK;
using System.Reflection.PortableExecutable;

namespace Ardo.ArdoHTTP
{
    /// <summary>
    /// Version 1.0
    /// Helper extension for JSON. Allows you to manipulate and parse JSON using JSONPath.
    /// Uses the Newtonsoft.Json library (https://www.newtonsoft.com/json)
    /// </summary>
    [OSInterface(Description = "Version 1.0\r\nSet of tools to perform all kinds of HTTP requests, with full control over the request.", IconResourceName = "ArdoHTTP.resources.logo.png", Name = "ArdoHTTP")]
    public interface IArdoHTTP
    {
        /// <summary>
        /// Gets a given header by name from a list of headers.
        /// </summary>
        [OSAction(Description = "Gets a given header by name from a list of headers.", IconResourceName = "ArdoHTTP.resources.logo.png", ReturnName = "Value")]
        public string GetHeader(
            [OSParameter(Description = "Name of the header to obtain.")]
            string Name,
            [OSParameter(Description = "List of headers to process.")]
            IEnumerable<HttpHeader> Headers);

        /// <summary>
        /// Perform an HTTP DELETE request.
        /// </summary>
        [OSAction(Description = "Perform an HTTP DELETE request.", IconResourceName = "ArdoHTTP.resources.logo.png", ReturnName = "HTTPResponse")]
        public void HTTPDelete(
            [OSParameter(Description = "The URL to access. MUST contain http:// or https://")]
            string URL,
            [OSParameter(Description = "Status of the request. \"OK\" if the request was successfull (200).")]
            out string Status,
            [OSParameter(Description = "HTTP Status code in numeric form.")]
            out int Status_Code,
            [OSParameter(Description = "Headers from the response.")]
            out IEnumerable < HttpHeader > Response_Headers,
            [OSParameter(Description = "Response as Text")]
            out string Response,
            [OSParameter(Description = "Extra HTTP headers to add to the request.\r\n\r\nSpecial headers:\r\n\r\nTimeout: int, sets the timeout for the request\r\nNoPreAuth: revert to .NET's default authentication behavior\r\nNoAutoCompression: disable attempting to auto-compress response.")]
            IEnumerable<HttpHeader> ? Headers = null,
            [OSParameter(Description = "Username to use for HTTP Basic authentication.")]
            string ? Username = null,
            [OSParameter(Description = "Password to use for HTTP Basic authentication.")]
            string ? Password = null);

        /// <summary>
        /// Perform an HTTP GET request.
        /// </summary>
        [OSAction(Description = "Perform an HTTP GET request.", IconResourceName = "ArdoHTTP.resources.logo.png", ReturnName = "HTTPResponse")]
        public void HTTPGet(
            [OSParameter(Description = "The URL to access. MUST contain http:// or https://")]
            string URL,
            [OSParameter(Description = "Status of the request. \"OK\" if the request was successfull (200).")]
            out string Status,
            [OSParameter(Description = "HTTP Status code in numeric form.")]
            out int Status_Code,
            [OSParameter(Description = "Headers from the response.")]
            out IEnumerable < HttpHeader > Response_Headers,
            [OSParameter(Description = "Response as Text")]
            out string Response,
            [OSParameter(Description = "Extra HTTP headers to add to the request.\r\n\r\nSpecial headers:\r\n\r\nTimeout: int, sets the timeout for the request\r\nNoPreAuth: revert to .NET's default authentication behavior\r\nNoAutoCompression: disable attempting to auto-compress response.")]
            IEnumerable<HttpHeader> ? Headers = null,
            [OSParameter(Description = "Username to use for HTTP Basic authentication.")]
            string ? Username = null,
            [OSParameter(Description = "Password to use for HTTP Basic authentication.")]
            string ? Password = null);

        /// <summary>
        ///Perform an HTTP HEAD request.
        /// </summary>
        [OSAction(Description = "Perform an HTTP HEAD request.", IconResourceName = "ArdoHTTP.resources.logo.png")]
        public void HTTPHead(
            [OSParameter(Description = "The URL to access. MUST contain http:// or https://")]
            string URL,
            [OSParameter(Description = "Status of the request. \"OK\" if the request was successfull (200).")]
            out string Status,
            [OSParameter(Description = "HTTP Status code in numeric form.")]
            out int Status_Code,
            [OSParameter(Description = "Headers from the response.")]
            out IEnumerable < HttpHeader > Response_Headers,

            [OSParameter(Description = "Extra HTTP headers to add to the request.\r\n\r\nSpecial headers:\r\n\r\nTimeout: int, sets the timeout for the request\r\nNoPreAuth: revert to .NET's default authentication behavior\r\nNoAutoCompression: disable attempting to auto-compress response.")]
            IEnumerable<HttpHeader> ? Headers = null,
            [OSParameter(Description = "Username to use for HTTP Basic authentication.")]
            string ? Username = null,
            [OSParameter(Description = "Password to use for HTTP Basic authentication.")]
            string ? Password = null);

        /// <summary>
        ///Perform an HTTP PATCH request.
        /// </summary>
        [OSAction(Description = "Perform an HTTP PATCH request.", IconResourceName = "ArdoHTTP.resources.logo.png", ReturnName = "HTTPResponse")]
        public void HTTPPatch(
            [OSParameter(Description = "The URL to access. MUST contain http:// or https://")]
            string URL,
            [OSParameter(Description = "Request content")]
            string Data,
            [OSParameter(Description = "Value for Content-Type header. If set, overrides anything set on the Headers list.")]
            string Content_Type,
            [OSParameter(Description = "Status of the request. \"OK\" if the request was successfull (200).")]
            out string Status,
            [OSParameter(Description = "HTTP Status code in numeric form.")]
            out int Status_Code,
            [OSParameter(Description = "Headers from the response.")]
            out IEnumerable < HttpHeader > Response_Headers,
            [OSParameter(Description = "Response as Text")]
            out string Response,
            [OSParameter(Description = "Extra HTTP headers to add to the request.\r\n\r\nSpecial headers:\r\n\r\nTimeout: int, sets the timeout for the request\r\nNoPreAuth: revert to .NET's default authentication behavior\r\nNoAutoCompression: disable attempting to auto-compress response.")]
            IEnumerable<HttpHeader> ? Headers = null,
            [OSParameter(Description = "Username to use for HTTP Basic authentication.")]
            string ? Username = null,
            [OSParameter(Description = "Password to use for HTTP Basic authentication.")]
            string ? Password = null);

        /// <summary>
        ///Perform an HTTP POST request.
        /// </summary>
        [OSAction(Description = "Perform an HTTP POST request.", IconResourceName = "ArdoHTTP.resources.logo.png", ReturnName = "HTTPResponse")]
        public void HTTPPost(
            [OSParameter(Description = "The URL to access. MUST contain http:// or https://")]
            string URL,
            [OSParameter(Description = "Request content")]
            string Data,
            [OSParameter(Description = "Value for Content-Type header. If set, overrides anything set on the Headers list.")]
            string Content_Type,
            [OSParameter(Description = "Status of the request. \"OK\" if the request was successfull (200).")]
            out string Status,
            [OSParameter(Description = "HTTP Status code in numeric form.")]
            out int Status_Code,
            [OSParameter(Description = "Headers from the response.")]
            out IEnumerable < HttpHeader > Response_Headers,
            [OSParameter(Description = "Response as Text")]
            out string Response,
            [OSParameter(Description = "Extra HTTP headers to add to the request.\r\n\r\nSpecial headers:\r\n\r\nTimeout: int, sets the timeout for the request\r\nNoPreAuth: revert to .NET's default authentication behavior\r\nNoAutoCompression: disable attempting to auto-compress response.")]
            IEnumerable<HttpHeader> ? Headers = null,
            [OSParameter(Description = "Username to use for HTTP Basic authentication.")]
            string ? Username = null,
            [OSParameter(Description = "Password to use for HTTP Basic authentication.")]
            string ? Password = null);

        /// <summary>
        ///Perform an HTTP PUT request.
        /// </summary>
        [OSAction(Description = "Perform an HTTP PUT request.", IconResourceName = "ArdoHTTP.resources.logo.png", ReturnName = "HTTPResponse")]
        public void HTTPPut(
            [OSParameter(Description = "The URL to access. MUST contain http:// or https://")]
            string URL,
            [OSParameter(Description = "Request content")]
            string Data,
            [OSParameter(Description = "Value for Content-Type header. If set, overrides anything set on the Headers list.")]
            string Content_Type,
            [OSParameter(Description = "Status of the request. \"OK\" if the request was successfull (200).")]
            out string Status,
            [OSParameter(Description = "HTTP Status code in numeric form.")]
            out int Status_Code,
            [OSParameter(Description = "Headers from the response.")]
            out IEnumerable < HttpHeader > Response_Headers,
            [OSParameter(Description = "Response as Text")]
            out string Response,
            [OSParameter(Description = "Extra HTTP headers to add to the request.\r\n\r\nSpecial headers:\r\n\r\nTimeout: int, sets the timeout for the request\r\nNoPreAuth: revert to .NET's default authentication behavior\r\nNoAutoCompression: disable attempting to auto-compress response.")]
            IEnumerable<HttpHeader> ? Headers = null,
            [OSParameter(Description = "Username to use for HTTP Basic authentication.")]
            string ? Username = null,
            [OSParameter(Description = "Password to use for HTTP Basic authentication.")]
            string ? Password = null);

        /// <summary>
        ///Implementation of RFC 6570 to allow templating your URLs.
        ///Supports any kind of template and simple string keys. Does not support array or dictionary keys.
        /// </summary>
        [OSAction(Description = "Implementation of RFC 6570 to allow templating your URLs.\r\n\r\nSupports any kind of template and simple string keys. Does not support array or dictionary keys.", IconResourceName = "ArdoHTTP.resources.logo.png", ReturnName = "URL")]
        public string URLTemplate(
            [OSParameter(Description = "The URL to access. MUST contain http:// or https://")]
            string Template,
            [OSParameter(Description = "List of name/value pairs with the variables to use in the URL Template.")]
             IEnumerable<TemplateVar> Variables);
        
    }
}