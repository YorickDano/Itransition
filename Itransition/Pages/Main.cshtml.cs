using ItransitionTask3.Classes;
using ItransitionTask3.Pages.Helders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Web;

namespace ItransitionTask3.Pages
{
    public class MainModel : PageModel
    {
        [BindProperty]
        public List<int> CheckBoxs { get; set; }

        [BindProperty]
        public bool Lock { get; set; }
        public void OnGet(int Id)
        {
            
            Helder.CreateHelder(Id);
        }
        public void OnPost()
        {

        }

        public void OnPostLockUsers()
        {
            var users = Helder.Users.FindAll(x => CheckBoxs.Contains(x.Id));
            Helder.Users.ForEach(x => x.Status = CheckBoxs.Contains(x.Id) ? "Lock" : x.Status);
            DataBase.ChangeUsersStatus(users, "Lock");
            if (users.Find(x => x.Id == Helder.ThisUserId) != null)
            {
                Response.Redirect("/Index");
            }
        }   

        public void OnPostUnLockUsers()
        {
            var users = Helder.Users.FindAll(x => CheckBoxs.Contains(x.Id));
            Helder.Users.ForEach(x => x.Status = CheckBoxs.Contains(x.Id) ? "UnLock" : x.Status);
            DataBase.ChangeUsersStatus(users, "UnLock");
        }
       
        public void OnPostBanUsers()
        {
            var users = Helder.Users.FindAll(x => CheckBoxs.Contains(x.Id));
            Helder.Users.RemoveAll(x => CheckBoxs.Contains(x.Id));
            DataBase.DeleteUser(users);
            if(users.Find(x=>x.Id == Helder.ThisUserId) != null)
            {
                Response.Redirect($"/Index");
            }
        }
        public void OnPostSellectAll()
        { 
            if (Helder.Users.TrueForAll(x => x.CheckBox == true))
            {
                Helder.Users.ForEach(x => x.CheckBox = false);
            }
            else
            {
                Helder.Users.ForEach(x => x.CheckBox = true);
            }
        }
    }
}
