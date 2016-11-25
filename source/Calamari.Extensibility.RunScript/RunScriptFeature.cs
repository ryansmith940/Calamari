﻿using Calamari.Extensibility.Features;
using Calamari.Shared;

namespace Calamari.Extensibility.RunScript
{
    [Feature("RunScript", "I Am A Run Script")]
    public class RunScriptFeature : IFeature
    {
        private readonly IPackageExtractor extractor;
        private readonly IScriptExecution executor;
        private readonly IFileSubstitution substitutor;

        public RunScriptFeature(IPackageExtractor extractor, IScriptExecution executor, IFileSubstitution substitutor)
        {
            this.extractor = extractor;
            this.executor = executor;
            this.substitutor = substitutor;
        }

        public void Install(IVariableDictionary variables)
        {
            var script = variables.Get(SpecialVariables.Action.Script.Path);
            var parameters = variables.Get(SpecialVariables.Action.Script.Parameters);
            var package = variables.Get(SpecialVariables.Action.Script.PackagePath);

            if (!string.IsNullOrWhiteSpace(package))
            {
                extractor.Extract(package, PackageExtractionLocation.WorkingDirectory);
            }

            substitutor.PerformSubstitution(script);
            executor.Invoke(script, parameters);
        }
    }
}
