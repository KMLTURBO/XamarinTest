using Xamarin.Forms;
using Acquaint.XForms;

[assembly: Dependency (typeof (CapabilityService))]

namespace Acquaint.XForms
{
    public class CapabilityService : ICapabilityService
    {
        readonly IEnvironmentService _EnvironmentService;

        public CapabilityService()
        {
            _EnvironmentService = DependencyService.Get<IEnvironmentService>();
        }

        #region ICapabilityService implementation

        public bool CanMakeCalls => _EnvironmentService.IsRealDevice || (Device.OS != TargetPlatform.iOS);

        public bool CanSendMessages => _EnvironmentService.IsRealDevice || (Device.OS != TargetPlatform.iOS);

        public bool CanSendEmail => _EnvironmentService.IsRealDevice || (Device.OS != TargetPlatform.iOS);

        #endregion
    }
}

