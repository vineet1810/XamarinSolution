using System.Collections.Generic;
using static Academy.UtilityAndModels.Enums;

namespace Academy.UtilityAndModels.Models
{
    public class UserDto
    {
        public List<UserModel> Users { get; set; }
        public UserModel User { get; set; }
        public ErrorCode ErrCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
