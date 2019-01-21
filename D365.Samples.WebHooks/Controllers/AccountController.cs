﻿using D365.Samples.WebHooks.Helpers;
using D365.Samples.WebHooks.Models;
using DynamicsCrmMappingUtility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace D365.Samples.WebHook.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        [HttpGet]
        public string Get() {
            return "Dynamics 365 Mapping Utility";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] JObject data) {            
            JObject postImage = (JObject)data["PostEntityImages"][0]["value"];

            // instantiate model
            AccountModel model = new AccountModel();

            // map JObject data to model
            DynamicsCrmMappingUtility<AccountModel>.CustomMappingMethod = CustomMapsHelper.CustomMapping;
            DynamicsCrmMappingUtility<AccountModel>.MapToModel(postImage, model);

            string accountName = model.AccountName;
            string accountNumber = model.AccountNumber;
        }
    }
}
