﻿using Hosts.ServiceDefaults;
using Hosts.Tests.PageModels;
using Hosts.Tests.TestInfra;
using Microsoft.Playwright;
using Xunit.Abstractions;

namespace Hosts.Tests;

public class BffBlazorWebAssemblyTests(ITestOutputHelper output, AppHostFixture fixture)
    : PlaywrightTestBase(output, fixture)
{
    public async Task<WebAssemblyPageModel> GoToHome()
    {
        await Page.GotoAsync(Fixture.GetUrlTo(AppHostServices.BffBlazorWebassembly).ToString());
        return new WebAssemblyPageModel()
        {
            Page = Page
        };
    }

    [SkippableFact]
    public async Task Can_login_and_load_local_api()
    {
        var homePage = await GoToHome();

        await homePage.VerifyNotLoggedIn();

        await homePage.Login();

        await homePage.VerifyLoggedIn();

        var weatherPage = await homePage.GoToWeather();

        await weatherPage.VerifyWeatherListIsShown();

        await homePage.LogOut();

    }



}