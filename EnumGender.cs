using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contact_List
{
    public enum Genders
    {
        Male = 1,
        Female = 2,
        Other = 3
    };

    public class EnumGender
    {
        public Genders GetGender(string gender)
        {
            Genders genders = (Genders)Enum.Parse(typeof(Genders), gender); 
            return genders;
        }
    }
}