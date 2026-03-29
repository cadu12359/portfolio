using Blazored.LocalStorage;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace Portfolio.Web.Services;

public class LanguageService(ILocalStorageService localStorage)
{
    private const string LangKey = "portfolio_lang";
    public string Current { get; private set; } = "pt"; // Default -> pt

    public event Action? OnLanguageChanged;

    public async Task InitializeAsync()
    {
        var savedLang = await localStorage.GetItemAsync<string>(LangKey);
        if (!string.IsNullOrEmpty(savedLang) && (savedLang == "pt" || savedLang == "en"))
        {
            Current = savedLang;
        }
        else
        {
            var browserLang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            Current = browserLang == "en" ? "en" : "pt";
        }

        SetCulture(Current);
    }

    public async Task ToggleLanguageAsync()
    {
        Current = Current == "pt" ? "en" : "pt";
        await localStorage.SetItemAsync(LangKey, Current);
        SetCulture(Current);
        OnLanguageChanged?.Invoke();
    }

    private void SetCulture(string lang)
    {
        var culture = new CultureInfo(lang == "pt" ? "pt-BR" : "en-US");
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}
