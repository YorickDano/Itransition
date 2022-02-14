using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;
using ItransitionTask3.Classes;

namespace ItransitionTask3.Pages
{
    public class Index : PageModel
    {
        public string UserWithThisEmailExist = "";
        public string IncorrectData = "";
        public string MainUrl = "";
        DataBase Database = new DataBase();
      
        
        private bool RememberMe;
        public void OnGet()
        {

        }

        public void OnPostLogin(string email, string password)
        {
            var user = DataBase.GetUserFromDataBaseByEmail(email);

            if (Database.IsThisUserExistAndDoesntBan(email, password))
            {
                DataBase.UpdateLastEnterDate(email);
                Response.Redirect($"Main/{user.Id}");
            }
            else
            {
                IncorrectData = "Incorrect email or pasword or your account locked";
            }
        }

        public void OnPostSignup(string emailSign, string nameSign, string passwordSign)
        {
         
            if (!Database.IsThisEmailExist(emailSign))
            {
                Database.AddInfoInTable(emailSign, nameSign, passwordSign);
                var user = DataBase.GetUserFromDataBaseByEmail(emailSign);
                Response.Redirect($"Main/{user.Id}");
            }
            else
            {
                UserWithThisEmailExist = "User with this email already exist";
            }
        }
        public bool GetRememberMe()
        {
            return RememberMe;
        }
    }
}
