using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bandienthoai
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           
            routes.MapRoute(
              name: "Product Category",
              url: "san-pham/{GHICHU_LOAISANPHAM}-{id}",
              defaults: new { controller = "SanPham", action = "Category", id = UrlParameter.Optional }

          );
            routes.MapRoute(
            name: "AllProduct Category",
            url: "tat-ca-san-pham",
            defaults: new { controller = "SanPham", action = "Index", id = UrlParameter.Optional }

        );
            routes.MapRoute(
            name: "Promotion Product",
            url: "khuyen-mai",
            defaults: new { controller = "SanPham", action = "KhuyenMai", id = UrlParameter.Optional }

        );
            routes.MapRoute(
            name: "Product Detail",
            url: "chi-tiet/{GHICHU_SANPHAM}-{id}",
            defaults: new { controller = "SanPham", action = "Detail", id = UrlParameter.Optional }

        );
            routes.MapRoute(
           name: "About",
           url: "gioi-thieu",
           defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional }

       );
            routes.MapRoute(
        name: "Add Cart",
        url: "them-gio-hang",
        defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional }

    );
            routes.MapRoute(
      name: "Cart",
      url: "gio-hang",
      defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional }

  );
            routes.MapRoute(
name: "Payment",
url: "thanh-toan",
defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }

);
            routes.MapRoute(
name: "Hoàn Thành",
url: "hoan-thanh",
defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional }

);
            routes.MapRoute(
name: "Liên hệ",
url: "lien-he",
defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }

);
            routes.MapRoute(
name: "Registers",
url: "dang-ky-thanh-vien",
defaults: new { controller = "UserClient", action = "Register", id = UrlParameter.Optional }

);
            routes.MapRoute(
name: "Login",
url: "dang-nhap",
defaults: new { controller = "UserClient", action = "Login", id = UrlParameter.Optional }

);
            routes.MapRoute(
name: "Tìm kiếm",
url: "tim-kiem",
defaults: new { controller = "SanPham", action = "Search", id = UrlParameter.Optional }

);
            routes.MapRoute(
name: "Detail Shipper",
    url: "Shipper/Detail-{id}",
defaults: new { controller = "Shipper", action = "DetailShipper", id = UrlParameter.Optional }

);
//            routes.MapRoute(
//name: "Order Detail Shipper",
//url: "Shipper/don-hang-{id}",
//defaults: new { controller = "Shipper", action = "GiaoHangShipper", id = UrlParameter.Optional }

//);
            routes.MapRoute(
name: "Paypal",
url: "Paypal",
defaults: new { controller = "Cart", action = "Paypal", id = UrlParameter.Optional }

);
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }

           );

        }
    }
}
