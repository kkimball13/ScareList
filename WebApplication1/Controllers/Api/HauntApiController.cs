using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models.Requests.Haunts;
using WebApplication1.Models.Responses;
using WebApplication1.Services.Haunts;

namespace WebApplication1.Controllers.Api
{
    [RoutePrefix("api/haunts")]
    public class HauntApiController : ApiController
    {
        
        [Route, HttpPost]
        public HttpResponseMessage Add(HauntAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = HauntService.Insert(model);

            return Request.CreateResponse(response);


        }



    }
}
