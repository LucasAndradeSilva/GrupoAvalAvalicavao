using GrupoAval.Helpers;

namespace GrupoAval.Models
{
    public class Alert : IDisposable
    {
        public Alert()
        {
            
        }
        public Alert(AlertType type, string message, HttpContext context)
        {
            Type = type;
            Message = message;

            context.Session.Set(this, SessionHelper.SessionKeys.Alert.ToString());
        }

        public enum AlertType
        {
            primary,
            secondary,
            success,
            danger,
            warning,
            info,
            light,
            dark
        }

        public AlertType Type { get; set; }
        public string Message { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
