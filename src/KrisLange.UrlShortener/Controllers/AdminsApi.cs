/*
 * Link Shortening Service
 *
 * This is an API for a Link Shortening Service
 *
 * OpenAPI spec version: 1.0.0
 * Contact: kris@krislange.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Formats.Asn1;
using KrisLange.UrlShortener.Attributes;
using Microsoft.AspNetCore.Authorization;
using KrisLange.UrlShortener.Models;
using KrisLange.UrlShortener.Store;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web.Resource;
using Microsoft.OpenApi.Writers;

namespace KrisLange.UrlShortener.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class AdminsApiController : ControllerBase
    {
        private readonly IKeyValueStore _kvStore;

        public AdminsApiController(IKeyValueStore kvStore)
        {
            _kvStore = kvStore;
        }

        /// <summary>
        /// adds a link with the specified shortUrlId
        /// </summary>
        /// <remarks>Post a URL to be shortened </remarks>
        /// <param name="postUrlSpec">The URL which needs to be shortened</param>
        /// <response code="200">A new shortURL was created!</response>
        [HttpPut]
        [Route("/lnk")]
        [ValidateModelState]
        [SwaggerOperation("PostUrl")]
        [SwaggerResponse(200, type: typeof(UrlObject), description: "A new shortURL was created!")]
        public virtual IActionResult PostUrl([FromBody]NewUrlSpec postUrlSpec)
        {
            string shortUrlId = Math.Abs(postUrlSpec.GetHashCode()).ToString().Substring(0, 4);
            
            _kvStore.Put(shortUrlId, postUrlSpec.LongUrl);

            UrlObject result = new UrlObject();
            result.ShortUrlId = shortUrlId;
            result.LongUrl = postUrlSpec.LongUrl;
            return this.Ok(result);
        }

        /// <summary>
        /// adds a link with the specified shortUrlId
        /// </summary>
        /// <remarks>Put a URL who&#39;s shortcut is shortUrlId </remarks>
        /// <param name="shortUrlId">the shortUrl ID</param>
        /// <param name="newUrlSpec">The URL which needs to be shortened</param>
        /// <response code="201">A new shortUrl was created!</response>
        [HttpPut]
        [Route("/lnk/{shortUrlId}")]
        [ValidateModelState]
        [SwaggerOperation("PutUrl")]
        [SwaggerResponse(statusCode: 201, type: typeof(UrlObject), description: "A new shortUrl was created!")]
        public virtual IActionResult PutUrl([FromRoute][Required]string shortUrlId, [FromBody]NewUrlSpec newUrlSpec)
        { 
            _kvStore.Put(shortUrlId, newUrlSpec.LongUrl);

            UrlObject result = new UrlObject();
            result.ShortUrlId = shortUrlId;
            result.LongUrl = newUrlSpec.LongUrl;
            return this.Created(shortUrlId, result);
        }
    }
}
