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
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using KrisLange.UrlShortener.Attributes;

using Microsoft.AspNetCore.Authorization;
using KrisLange.UrlShortener.Models;
using KrisLange.UrlShortener.Store;

namespace KrisLange.UrlShortener.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AnyoneApiController : ControllerBase
    {
        private readonly IKeyValueStore _kvStore;

        public AnyoneApiController(IKeyValueStore kvStore)
        {
            _kvStore = kvStore;
        }
        /// <summary>
        /// fetches Url from shortUrlId
        /// </summary>
        /// <remarks>Get the URL who&#39;s shortcut is shortUrlId </remarks>
        /// <param name="shortUrlId">the shortUrl ID</param>
        /// <response code="301">link exists, follow Location header</response>
        /// <response code="404">link does not exist</response>
        [HttpGet]
        [Route("//lnk/{shortUrlId}")]
        [ValidateModelState]
        [SwaggerOperation("GetUrl")]
        public virtual IActionResult GetUrl([FromRoute][Required]string shortUrlId)
        {
            var longUrl = _kvStore.Get(shortUrlId);

            if (longUrl == null)
            {
                return StatusCode(404);
            }

            return this.Redirect(longUrl);
        }
    }
}
