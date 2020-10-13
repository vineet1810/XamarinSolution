using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Academy.UtilityAndModels;
using Academy.UtilityAndModels.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using static Academy.UtilityAndModels.Enums;

namespace Academy.Service.Controllers
{
    public class AccountsController : Controller
    {
        [HttpPost]
        [Route("Login")]
        public async Task<UserDto> LoginAsync([FromBody]UserDto userDto)
        {
            using SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + "username", userDto.User.Email, DbType.String, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.Password), userDto.User.Email, DbType.String, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(userDto.ErrCode), userDto.ErrCode, DbType.Int16, direction: ParameterDirection.Output);
            userDto.Users = (await connection.QueryAsync<UserModel>(SPNameFieldConstants.USP_LOGIN, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
            userDto.ErrCode = (ErrorCode)parameter.Get<short>(Constants.SYMBOL_AT_THE_RATE + nameof(userDto.ErrCode));
            return userDto;
        }

        [Route("GetUser")]
        public async Task<UserDto> GetUser([FromQuery]int UserId, int UserRole)
        {

            UserDto userDto = new UserDto()
            {
                Users = new List<UserModel>()
            };
            using SqlConnection connection = new SqlConnection("data source=YY173167;   initial catalog = priyait; persist security info = True; user id=Test@12345; password=Vineet@12345; Integrated Security = SSPI;");
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.UserId), UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.UserRole), UserRole, DbType.Int32, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(userDto.ErrCode), userDto.ErrCode, DbType.Int16, direction: ParameterDirection.Output);
            userDto.Users = (await connection.QueryAsync<UserModel>(SPNameFieldConstants.USP_GETUSER, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
            userDto.ErrCode = (ErrorCode)parameter.Get<short>(Constants.SYMBOL_AT_THE_RATE + nameof(userDto.ErrCode));
            return userDto;
        }

        [HttpPost]
        [Route("SaveUser")]
        public async Task<UserDto> SaveUser([FromBody]UserDto userDto)
        {
            using SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.Gender), userDto.User.Gender, DbType.Int32, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.FirstName), userDto.User.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.LastName), userDto.User.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.Address), userDto.User.Address, DbType.String, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.Email), userDto.User.Email, DbType.Int64, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.ContactNo), userDto.User.ContactNo, DbType.String, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.Class), userDto.User.Class, DbType.Int32, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.Audited), userDto.User.Audited, DbType.Int32, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.BirthDate), userDto.User.BirthDate, DbType.DateTimeOffset, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(UserModel.UserId), userDto.User.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add(Constants.SYMBOL_AT_THE_RATE + nameof(userDto.ErrCode), userDto.ErrCode, DbType.Int16, direction: ParameterDirection.Output);
            await connection.ExecuteAsync(SPNameFieldConstants.USP_SAVEUSER, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            userDto.ErrCode = (ErrorCode)parameter.Get<short>(Constants.SYMBOL_AT_THE_RATE + nameof(userDto.ErrCode));
            return userDto;
        }
    }
}
