using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class ProfilePopup : Popup
{
    [SerializeField] TMP_Text _ageTxt;

    [SerializeField] LocalizedString _yearTrad, _monthTrad, _dayTrad;

    public override void Init()
    {
        base.Init();

        _ageTxt.text = YearsMonthsDaysFromDate(new DateTime(2002, 05, 07));
    }

    public string YearsMonthsDaysFromDate(DateTime startDate)
    {
        DateTime today = DateTime.Today;

        int years = today.Year - startDate.Year;

        int months = today.Month - startDate.Month;

        if (months < 0)
        {
            months += 12;
            years--;
        }

        int days = today.Day - startDate.Day;

        if (days < 0)
        {
            months--;
            DateTime previousMonth = today.AddMonths(-1);
            days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
        }

        if (months < 0)
        {
            months += 12;
            years--;
        }

        string result = "";

        if (years > 0)
            result += years + " " + _yearTrad.GetLocalizedString(years) + " ";

        if (months > 0)
            result += months + " " + _monthTrad.GetLocalizedString(months) + " ";

        if (days > 0)
            result += days + " " + _dayTrad.GetLocalizedString(days);

        return result.Trim();
    }

    public void HandleOnAlexisGelin()
    {
        Application.OpenURL("https://www.google.com/search?sca_esv=d2a9abe7b60a3dd2&sxsrf=AHTn8zryeSuyQNva5do30fqSdSk72CLx7g:1742077948499&q=Alexis+gelin&udm=2&fbs=ABzOT_BnMAgCWdhr5zilP5f1cnRvJ3SHQcDVxkdpDyHwlRhdNfno-ClRh0PKqyvFYyTkfIfJOoyi6rL2ScSJ67dNoiLlma6nffqoENgGX1Qo-QK1HEFg3ItZnm6x0TVwu0vcGVLvKsTHoTPzsjl_vfkMTseLPtEAPAxx8yNBq8YShV_TbB2QQ98UL-rud6c8jEJL-mQnahUL&sa=X&ved=2ahUKEwiGi6qKko2MAxWNLPsDHVqqMNUQtKgLegQIExAB&biw=1436&bih=1144&dpr=1#vhid=QXBJ5uHXwuMqoM&vssid=mosaic");
    }

    public void HandleOnAgeClick()
    {
        Application.OpenURL("https://codepen.io/ggglll/full/oJbMja");
    }

    public void HandleOnTelephone()
    {
        Application.OpenURL("tel:+33781425765");
    }

    public void HandleOnMail()
    {
        Application.OpenURL("mailto:gelin752002@gmail.com");
    }

    public void HandleOnLinkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/gelin-alexis/");
    }

    public void HandleOnItchio()
    {
        Application.OpenURL("https://alexisgelin.itch.io/");
    }
}
