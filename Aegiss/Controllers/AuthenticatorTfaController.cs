using Microsoft.AspNetCore.Mvc;
using Google.Authenticator;

namespace Aegiss.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthenticatorTfaController : ControllerBase
{
    private readonly TwoFactorAuthenticator _tfa;

    public AuthenticatorTfaController(TwoFactorAuthenticator tfa)
    {
        _tfa = tfa;
    }

    [HttpGet("generateqr")]
    public ActionResult<string> GenerateQR(string email)
    {
        string key = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
        SetupCode setupCode = _tfa.GenerateSetupCode("Aegiss - 2FA J6N6S6", email, key, false, 3);

        //Apresentar key pra conferir se está certo, colocar no banco de dados.
        Console.WriteLine(key);

        return setupCode.QrCodeSetupImageUrl;
    }

    [HttpPost("validatecode")]
    public ActionResult<bool> ValidateCode(string key, string code)
    {
        return _tfa.ValidateTwoFactorPIN(key, code);
    }



}

