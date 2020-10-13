using Academy.UtilityAndModels;
using Academy.UtilityAndModels.Models;
using System;
using System.Collections.Generic;

namespace Academy.ClientDataLayer
{
    public class DataStub
    {
        public static List<UserModel> userData = new List<UserModel>
            {
                new UserModel
                {
                    IsSync=false,UserId=1,UserRole=(int)Enums.UserRole.Admin, Address="Mumbai", Audited=false, BirthDate=DateTime.Now.AddYears(-20), Class=10, ContactNo=123456789, Email="test@test.com", FirstName="Vineet", LastName="agarwal", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=2,UserRole=(int)Enums.UserRole.Student, Address="Delhi", Audited=false, BirthDate=DateTime.Now.AddYears(-21), Class=11, ContactNo=223456789, Email="test1@test.com", FirstName="rohan", LastName="mangale", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=3,UserRole=(int)Enums.UserRole.Student, Address="Jaipur", Audited=false, BirthDate=DateTime.Now.AddYears(-22), Class=9, ContactNo=323456789, Email="test2@test.com", FirstName="vishal", LastName="parmar", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=4,UserRole=(int)Enums.UserRole.Student, Address="Pune", Audited=false, BirthDate=DateTime.Now.AddYears(-22), Class=8, ContactNo=423456789, Email="test3@test.com", FirstName="neha", LastName="agarwal", Gender =(int) Enums.Gender.Female, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=5,UserRole=(int)Enums.UserRole.Student, Address="Bangalore", Audited=false, BirthDate=DateTime.Now.AddYears(-23), Class=7, ContactNo=523456789, Email="test4@test.com", FirstName="aniket", LastName="prakash", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=6,UserRole=(int)Enums.UserRole.Student, Address="Hyderabad", Audited=false, BirthDate=DateTime.Now.AddYears(-24), Class=6, ContactNo=623456789, Email="test5@test.com", FirstName="rajesh", LastName="armorikar", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=7,UserRole=(int)Enums.UserRole.Student, Address="Chennai", Audited=false, BirthDate=DateTime.Now.AddYears(-25), Class=5, ContactNo=723456789, Email="test6@test.com", FirstName="narendra", LastName="chauhan", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=8,UserRole=(int)Enums.UserRole.Student, Address="Chandigarh", Audited=false, BirthDate=DateTime.Now.AddYears(-26), Class=12, ContactNo=823456789, Email="test7@test.com", FirstName="kamlesh", LastName="asnani", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=9,UserRole=(int)Enums.UserRole.Student, Address="kolkata", Audited=false, BirthDate=DateTime.Now.AddYears(-19), Class=13, ContactNo=923456789, Email="test8@test.com", FirstName="tarun", LastName="ahuja", Gender =(int) Enums.Gender.Male, Password="Test@123",
                },
                new UserModel
                {
                    IsSync=false, UserId=10,UserRole=(int)Enums.UserRole.Student, Address="kochi", Audited=false, BirthDate=DateTime.Now.AddYears(-18), Class=14, ContactNo=023456789, Email="test9@test.com", FirstName="lavy", LastName="asnani", Gender =(int) Enums.Gender.Female, Password="Test@123",
                },
            };
    }
}
