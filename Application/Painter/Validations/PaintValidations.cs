using Application.Common.Functions;
using Domain.Entities;
using Domain.Enums;

namespace Application.Painter.Validations
{
    public static class PaintValidations
    {
        public static List<string> ValidatePaint(this Paint paint, List<string> ErrorList)
        {
            if (!paint.Name.IsValidSystemLanguage())
            {
                ErrorList.Add("Name (Key, English) can't be null or empty");
            }

            if (paint.UserID == null)
            {
                ErrorList.Add("UserID can't be null");
            }
            else if (paint.UserID == (int)RoleName.Painter)
            {
                ErrorList.Add("Admins can't have a paint");
            }

            return ErrorList;
        }
    }
}
