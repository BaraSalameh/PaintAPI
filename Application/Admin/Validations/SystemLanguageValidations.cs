using Domain.Entities;

namespace Application.Admin.Validations
{
    public static class SystemLanguageValidations
    {
        public static List<string> ValidateSystemLanguage(this System_Language Sl, List<string> ErrorList)
        {
            if (string.IsNullOrEmpty(Sl.Key))
            {
                ErrorList.Add("Key can't be null or empty");
            }

            if (string.IsNullOrEmpty(Sl.English))
            {
                ErrorList.Add("English can't be null or empty");
            }

            return ErrorList;
        }
    }
}
