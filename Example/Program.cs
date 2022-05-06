using Kakao.AspNetCore.SDK.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/// <summary>
/// Kakao.AspNetCore.SDK
/// </summary>
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ※ KakaoSdk 라이브러리는 Kakao.AspNetCore.Authentication.OAuth2 라이브러리와 무관한 라이브러리입니다.
// ※ Kakao관련 인가요청 주소, 리다이렉트 URI 처리 관련 API, 토큰요청 주소, API 호출 주소 등. 라이브러리 내부 설정되어 있으므로 UseKakaoSDKInit으로 앱키만 설정하면 됩니다.   
// ※ Redirect URI는 기본값 "/UserApi/KakaoLoginRedirectUri"이고, UseKakaoSDKInit의 파라메터로 재정의해서 커스터마이징 가능합니다.
// ※ 액세스 토큰은 HttpContext Session을 필수로 사용하며 Session에 kakao_access_token Key로 저장됩니다.
// ※ Session, kakao_access_token에 유효한 토큰을 설정하면 별도 인가요청 절차 없이 API를 사용할 수 있습니다. 
builder.Services.UseKakaoSDKInit("APP_KEY");






var app = builder.Build();

/// <summary>
/// Kakao.AspNetCore.SDK
/// </summary>
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseSession();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

