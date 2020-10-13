using System;
using System.Linq;
using System.Threading.Tasks;
using Academy.UtilityAndModels;
using Academy.UtilityAndModels.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Academy.ClientDataLayer
{
    public class AccountDAL
    {
        public void ValidateUser(UserDto userDto)
        {
            try
            {
                var userInfo = DataStub.userData.FirstOrDefault(x => x.Email == userDto.User.Email && x.Password == userDto.User.Password);
                if (userInfo != null)
                {
                    Preferences.Set(Constants.UserIDPreference, userInfo.UserId);
                    Preferences.Set(Constants.UserRoleIDPreference, userInfo.UserRole);
                    userDto.ErrCode = Enums.ErrorCode.OK;
                }
                else
                {
                    userDto.ErrCode = Enums.ErrorCode.InValidData;
                }
            }
            catch (Exception e)
            {
                userDto.ErrCode = Enums.ErrorCode.Error;
            }
        }

        public async Task GetUsers(UserDto userDto)
        {
            if (Preferences.Get(Constants.UserRoleIDPreference, 0) == (int)Enums.UserRole.Admin)
            {
                foreach (var item in DataStub.userData)
                {
                    if (item.UserRole == (int)Enums.UserRole.Student)
                    {
                        item.AuditedString = item.Audited ? nameof(item.Audited) : "Un-Audited";
                        item.AuditedColor = item.Audited ? Color.Green.ToHex() : Color.Red.ToHex();
                        userDto.Users.Add(item);
                    }
                }
            }
            else
            {
                userDto.Users.Add(DataStub.userData.Find(x=>x.UserId == Preferences.Get(Constants.UserIDPreference, 0)));
            }
        }

        public async Task SaveUser(UserDto userDto)
        {
            try
            {
                userDto.ErrCode = Enums.ErrorCode.OK;
                if (userDto.User.UserId > 0)
                {
                    DataStub.userData[DataStub.userData.IndexOf(x => x.UserId == userDto.User.UserId)] = userDto.User;
                }
                else
                {
                    if (DataStub.userData.Find(x=>x.Email==userDto.User.Email)!=null)
                    {
                        userDto.ErrCode = Enums.ErrorCode.InValidData;
                        userDto.ErrorMessage = "User already Exist!!";
                    }
                    else
                    {
                        userDto.User.UserId = DataStub.userData.Last().UserId + 1;
                        userDto.User.Class = 10;
                        userDto.User.UserRole = (int)Enums.UserRole.Student;
                        DataStub.userData.Add(userDto.User);
                    }
                }
            }
            catch (Exception e)
            {
                userDto.ErrCode = Enums.ErrorCode.Error;
                userDto.ErrorMessage = "Something Went Wrong!";
            }
        }

        public async Task AuditStudent(UserDto userDto)
        {
            try
            {
                DataStub.userData.Find(x => x.UserId == userDto.User.UserId).Audited = true;
                userDto.ErrCode = Enums.ErrorCode.OK;
            }
            catch (Exception e)
            {
                userDto.ErrCode = Enums.ErrorCode.Error;
            }
        }
    }
}
