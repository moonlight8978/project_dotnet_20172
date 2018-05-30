using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace Project20172
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            
            routes.MapPageRoute(
                "AdminNovels",
                "admin_novels/{ID}",
                "~/AdminNovels.aspx"
            );

            routes.MapPageRoute(
                "Admin",
                "asddas",
                "~/Admin.aspx"
            );

			routes.MapPageRoute(
				"NovelShow",
				"novels/{ID}",
				"~/Novel.aspx"
			);

			routes.MapPageRoute(
				"ChapterShow",
				"chapters/{ID}",
				"~/Chapter.aspx"
			);
		}
    }
}
