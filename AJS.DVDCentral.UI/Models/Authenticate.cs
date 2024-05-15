using AJS.DVDCentral.BL.Models;
using AJS.DVDCentral.UI.Extensions;

namespace AJS.DVDCentral.UI.Models
{
    public static class Authenticate
    {
        public static bool IsAuthenticated(HttpContext context)
        {
            if (context.Session.GetObject<User>("user") != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
