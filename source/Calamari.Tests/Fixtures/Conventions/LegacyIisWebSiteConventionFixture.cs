﻿//#if IIS_SUPPORT
//using System.IO;
//using Calamari.Deployment;
//using Calamari.Extensibility.IIS;
//using Calamari.Deployment.Conventions;
//using Calamari.Extensibility;
//using Calamari.Features;
//using Calamari.Integration.FileSystem;
//using NSubstitute;
//using NUnit.Framework;
//
//namespace Calamari.Tests.Fixtures.Conventions
//{
//    [TestFixture]
//    public class LegacyIisWebSiteConventionFixture
//    {
//        ICalamariFileSystem fileSystem;
//        IInternetInformationServer iis;
//        IVariableDictionary variables;
//        RunningDeployment deployment;
//        const string stagingDirectory = "C:\\Applications\\Acme\\1.0.0";
//
//        [SetUp]
//        public void SetUp()
//        {
//            variables = new CalamariVariableDictionary();
//            fileSystem = Substitute.For<ICalamariFileSystem>();
//            iis = Substitute.For<IInternetInformationServer>();
//            deployment = new RunningDeployment("C:\\packages", variables)
//            {
//                StagingDirectory = stagingDirectory
//            };
//        }
//
//        [Test]
//        public void ShouldUpdatePath()
//        {
//            const string websiteName = "AcmeOnline";
//            variables.Set(SpecialVariables.Package.UpdateIisWebsite, true.ToString());
//            variables.Set(SpecialVariables.Package.UpdateIisWebsiteName, websiteName);
//            fileSystem.FileExists(Path.Combine(stagingDirectory, "Web.config")).Returns(true);
//            iis.OverwriteHomeDirectory(websiteName, stagingDirectory, false).Returns(true);
//
//            CreateConvention().Install(deployment);
//
//            iis.Received().OverwriteHomeDirectory(websiteName, stagingDirectory, false);
//        }
//
//        [Test]
//        public void ShouldUsePackageNameIfWebsiteNameVariableNotSupplied()
//        {
//            const string packageId = "Acme.1.1.1";
//            variables.Set(SpecialVariables.Package.UpdateIisWebsite, true.ToString());
//            variables.Set(SpecialVariables.Package.NuGetPackageId, packageId);
//            fileSystem.FileExists(Path.Combine(stagingDirectory, "Web.config")).Returns(true);
//            iis.OverwriteHomeDirectory(packageId, stagingDirectory, false).Returns(true);
//
//            CreateConvention().Install(deployment);
//
//            iis.Received().OverwriteHomeDirectory(packageId, stagingDirectory, false);
//        }
//
//        [Test]
//        public void ShouldForceIis6CompatibilityIfFlagSet()
//        {
//            const string websiteName = "AcmeOnline";
//            variables.Set(SpecialVariables.Package.UpdateIisWebsite, true.ToString());
//            variables.Set(SpecialVariables.Package.UpdateIisWebsiteName, websiteName);
//            variables.Set(SpecialVariables.UseLegacyIisSupport, true.ToString());
//            fileSystem.FileExists(Path.Combine(stagingDirectory, "Web.config")).Returns(true);
//            iis.OverwriteHomeDirectory(websiteName, stagingDirectory, true).Returns(true);
//
//            CreateConvention().Install(deployment);
//
//            iis.Received().OverwriteHomeDirectory(websiteName, stagingDirectory, true);
//        }
//
//        [Test]
//        public void ShouldNotUpdatePathIfFlagNotSet()
//        {
//            const string websiteName = "AcmeOnline";
//            variables.Set(SpecialVariables.Package.UpdateIisWebsite, false.ToString());
//            variables.Set(SpecialVariables.Package.UpdateIisWebsiteName, websiteName);
//            fileSystem.FileExists(Path.Combine(stagingDirectory, "Web.config")).Returns(true);
//            iis.OverwriteHomeDirectory(websiteName, stagingDirectory, false).Returns(true);
//
//            CreateConvention().Install(deployment);
//
//            iis.DidNotReceive().OverwriteHomeDirectory(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<bool>());
//        }
//
//
//        private LegacyIisWebSiteConvention CreateConvention()
//        {
//            return new LegacyIisWebSiteConvention(fileSystem, iis);
//        }
//    }
//}
//#endif