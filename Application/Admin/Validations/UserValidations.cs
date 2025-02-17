using Application.Common.Functions;
using Domain.Entities;

namespace Application.Admin.Validations
{
    public static class UserValidations
    {
        public static List<string> ValidateUser(this User user, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(user.Username))
            {
                ErrorList.Add("Username can't be null or empty");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                ErrorList.Add("Password can't be null or empty");
            }

            if (string.IsNullOrEmpty(user.Firstname))
            {
                ErrorList.Add("Firstname can't be null or empty");
            }

            if (string.IsNullOrEmpty(user.Lastname))
            {
                ErrorList.Add("Lastname can't be null or empty");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                ErrorList.Add("Email can't be null or empty");
            }
            else if (!user.Email.IsValidEmail())
            {
                ErrorList.Add("Invalid email");
            }
            
            if (!string.IsNullOrEmpty(user.BackupEmail) && !user.BackupEmail.IsValidEmail())
            {
                ErrorList.Add("Invalid backup email");
            }

            if (string.IsNullOrEmpty(user.Phone))
            {
                ErrorList.Add("Phone  can't be null or empty");
            }
            else if (!user.Phone.IsValidPhone())
            {
                ErrorList.Add("Invalid Phone");
            }

            if (!string.IsNullOrEmpty(user.BackupPhone) && !user.BackupPhone.IsValidPhone())
            {
                ErrorList.Add("Invalid backup phone");
            }

            if (user.RoleID == null)
            {
                ErrorList.Add("RoleID  can't be null");
            }

            return ErrorList;
        }
    }
}
