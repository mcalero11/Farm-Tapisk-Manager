using System;
using System.Collections.Generic;
using System.Text;
using TapiskAPP.Views.MenuItemPages;

namespace TapiskAPP.Models
{
    public class MenuItem
    {
        public string PageName { get; set; }
        public string Icon { get; set; }
        public int PermissionLevel { get; set; }
        public string Title { get; set; }
    }
    public class MockMenuItems
    {
        public static List<MenuItem> GetMenuItems()
        {
            List<MenuItem> MenuItems;

            MenuItems = new List<MenuItem>() {
                new MenuItem() {
                    PageName        = nameof(UserPage),
                    Icon            = "\uf0c0",
                    PermissionLevel = 2,
                    Title           = "Empleados",
                },
                new MenuItem() {
                    PageName        = nameof(CropPage),
                    Icon            = "\uf06c",
                    PermissionLevel = 1,
                    Title           = "Cultivos",
                },
                new MenuItem() {
                    PageName        = nameof(HarvestPage),
                    Icon            = "\uf474",
                    PermissionLevel = 3,
                    Title           = "Cosechas",
                },
                //*********************************
                /*
                new MenuItem() {
                    PageName        = nameof(UserPage),
                    Icon            = "\uf0c0",
                    PermissionLevel = 2,
                    Title           = "Empleados",
                },
                new MenuItem() {
                    PageName        = nameof(CropPage),
                    Icon            = "\uf06c",
                    PermissionLevel = 1,
                    Title           = "Cultivos",
                },
                new MenuItem() {
                    PageName        = nameof(HarvestPage),
                    Icon            = "\uf474",
                    PermissionLevel = 3,
                    Title           = "Cosechas",
                },
                new MenuItem() {
                    PageName        = nameof(UserPage),
                    Icon            = "\uf0c0",
                    PermissionLevel = 2,
                    Title           = "Empleados",
                },
                new MenuItem() {
                    PageName        = nameof(CropPage),
                    Icon            = "\uf06c",
                    PermissionLevel = 1,
                    Title           = "Cultivos",
                },
                new MenuItem() {
                    PageName        = nameof(HarvestPage),
                    Icon            = "\uf474",
                    PermissionLevel = 3,
                    Title           = "Cosechas",
                },
                new MenuItem() {
                    PageName        = nameof(UserPage),
                    Icon            = "\uf0c0",
                    PermissionLevel = 2,
                    Title           = "Empleados",
                },
                new MenuItem() {
                    PageName        = nameof(CropPage),
                    Icon            = "\uf06c",
                    PermissionLevel = 1,
                    Title           = "Cultivos",
                },
                new MenuItem() {
                    PageName        = nameof(HarvestPage),
                    Icon            = "\uf474",
                    PermissionLevel = 3,
                    Title           = "Cosechas",
                },
                */
                //*********************************

            };

            return MenuItems;
        }
    }
}
