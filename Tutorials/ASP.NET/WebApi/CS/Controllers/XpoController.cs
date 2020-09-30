using System.Threading.Tasks;

using DevExpress.Xpo.DB;

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiApplication.Controllers {
    [ApiController]
    [Route("[controller]/[action]")]
    public class XpoController : ControllerBase {
        readonly WebApiDataStoreService DataStoreService;
        public XpoController(WebApiDataStoreService dataStoreService) {
            this.DataStoreService = dataStoreService;
        }
        [HttpGet]
        public string Hello() {
            return "Use WebApiDataStoreClient to connect to this service.";
        }
        [HttpPost]
        [EnableCors("XPO")]
        public Task<OperationResult<UpdateSchemaResult>> UpdateSchema([FromQuery] bool doNotCreateIfFirstTableNotExist, [FromBody] DBTable[] tables) {
            return DataStoreService.UpdateSchemaAsync(doNotCreateIfFirstTableNotExist, tables);
        }
        [HttpPost]
        [EnableCors("XPO")]
        public Task<OperationResult<SelectedData>> SelectData([FromBody] SelectStatement[] selects) {
            return DataStoreService.SelectDataAsync(selects);
        }
        [HttpPost]
        [EnableCors("XPO")]
        public Task<OperationResult<ModificationResult>> ModifyData([FromBody] ModificationStatement[] dmlStatements) {
            return DataStoreService.ModifyDataAsync(dmlStatements);
        }
    }
}
