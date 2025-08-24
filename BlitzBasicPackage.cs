using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace BlitzBasicLanguageSupport
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid(BlitzBasicPackage.PackageGuidString)]
    public sealed class BlitzBasicPackage : AsyncPackage
    {
        public const string PackageGuidString = "186e229c-3ef2-46b3-b75a-7eea251afc03";

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }
    }
}
