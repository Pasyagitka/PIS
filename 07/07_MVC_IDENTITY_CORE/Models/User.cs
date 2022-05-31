using Microsoft.AspNetCore.Identity;

namespace _07_MVC_IDENTITY.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
        
        //Email: email пользователя

        //Id: уникальный идентификатор пользователя

        //Logins: возвращает коллекцию логинов пользователя

        //PasswordHash: возвращает хэш пароля

        //Roles: возвращает коллекцию ролей пользователя
    }
}
