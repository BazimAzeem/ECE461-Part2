/*
 * ECE 461 - Spring 2023 - Project 2
 *
 * API for ECE 461/Spring 2023/Project 2: A Trustworthy Module Registry
 *
 * OpenAPI spec version: 2.3.5
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
using Microsoft.AspNetCore.Authorization;
using PackageRegistry.Models;
using PackageRegistry.MetricsCalculation;

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
            Program.LogDebug("Request: PUT /authenticate\n" + body.ToString());

            int code;
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // response = StatusCode(200, default(string));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 501 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            code = 501;
            Program.LogDebug("Response: PUT /authenticate\n" + "response: " + code);

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
        public virtual IActionResult PackageByNameDelete([FromHeader] string xAuthorization, [FromRoute][Required] string name)
        {
            Program.LogDebug("Request: DELETE /package/byName/{name}\n" + "name: " + name.ToString());

            int code;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            code = 400;
            Program.LogDebug("Response: DELETE /package/byName/{name}\n" + "response: " + code + "\nNot implemented." + "name: " + name.ToString());
            return StatusCode(code);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(404);

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
        [HttpGet]
        [Route("/package/byName/{name}")]
        [ValidateModelState]
        [SwaggerOperation("PackageByNameGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageHistoryEntry>), description: "Return the package history.")]
        public virtual IActionResult PackageByNameGet([FromRoute][Required] string name, [FromHeader] string xAuthorization)
        {
            Program.LogDebug("Request: GET /package/byName/{name}\n" + "name: " + name.ToString());

            int code;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(List<PackageHistoryEntry>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            code = 400;
            Program.LogDebug("Response: GET /package/byName/{name}\n" + "response: " + code + "\nNot implemented." + "name: " + name.ToString());
            return StatusCode(code);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(404);
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
        /// <response code="200">Return a list of packages.</response>
        /// <response code="400">There is missing field(s) in the PackageRegEx/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">No package found under this regex.</response>
        [HttpPost]
        [Route("/package/byRegEx")]
        [ValidateModelState]
        [SwaggerOperation("PackageByRegExGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageMetadata>), description: "Return a list of packages.")]
        public virtual IActionResult PackageByRegExGet([FromBody] PackageRegEx body, [FromHeader] string xAuthorization)
        {
            Program.LogDebug("Request: POST /package/byRegex/{regex}\n" + body.ToString() + "regex: " + body.ToString());

            int code;

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(List<PackageMetadata>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            code = 400;
            Program.LogDebug("Response: POST /package/byRegex/{regex}\n" + "response: " + code + "\nNot implemented." + "regex: " + body.ToString());
            return StatusCode(code);

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
        /// <response code="400">There is missing field(s) in the PackageData/AuthenticationToken or it is formed improperly (e.g. Content and URL are both set), or the AuthenticationToken is invalid.</response>
        /// <response code="409">Package exists already.</response>
        /// <response code="424">Package is not uploaded due to the disqualified rating.</response>
        [HttpPost]
        [Route("/package")]
        [ValidateModelState]
        [SwaggerOperation("PackageCreate")]
        [SwaggerResponse(statusCode: 201, type: typeof(Package), description: "Success. Check the ID in the returned metadata for the official ID.")]
        public async virtual Task<IActionResult> PackageCreate([FromBody] PackageData body, [FromHeader] string xAuthorization)
        {
#if !NO_GCP
            Program.LogDebug("Request: POST /package\n" + body.ToString());

            int code;
            Package package;
            if (!string.IsNullOrWhiteSpace(body.Content) && string.IsNullOrWhiteSpace(body.URL))
            {
                try
                {
                    package = await Package.CreateFromContent(body.Content);
                }
                catch (System.Exception e)
                {
                    code = 400;
                    Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nFailed to create package from content." + "\nexception: " + e.ToString() + "\nbody" + body.ToString());
                    return StatusCode(code);
                }
            }
            else if (!string.IsNullOrWhiteSpace(body.URL) && string.IsNullOrWhiteSpace(body.Content))
            {
                try
                {
                    package = await Package.CreateFromURL(body.URL);
                }
                catch (System.Exception e)
                {
                    code = 400;
                    Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nFailed to create package from URL." + "\nexception: " + e.ToString() + "\nbody" + body.ToString());
                    return StatusCode(code);
                }
            }
            else
            {
                code = 400;
                Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nInvalid request format." + "\nbody" + body.ToString());
                return StatusCode(code);
            }
            package.Data.JSProgram = body.JSProgram;

            MetricsCalculator mc = null;
            try
            {
                mc = new MetricsCalculator(package.Data.URL);
                if (mc.error_level == MetricsCalculator.ERROR_ERROR)
                {
                    code = 400;
                    Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nError in metric calculations." + "\nbody" + body.ToString());
                    return StatusCode(code);
                }
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nFailed to calculate metrics." + "\nexception: " + e.ToString() + "\nbody" + body.ToString());
                return StatusCode(code);
            }

            if (mc.Calculate() < 0)
            {
                code = 424;
                Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nScore is too low" + "\nmetrics: " + mc.ToString());
                return StatusCode(code);
            }

            int id = 0;
            try
            {
                id = await Program.db.InsertIntoPackageTable(package);
            }
            catch (Npgsql.PostgresException e)
            {
                if (e.SqlState == Npgsql.PostgresErrorCodes.UniqueViolation)
                {
                    code = 409;
                    Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nPackage already exists." + "\nbody" + body.ToString());
                    return StatusCode(code);
                }
                else
                {
                    code = 400;
                    Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nFailed to insert package into database. Unexpected PostgreSQL error." + "\nexception: " + e.ToString() + "\nbody" + body.ToString());
                    return StatusCode(code);
                }
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: POST /package\n" + "response: " + code + "\nFailed to insert package into database." + "\nexception: " + e.ToString() + "\nbody" + body.ToString());
                return StatusCode(code);
            }
            package.Metadata.ID = id.ToString();

            code = 201;
            Program.LogDebug("Response: POST /package\n" + "response: " + code + "\npackage: " + package.ToString());
            return StatusCode(code, package);

            // string exampleJson = null;
            // exampleJson = "{\n  \"metadata\" : {\n    \"Version\" : \"1.2.3\",\n    \"ID\" : \"ID\",\n    \"Name\" : \"Name\"\n  },\n  \"data\" : {\n    \"Content\" : \"Content\",\n    \"JSProgram\" : \"JSProgram\",\n    \"URL\" : \"URL\"\n  }\n}";

            // var example = exampleJson != null
            // ? JsonConvert.DeserializeObject<Package>(exampleJson)
            // : default(Package);            //TODO: Change the data returned
            // return new ObjectResult(example);
#else
            return StatusCode(400);
#endif
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
        public async virtual Task<IActionResult> PackageDelete([FromHeader] string xAuthorization, [FromRoute][Required] string id)
        {
            Program.LogDebug("Request: DELETE /package/{id}\n" + "id: " + id);

            int code;

            bool exists = false;
            try
            {
                exists = await Program.db.ExistsInPackageTable(id);
            }
            catch (System.Exception e)
            {
                code = 404;
                Program.LogDebug("Response: DELETE /package/{id}\n" + "response: " + code + "\nCould not check exists." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            if (!exists)
            {
                code = 404;
                Program.LogDebug("Response: DELETE /package/{id}\n" + "response: " + code + "\nPackage does not exist." + "\nid: " + id);
                return StatusCode(code);
            }

            try
            {
                await Program.db.DeleteFromPackageTable(id);
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: DELETE /package/{id}\n" + "response: " + code + "\nCould not delete from database." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            code = 200;
            Program.LogDebug("Response: DELETE /package/{id}\n" + "response: " + code + "\nSuccessfully deleted." + "\nid: " + id);
            return StatusCode(code);
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
        public async virtual Task<IActionResult> PackageRate([FromRoute][Required] string id, [FromHeader] string xAuthorization)
        {
            Program.LogDebug("Request: GET /package/{id}/rate\n" + "id: " + id);

            int code;

            bool exists = false;
            try
            {
                exists = await Program.db.ExistsInPackageTable(id);
            }
            catch (System.Exception e)
            {
                code = 404;
                Program.LogDebug("Response: GET /package/{id}/rate\n" + "response: " + code + "\nCould not check exists." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            if (!exists)
            {
                code = 404;
                Program.LogDebug("Response: GET /package/{id}/rate\n" + "response: " + code + "\nPackage does not exist." + "\nid: " + id);
                return StatusCode(code);
            }

            string url = null;
            try
            {
                url = await Program.db.SelectURLFromPackage(id);
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: GET /package/{id}/rate\n" + "response: " + code + "\nCould not fetch URL." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            MetricsCalculator mc = null;
            try
            {
                mc = new MetricsCalculator(url);
                if (mc.error_level == MetricsCalculator.ERROR_ERROR)
                {
                    code = 500;
                    Program.LogDebug("Response: GET /package/{id}/rate\n" + "response: " + code + "\nError in metric calculations.");
                    return StatusCode(code);
                }
            }
            catch (System.Exception e)
            {
                code = 500;
                Program.LogDebug("Response: GET /package/{id}/rate\n" + "response: " + code + "\nFailed to calculate metrics." + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            PackageRating rating = new PackageRating();
            rating.NetScore = mc.Calculate();
            rating.BusFactor = mc.BusFactor.score;
            rating.Correctness = mc.Correctness.score;
            rating.RampUp = mc.RampUp.score;
            rating.ResponsiveMaintainer = mc.ResponsiveMaintainer.score;
            rating.LicenseScore = mc.LicenseScore.score;
            rating.GoodPinningPractice = mc.GoodPinningPractice.score;
            rating.PullRequest = mc.PullRequest.score;

            code = 200;
            Program.LogDebug("Response: GET /package/{id}/rate\n" + "response: " + code + "\nrating: " + rating.ToString());
            return StatusCode(code, rating);

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(PackageRating));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 500 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
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
        /// <response code="200">Return the package. Content is required.</response>
        /// <response code="400">There is missing field(s) in the PackageID/AuthenticationToken or it is formed improperly, or the AuthenticationToken is invalid.</response>
        /// <response code="404">Package does not exist.</response>
        [HttpGet]
        [Route("/package/{id}")]
        [ValidateModelState]
        [SwaggerOperation("PackageRetrieve")]
        [SwaggerResponse(statusCode: 200, type: typeof(Package), description: "Return the package.")]
        public async virtual Task<IActionResult> PackageRetrieve([FromHeader] string xAuthorization, [FromRoute][Required] string id)
        {
            Program.LogDebug("Request: GET /package/{id}\n" + "id: " + id);

            int code;

            bool exists = false;
            try
            {
                exists = await Program.db.ExistsInPackageTable(id);
            }
            catch (System.Exception e)
            {
                code = 404;
                Program.LogDebug("Response: GET /package/{id}\n" + "response: " + code + "\nCould not check exists." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            if (!exists)
            {
                code = 404;
                Program.LogDebug("Response: GET /package/{id}\n" + "response: " + code + "\nPackage does not exist." + "\nid: " + id);
                return StatusCode(code);
            }

            Package package = null;
            try
            {
                package = await Program.db.SelectFromPackage(id);
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: GET /package/{id}\n" + "response: " + code + "\nCould not get from database." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            code = 200;
            Program.LogDebug("Response: GET /package/{id}\n" + "response: " + code + "\nid: " + id + "\npackage: " + package.ToString());
            return StatusCode(code, package);

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(Package));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
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
        public async virtual Task<IActionResult> PackageUpdate([FromBody] Package body, [FromHeader] string xAuthorization, [FromRoute][Required] string id)
        {
            Program.LogDebug("Request: PUT /package/{id}\n" + "id: " + id + "\nbody: " + body.ToString());

            int code;

            if (id != body.Metadata.ID)
            {
                code = 400;
                Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\n IDs do not match.");
                return StatusCode(code);
            }


            Package package = null;
            if (!string.IsNullOrWhiteSpace(body.Data.Content) && string.IsNullOrWhiteSpace(body.Data.URL))
            {
                try
                {
                    package = await Package.CreateFromContent(body.Data.Content);
                }
                catch (System.Exception e)
                {
                    code = 400;
                    Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\nFailed to create package from content." + "\nexception: " + e.ToString());
                    return StatusCode(code);
                }
            }
            else if (!string.IsNullOrWhiteSpace(body.Data.URL) && string.IsNullOrWhiteSpace(body.Data.Content))
            {
                try
                {
                    package = await Package.CreateFromURL(body.Data.URL);
                }
                catch (System.Exception e)
                {
                    code = 400;
                    Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\nFailed to create package from URL." + "\nexception: " + e.ToString());
                    return StatusCode(code);
                }
            }
            else
            {
                code = 400;
                Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\nInvalid request format.");
                return StatusCode(code);
            }
            package.Data.JSProgram = body.Data.JSProgram;

            bool exists = false;
            try
            {
                exists = await Program.db.ExistsInPackageTable(body.Metadata);
            }
            catch (System.Exception e)
            {
                code = 404;
                Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\nCould not check exists." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            if (!exists)
            {
                code = 404;
                Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\nPackage does not exist." + "\nid: " + id);
                return StatusCode(code);
            }

            try
            {
                await Program.db.UpdatePackageTable(id, body.Data);
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\nCould not update database." + "\nid: " + id + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            code = 200;
            Program.LogDebug("Response: PUT /package/{id}\n" + "response: " + code + "\nSuccessfully updated." + "\nid: " + id);
            return StatusCode(code);
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
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
        [HttpPost]
        [Route("/packages")]
        [ValidateModelState]
        [SwaggerOperation("PackagesList")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<PackageMetadata>), description: "List of packages")]
        public async virtual Task<IActionResult> PackagesList([FromBody] List<PackageQuery> body, [FromHeader] string xAuthorization, [FromQuery] string offset)
        {
            Program.LogDebug("Request: POST /packages\n" + "body: " + string.Join("\n", body.ConvertAll<string>(x => x.ToString())) + "\noffset: " + offset);

            int code;

            List<PackageMetadata> packages = null;
            try
            {
                packages = await Program.db.SelectFromPackage();
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: POST /packages\n" + "response: " + code + "\nCould not get packages." + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            code = 200;
            Program.LogDebug("Response: POST /packages\n" + "response: " + code + "\npackages: \n" + string.Join("\n", packages.ConvertAll<string>(x => x.ToString())));
            return StatusCode(code, packages);

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(200, default(List<PackageMetadata>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 413 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(413);
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
        public async virtual Task<IActionResult> RegistryReset([FromHeader] string xAuthorization)
        {
#if !NO_GCP
            Program.LogDebug("Request: DELETE /reset\n");

            int code;

            try
            {
                await Program.db.ResetPackageTable();
            }
            catch (System.Exception e)
            {
                code = 400;
                Program.LogDebug("Response: DELETE /reset\n" + "response: " + code + "\nexception: " + e.ToString());
                return StatusCode(code);
            }

            code = 200;
            Program.LogDebug("Response: DELETE /reset\n" + "response: " + code);
            return StatusCode(code);
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..),-...
            // return StatusCode(401);
#else
            return StatusCode(400);
#endif
        }
    }
}
