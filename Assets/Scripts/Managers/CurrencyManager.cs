using BaseTemplate.Behaviours;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoSingleton<CurrencyManager>
{
    Dictionary<Currency, int> _currencies = new Dictionary<Currency, int>();

    public UnityAction OnCurrencyChange;

    public void Init()
    {
        UseCurrency(Currency.Exp, -365);// faire que chaque = a jour depuis le debut du dev
        UseCurrency(Currency.Life, -22);// faire que = a mon age
    }

    public int GetCurrency(Currency currency)
    {
        if (!_currencies.ContainsKey(currency)) _currencies[currency] = 0;

        return _currencies[currency];
    }

    public bool UseCurrency(Currency currency, int amount)
    {
        if (!_currencies.ContainsKey(currency)) _currencies[currency] = 0;

        if (_currencies[currency] - amount < 0) return false;

        _currencies[currency] -= amount;

        OnCurrencyChange?.Invoke();

        return true;
    }
}
