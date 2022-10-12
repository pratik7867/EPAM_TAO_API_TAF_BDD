using System;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace EPAM_TAO_API_TAF_BDD.APIHelpers
{
    public class ExtentReportHelper
    {
        private static readonly object syncLock = new object();
        private static ExtentReportHelper _extentReportHelper = null;

        public ExtentReports extent { get; set; }
        public ExtentHtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }

        ExtentReportHelper(string strAUT)
        {
            extent = new ExtentReports();

            reporter = new ExtentHtmlReporter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), DateTime.Now.ToString("dd-MM-yyyy")) + @"\" + "TAF_Report.html");
            reporter.Config.DocumentTitle = "API Automation Testing Report";
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AttachReporter(reporter);

            extent.AddSystemInfo("Application Under Test", strAUT);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);            
        }        

        public static ExtentReportHelper GetInstance(string strAUT)
        {
            lock (syncLock)
            {
                if (_extentReportHelper == null)
                {
                    _extentReportHelper = new ExtentReportHelper(strAUT);
                }
                return _extentReportHelper;
            }
        }

        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
        public void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass()
        {
            test.Pass("Test Executed Sucessfully!");
        }
        public void SetTestStatusFail(string message)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>" + $"Message: <br>{message}<br>";
            test.Fail(printMessage);                       
        }        
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }

        public void SetTestNodePassed(string gherkinKeyword, string stepInfo)
        {
            try
            {
                test.CreateNode(gherkinKeyword, stepInfo).Pass("Step Executed Sucessfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SetTestNodeFailed(string gherkinKeyword, string stepInfo, string message, string strPathToSSFile = null)
        {
            try
            {
                var printMessage = "<p><b>Test FAILED!</b></p>" + $"Message: <br>{message}<br>";
                test.CreateNode(gherkinKeyword, stepInfo).Fail("Step Failed!");

                if (!string.IsNullOrEmpty(strPathToSSFile))
                {
                    test.AddScreenCaptureFromPath(strPathToSSFile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CloseExtentReport()
        {
            extent.Flush();         
        }
    }
}
