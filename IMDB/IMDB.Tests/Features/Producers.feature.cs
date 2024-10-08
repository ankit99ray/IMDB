﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace IMDB.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class ProducersFeature : object, Xunit.IClassFixture<ProducersFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Producers.feature"
#line hidden
        
        public ProducersFeature(ProducersFeature.FixtureData fixtureData, IMDB_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Producers", "A short summary of the feature", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get all producers")]
        [Xunit.TraitAttribute("FeatureTitle", "Producers")]
        [Xunit.TraitAttribute("Description", "Get all producers")]
        [Xunit.InlineDataAttribute("/api/producers", "200", "Producer/GetAll.json", new string[0])]
        public virtual void GetAllProducers(string route, string status_Code, string response_Data, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("route", route);
            argumentsOfScenario.Add("status_code", status_Code);
            argumentsOfScenario.Add("response_data", response_Data);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get all producers", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("I am a Client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When(string.Format("I send a GET request to \'{0}\'", route), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then(string.Format("I should get a response with status code \'{0}\'", status_Code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
 testRunner.And(string.Format("response data should look like \'{0}\'", response_Data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get producer by Id")]
        [Xunit.TraitAttribute("FeatureTitle", "Producers")]
        [Xunit.TraitAttribute("Description", "Get producer by Id")]
        [Xunit.InlineDataAttribute("/api/producers/1", "200", "Producer/ValidGetById.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers/50", "404", "Producer/InvalidGetById.json", new string[0])]
        public virtual void GetProducerById(string route, string status_Code, string response_Data, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("route", route);
            argumentsOfScenario.Add("status_code", status_Code);
            argumentsOfScenario.Add("response_data", response_Data);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get producer by Id", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 15
 testRunner.Given("I am a Client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.When(string.Format("I send a GET request to \'{0}\'", route), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 17
 testRunner.Then(string.Format("I should get a response with status code \'{0}\'", status_Code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 18
 testRunner.And(string.Format("response data should look like \'{0}\'", response_Data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Add a producer")]
        [Xunit.TraitAttribute("FeatureTitle", "Producers")]
        [Xunit.TraitAttribute("Description", "Add a producer")]
        [Xunit.InlineDataAttribute("/api/producers", "Producer/ValidNew.json", "201", "Producer/ValidNew.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers", "Producer/InvalidNew1.json", "400", "Producer/InvalidNew1.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers", "Producer/InvalidNew2.json", "400", "Producer/InvalidNew2.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers", "Producer/InvalidNew3.json", "400", "Producer/InvalidNew3.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers", "Producer/InvalidNew4.json", "400", "Producer/InvalidNew4.json", new string[0])]
        public virtual void AddAProducer(string route, string request_Data, string status_Code, string response_Data, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("route", route);
            argumentsOfScenario.Add("request_data", request_Data);
            argumentsOfScenario.Add("status_code", status_Code);
            argumentsOfScenario.Add("response_data", response_Data);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a producer", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 25
 testRunner.Given("I am a Client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 26
 testRunner.When(string.Format("I send a POST request to \'{0}\' with data \'{1}\'", route, request_Data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 27
 testRunner.Then(string.Format("I should get a response with status code \'{0}\'", status_Code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 28
 testRunner.And(string.Format("response data should look like \'{0}\'", response_Data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Update producer details")]
        [Xunit.TraitAttribute("FeatureTitle", "Producers")]
        [Xunit.TraitAttribute("Description", "Update producer details")]
        [Xunit.InlineDataAttribute("/api/producers/1", "Producer/ValidUpdate.json", "200", "Producer/ValidUpdate.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers/50", "Producer/InvalidUpdate1.json", "404", "Producer/InvalidUpdate1.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers/1", "Producer/InvalidUpdate2.json", "400", "Producer/InvalidUpdate2.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers/1", "Producer/InvalidUpdate3.json", "400", "Producer/InvalidUpdate3.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers/1", "Producer/InvalidUpdate4.json", "400", "Producer/InvalidUpdate4.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers/1", "Producer/InvalidUpdate5.json", "400", "Producer/InvalidUpdate5.json", new string[0])]
        public virtual void UpdateProducerDetails(string route, string request_Data, string status_Code, string response_Data, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("route", route);
            argumentsOfScenario.Add("request_data", request_Data);
            argumentsOfScenario.Add("status_code", status_Code);
            argumentsOfScenario.Add("response_data", response_Data);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update producer details", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 38
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 39
 testRunner.Given("I am a Client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 40
 testRunner.When(string.Format("I send a PUT request to \'{0}\' with data \'{1}\'", route, request_Data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 41
 testRunner.Then(string.Format("I should get a response with status code \'{0}\'", status_Code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
 testRunner.And(string.Format("response data should look like \'{0}\'", response_Data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Delete a producer")]
        [Xunit.TraitAttribute("FeatureTitle", "Producers")]
        [Xunit.TraitAttribute("Description", "Delete a producer")]
        [Xunit.InlineDataAttribute("/api/producers/1", "200", "Producer/ValidDelete.json", new string[0])]
        [Xunit.InlineDataAttribute("/api/producers/50", "404", "Producer/InvalidDelete.json", new string[0])]
        public virtual void DeleteAProducer(string route, string status_Code, string response_Data, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("route", route);
            argumentsOfScenario.Add("status_code", status_Code);
            argumentsOfScenario.Add("response_data", response_Data);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a producer", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 53
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 54
 testRunner.Given("I am a Client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 55
 testRunner.When(string.Format("I send a DELETE request to \'{0}\'", route), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 56
 testRunner.Then(string.Format("I should get a response with status code \'{0}\'", status_Code), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 57
 testRunner.And(string.Format("response data should look like \'{0}\'", response_Data), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                ProducersFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ProducersFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
