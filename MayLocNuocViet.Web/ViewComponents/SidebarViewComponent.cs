using Microsoft.AspNetCore.Mvc;
using MLT.MayLocNuocViet.Web.Common;
using MLT.MayLocNuocViet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MLT.MayLocNuocViet.Web.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {

        public SidebarViewComponent()
        {
        }

        public IViewComponentResult Invoke(string filter)
        {
            var sidebars = new List<SidebarMenu>();
            sidebars.Add(new SidebarMenu() { Id = "HRM", Name = "Nhân sự", ParentId = null, IconClassName = "fa-user", IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Employee", Name = "Nhân viên", ParentId = "HRM", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "TimekeepingInDay", Name = "Chấm công", ParentId = "HRM", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Timekeeping", Name = "Bảng chấm công", ParentId = "HRM", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Role1", Name = "Bảng lương", ParentId = "HRM", URLPath = "", SortOder = 1, IsActive = true });

            sidebars.Add(new SidebarMenu() { Id = "Products", Name = "Hàng hoá", ParentId = null, IconClassName = "fa-shopping-cart", IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Product", Name = "Sản phẩm", ParentId = "Products", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Inventory", Name = "Kiểm kho", ParentId = "Products", URLPath = "", SortOder = 1, IsActive = true });

            sidebars.Add(new SidebarMenu() { Id = "Partners", Name = "Đối tác", ParentId = null, IconClassName = "fa-shopping-cart", IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Customer", Name = "Khách hàng", ParentId = "Partners", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Supplier", Name = "Đối tác", ParentId = "Partners", URLPath = "", SortOder = 1, IsActive = true });

            sidebars.Add(new SidebarMenu() { Id = "Report", Name = "Báo cáo", ParentId = null, IconClassName = "fa-bar-chart-o", IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Report1", Name = "Tài chính", ParentId = "Report", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Report2", Name = "Bán hàng", ParentId = "Report", URLPath = "", SortOder = 1, IsActive = true });

            sidebars.Add(new SidebarMenu() { Id = "Category", Name = "Danh mục", ParentId = null, IconClassName = "fa-book", IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Position", Name = "Chức vụ", ParentId = "Category", URLPath = "", SortOder = 1, IsActive = true });

            sidebars.Add(new SidebarMenu() { Id = "System", Name = "Hệ thống", ParentId = null, IconClassName = "fa-cube", IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "User", Name = "Người dùng", ParentId = "System", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Role", Name = "Vai trò", ParentId = "System", URLPath = "", SortOder = 1, IsActive = true });
            sidebars.Add(new SidebarMenu() { Id = "Configuration", Name = "Cấu hình", ParentId = "System", URLPath = "", SortOder = 1, IsActive = true });




            return View(sidebars);
        }
    }
}
