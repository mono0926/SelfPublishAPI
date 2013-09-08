using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;
using Mono.App.SelfPublishConverter.Converter;
using Mono.App.SelfPublishConverter.Models;

namespace Mono.API.SelfPublish.Controllers
{
    public class BooksController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            string stCurrentDir = System.Environment.CurrentDirectory;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post(Book book)
        {
            var accessToken = this.Request.Headers.Authorization.Scheme;
            if (accessToken == null || accessToken != book.Author.AccessToken)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Exception(""));
            }
            

            var filename = string.Format("{0}-{1}", book.Author.AccessToken, book.Title);
            var filepath = @"";
            if (book.Format == "epub")
            {
                filepath = string.Format(HostingEnvironment.MapPath("~/published/{0}.epub"), filename);
                book.Convert(FormatType.Epub, filepath);
                Debug.WriteLine(book);
            }
            else if (book.Format == "mobi")
            {
                filepath = string.Format(HostingEnvironment.MapPath("~/published/{0}.mobi"), filename);
                book.Convert(FormatType.Kindle, filepath);
                Debug.WriteLine(book);
            }

            var base64String = SelfPublishUtil.ConvertToBase64String(filepath);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, base64String);
            return response;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}