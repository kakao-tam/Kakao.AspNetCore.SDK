using System;
using Kakao.AspNetCore.SDK.Talk;
using Kakao.AspNetCore.SDK.Talk.Model;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [Route("[controller]/[action]")]
    public class TalkController : Controller
    {
        [Route("~/Talk/profile.json")]
        public string profileJson()
        {
            return new TalkApiClient().profile();
        }

        [Route("~/Talk/profile.model")]
        public string profileModel()
        {
            TalkProfile? rtn = new TalkProfile();
            new TalkApiClient().profile((profile, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("카카오톡 프로필 가져오기 실패 {0}", error.ToString());
                }
                else if (profile != null)
                {
                    rtn = profile;
                    Console.WriteLine("카카오톡 프로필 가져오기 성공");
                    Console.WriteLine("닉네임: {0}", profile.Nickname);
                    Console.WriteLine("프로필사진: {0}", profile.ProfileImageUrl);
                    Console.WriteLine("국가코드: {0}", profile.CountryISO);
                }
            });

            return rtn.ToString();
        }
    }
}

