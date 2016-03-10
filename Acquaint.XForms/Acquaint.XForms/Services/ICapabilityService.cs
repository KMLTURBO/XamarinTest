
namespace Acquaint.XForms
{
    public interface ICapabilityService
    {
        bool CanMakeCalls { get; }
        bool CanSendMessages { get; }
        bool CanSendEmail { get; }
    }
}

