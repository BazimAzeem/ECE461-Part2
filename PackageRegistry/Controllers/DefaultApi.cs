/*
 * ECE 461 - Spring 2023 - Project 2
 *
 * API for ECE 461/Spring 2023/Project 2: A Trustworthy Module Registry
 *
 * OpenAPI spec version: 2.0.0
 * Contact: davisjam@purdue.edu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using PackageRegistry.Attributes;
using PackageRegistry.Security;
using Microsoft.AspNetCore.Authorization;
using PackageRegistry.Models;

namespace PackageRegistry.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Create an access token.</remarks>
        /// <param name="body"></param>
        /// <response code="200">Return an AuthenticationToken.</response>
        /// <response code="400">There is missing field(s) in the AuthenticationRequest or it is formed improperly.</response>
        /// <response code="401">The user or password is invalid.</response>
        /// <response code="501">This system does not support authentication.</response>
        [HttpPut]
        [Route("/authenticate")]
        [ValidateModelState]
        [SwaggerOperation("CreateAuthToken")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "Return an AuthenticationToken.")]
        public virtual IActionResult CreateAuthToken([FromBody] AuthenticationRequest body)
        {
            Program.WriteLogEntry("PUT-.authenticate", "PUT /authenticate\n" + body.ToString());

            int code;
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // response = StatusCode(200, default(string));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 501 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            code = 501;
            Program.WriteLogEntry("PUT-.authenticate", "PUT /authenticate\n" + "response: " + code);

            return StatusCode(code);
            // string exampleJson = null;
            // exampleJson = "\"\"";

            // var example = exampleJson != null
            // ? JsonConvert.DeserializeObject<string>(exampleJson)
            // : default(string);            //TODO: Change the data returned
            // return new ObjectResult(example);
        }

        /// <summary>
        /// Delete all versions of this package.
        /// </summary>
        /// <param name="xAuthorization"></param>
        /// <param name="name"></param>
        /// <response code="200">Package is deleted.</response>
        /// <response code="400">There is missing field(s) in the PackageName/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">Package does not exist.</response>
        [HttpDelete]
        [Route("/package/byName/{name}")]
        [ValidateModelState]
        [SwaggerOperation("PackageByNameDelete")]
        public virtual IActionResult PackageByNameDelete([FromHeader][Required()] string xAuthorization, [FromRoute][Required] string name)
        {
            Program.WriteLogEntry("DELETE-.package.byName.{name}", "DELETE /package/byName/{name}\n" + "name: " + name.ToString());

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            return StatusCode(404);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Return the history of this package (all versions).</remarks>
        /// <param name="name"></param>
        /// <param name="xAuthorization"></param>
        /// <response code="200">Return the package history.</response>
        /// <response code="400">There is missing field(s) in the PackageName/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">No such package.</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("/package/byName/{name}")]
        [ValidateModelState]
        [SwaggerOperation("PackageByNameGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageHistoryEntry>), description: "Return the package history.")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult PackageByNameGet([FromRoute][Required] string name, [FromHeader][Required()] string xAuthorization)
        {
            Program.WriteLogEntry("GET-.package.byName.{name}", "GET /package/byName/{name}\n" + "name: " + name.ToString());

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(List<PackageHistoryEntry>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            return StatusCode(404);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(0, default(Error));
            string exampleJson = null;
            exampleJson = "[ {\n  \"Action\" : \"CREATE\",\n  \"User\" : {\n    \"name\" : \"Alfalfa\",\n    \"isAdmin\" : true\n  },\n  \"PackageMetadata\" : {\n    \"Version\" : \"1.2.3\",\n    \"ID\" : \"ID\",\n    \"Name\" : \"Name\"\n  },\n  \"Date\" : \"2023-03-23T23:11:15Z\"\n}, {\n  \"Action\" : \"CREATE\",\n  \"User\" : {\n    \"name\" : \"Alfalfa\",\n    \"isAdmin\" : true\n  },\n  \"PackageMetadata\" : {\n    \"Version\" : \"1.2.3\",\n    \"ID\" : \"ID\",\n    \"Name\" : \"Name\"\n  },\n  \"Date\" : \"2023-03-23T23:11:15Z\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<PackageHistoryEntry>>(exampleJson)
            : default(List<PackageHistoryEntry>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get any packages fitting the regular expression.
        /// </summary>
        /// <remarks>Search for a package using regular expression over package names and READMEs. This is similar to search by name.</remarks>
        /// <param name="body"></param>
        /// <param name="xAuthorization"></param>
        /// <param name="regex"></param>
        /// <response code="200">Return a list of packages.</response>
        /// <response code="400">There is missing field(s) in the PackageRegEx/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">No package found under this regex.</response>
        [HttpPost]
        [Route("/package/byRegEx/{regex}")]
        [ValidateModelState]
        [SwaggerOperation("PackageByRegExGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageMetadata>), description: "Return a list of packages.")]
        public async virtual Task<IActionResult> PackageByRegExGet([FromBody] string body, [FromHeader][Required()] string xAuthorization, [FromRoute][Required] string regex)
        {
            Program.WriteLogEntry("POST-.package.byRegEx.{regex}", "POST /package/byRegex/{regex}\n" + body.ToString() + "\nregex: " + regex.ToString());

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(List<PackageMetadata>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(404);
            string exampleJson = null;
            exampleJson = "[ {\n  \"Version\" : \"1.2.3\",\n  \"ID\" : \"ID\",\n  \"Name\" : \"Name\"\n}, {\n  \"Version\" : \"1.2.3\",\n  \"ID\" : \"ID\",\n  \"Name\" : \"Name\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<PackageMetadata>>(exampleJson)
            : default(List<PackageMetadata>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="xAuthorization"></param>
        /// <response code="201">Success. Check the ID in the returned metadata for the official ID.</response>
        /// <response code="400">There is missing field(s) in the PackageData/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="409">Package exists already.</response>
        /// <response code="424">Package is not uploaded due to the disqualified rating.</response>
        [HttpPost]
        [Route("/package")]
        [ValidateModelState]
        [SwaggerOperation("PackageCreate")]
        [SwaggerResponse(statusCode: 201, type: typeof(Package), description: "Success. Check the ID in the returned metadata for the official ID.")]
        public async virtual Task<IActionResult> PackageCreate([FromBody] PackageData body, [FromHeader][Required()] string xAuthorization)
        {
            Program.WriteLogEntry(
                "POST-.package",
                "POST /package\n" +
                body.ToString()
            );

            ActionResult response;

            var item = new Dictionary<string, string> {
                {"name", "'bazim'"},
                {"version_major", "1"},
                {"version_minor", "2"},
                {"version_patch", "3"},
                {"content", "''"},
                {"url", "'https://github.com/pytorch/pytorch'"},
                {"js_program", "''"},
            };

            int id = await Program.db.packageTable.Insert(item);


            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(201, default(Package));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 409 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(409);

            //TODO: Uncomment the next line to return response 424 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            return StatusCode(424);
            string exampleJson = null;
            exampleJson = "{\n  \"metadata\" : {\n    \"Version\" : \"1.2.3\",\n    \"ID\" : \"ID\",\n    \"Name\" : \"Name\"\n  },\n  \"data\" : {\n    \"Content\" : \"Content\",\n    \"JSProgram\" : \"JSProgram\",\n    \"URL\" : \"URL\"\n  }\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Package>(exampleJson)
            : default(Package);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Delete this version of the package.
        /// </summary>
        /// <param name="xAuthorization"></param>
        /// <param name="id">Package ID</param>
        /// <response code="200">Package is deleted.</response>
        /// <response code="400">There is missing field(s) in the PackageID/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">Package does not exist.</response>
        [HttpDelete]
        [Route("/package/{id}")]
        [ValidateModelState]
        [SwaggerOperation("PackageDelete")]
        public virtual IActionResult PackageDelete([FromHeader][Required()] string xAuthorization, [FromRoute][Required] string id)
        {
            Program.WriteLogEntry("DELETE-.package.{id}", "DELETE /package/{id}\n" + "id: " + id);

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(404);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="xAuthorization"></param>
        /// <response code="200">Return the rating. Only use this if each metric was computed successfully.</response>
        /// <response code="400">There is missing field(s) in the PackageID/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">Package does not exist.</response>
        /// <response code="500">The package rating system choked on at least one of the metrics.</response>
        [HttpGet]
        [Route("/package/{id}/rate")]
        [ValidateModelState]
        [SwaggerOperation("PackageRate")]
        [SwaggerResponse(statusCode: 200, type: typeof(PackageRating), description: "Return the rating. Only use this if each metric was computed successfully.")]
        public virtual IActionResult PackageRate([FromRoute][Required] string id, [FromHeader][Required()] string xAuthorization)
        {
            Program.WriteLogEntry("GET-.package.{id}.rate", "GET /package/{id}/rate\n" + "id: " + id);

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(PackageRating));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(500);
            string exampleJson = null;
            exampleJson = "{\n  \"GoodPinningPractice\" : 2.3021358869347655,\n  \"NetScore\" : 9.301444243932576,\n  \"PullRequest\" : 7.061401241503109,\n  \"ResponsiveMaintainer\" : 5.962133916683182,\n  \"LicenseScore\" : 5.637376656633329,\n  \"RampUp\" : 1.4658129805029452,\n  \"BusFactor\" : 0.8008281904610115,\n  \"Correctness\" : 6.027456183070403\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<PackageRating>(exampleJson)
            : default(PackageRating);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Interact with the package with this ID
        /// </summary>
        /// <remarks>Return this package.</remarks>
        /// <param name="xAuthorization"></param>
        /// <param name="id">ID of package to fetch</param>
        /// <response code="200">Return the package.</response>
        /// <response code="400">There is missing field(s) in the PackageID/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">Package does not exist.</response>
        /// <response code="0">unexpected error</response>
        [HttpGet]
        [Route("/package/{id}")]
        [ValidateModelState]
        [SwaggerOperation("PackageRetrieve")]
        [SwaggerResponse(statusCode: 200, type: typeof(Package), description: "Return the package.")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult PackageRetrieve([FromHeader][Required()] string xAuthorization, [FromRoute][Required] string id)
        {
            Program.WriteLogEntry("GET-.package.{id}", "GET /package/{id}\n" + "id: " + id);

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(Package));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(0, default(Error));
            string exampleJson = null;
            exampleJson = "{\n  \"metadata\" : {\n    \"Version\" : \"1.2.3\",\n    \"ID\" : \"ID\",\n    \"Name\" : \"Name\"\n  },\n  \"data\" : {\n    \"Content\" : \"Content\",\n    \"JSProgram\" : \"JSProgram\",\n    \"URL\" : \"URL\"\n  }\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Package>(exampleJson)
            : default(Package);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Update this content of the package.
        /// </summary>
        /// <remarks>The name, version, and ID must match.  The package contents (from PackageData) will replace the previous contents.</remarks>
        /// <param name="body"></param>
        /// <param name="xAuthorization"></param>
        /// <param name="id"></param>
        /// <response code="200">Version is updated.</response>
        /// <response code="400">There is missing field(s) in the PackageID/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">Package does not exist.</response>
        [HttpPut]
        [Route("/package/{id}")]
        [ValidateModelState]
        [SwaggerOperation("PackageUpdate")]
        public virtual IActionResult PackageUpdate([FromBody] Package body, [FromHeader][Required()] string xAuthorization, [FromRoute][Required] string id)
        {
            Program.WriteLogEntry("PUT-.package.{id}", "PUT /package/{id}\n" + body.ToString() + "\nid: " + id);

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(404);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the packages from the registry.
        /// </summary>
        /// <remarks>Get any packages fitting the query. Search for packages satisfying the indicated query.  If you want to enumerate all packages, provide an array with a single PackageQuery whose name is \&quot;*\&quot;.  The response is paginated; the response header includes the offset to use in the next query.</remarks>
        /// <param name="body"></param>
        /// <param name="xAuthorization"></param>
        /// <param name="offset">Provide this for pagination. If not provided, returns the first page of results.</param>
        /// <response code="200">List of packages</response>
        /// <response code="400">There is missing field(s) in the PackageQuery/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="413">Too many packages returned.</response>
        /// <response code="0">unexpected error</response>
        [HttpPost]
        [Route("/packages")]
        [ValidateModelState]
        [SwaggerOperation("PackagesList")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageMetadata>), description: "List of packages")]
        [SwaggerResponse(statusCode: 0, type: typeof(Error), description: "unexpected error")]
        public virtual IActionResult PackagesList([FromBody] List<PackageQuery> body, [FromHeader][Required()] string xAuthorization, [FromQuery] string offset)
        {
            Program.WriteLogEntry("POST-.packages", "POST /packages\n" + body.ToString() + "\noffset: " + offset);

            ActionResult response;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(List<PackageMetadata>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 413 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(413);

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(0, default(Error));
            string exampleJson = null;
            exampleJson = "[ {\n  \"Version\" : \"1.2.3\",\n  \"ID\" : \"ID\",\n  \"Name\" : \"Name\"\n}, {\n  \"Version\" : \"1.2.3\",\n  \"ID\" : \"ID\",\n  \"Name\" : \"Name\"\n} ]";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<PackageMetadata>>(exampleJson)
            : default(List<PackageMetadata>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Reset the registry
        /// </summary>
        /// <remarks>Reset the registry to a system default state.</remarks>
        /// <param name="xAuthorization"></param>
        /// <response code="200">Registry is reset.</response>
        /// <response code="400">There is missing field(s) in the AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="401">You do not have permission to reset the registry.</response>
        [HttpDelete]
        [Route("/reset")]
        [ValidateModelState]
        [SwaggerOperation("RegistryReset")]
        public async virtual Task<IActionResult> RegistryReset([FromHeader][Required()] string xAuthorization)
        {
            Program.WriteLogEntry("DELETE-.reset", "DELETE /reset\n");

            int code;

            try
            {
                await Program.db.packageTable.Delete();
                code = 200;
            }
            catch (System.Exception)
            {
                code = 400;
            }

            return StatusCode(code);
        }
    }
}
