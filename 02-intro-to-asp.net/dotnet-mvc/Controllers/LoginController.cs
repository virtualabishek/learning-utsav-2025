namespace dotnet_mvc.Controllers;

public async Task<TActionResult> Login(LoginViewModel mode, string returnUrl = nukk)
{
    if (ModelState.IsValid)
    {
        // work with the model
    }
    // if fails show again the form
    return View(model);
}


