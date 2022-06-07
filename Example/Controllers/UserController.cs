using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kakao.AspNetCore.SDK.User;
using Kakao.AspNetCore.SDK.User.Model;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        [Route("~/User/me.json")]
        public string profileJson()
        {
            return new UserApiClient().me();
        }

        [Route("~/User/me.model")]
        public string? profileModel()
        {
            User rtn = new User();
            new UserApiClient().me((user, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("사용자 정보 가져오기 실패 {0}", error.ToString());
                }
                else if (user != null)
                {
                    rtn = user;
                    Console.WriteLine("사용자 정보 가져오기 성공");
                    Console.WriteLine("회원번호: {0}", user.Id);
                    Console.WriteLine("이메일: {0}", user.Kakao_Account?.Email);
                    Console.WriteLine("닉네임: {0}", user.Kakao_Account?.Profile?.Nickname);
                    Console.WriteLine("프로필사진: {0}", user.Kakao_Account?.Profile?.Thumbnail_Image_Url);
                }
            });

            return rtn?.ToString();
        }
    }
}

