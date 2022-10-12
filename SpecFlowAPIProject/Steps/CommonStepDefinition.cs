using System.Collections.Generic;
using TechTalk.SpecFlow;
using RestSharp;

namespace SpecFlowAPIProject.Steps
{
    [Binding]
    public class CommonStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        protected readonly ScenarioContext scenarioContext;

        protected RestClient restClient;
        protected RestRequest restRequest;
        protected RestResponse restResponse;
        protected Dictionary<string, dynamic> dictOfPostsReqData;

        public CommonStepDefinition(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
            dictOfPostsReqData = new Dictionary<string, dynamic>();
        }
    }
}
