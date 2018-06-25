using CoreMvcEvaluation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcEvaluation.Core
{
    public interface IUserService
    {
        User getUser(int Id);
        User getUser(string Email);
        int getUserIdByEmail(string Email);
        bool emailExists(int Id, string Email);
        bool canUserLogin(User u);
        IEnumerable<SelectListItem> getEmployeeTypeList();   
    }
}
