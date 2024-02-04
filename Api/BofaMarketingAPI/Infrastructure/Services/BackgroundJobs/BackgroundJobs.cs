using Application.Campaigns.Queries.GetCampains;
using Hangfire;
using Hangfire.States;
using MediatR;

namespace Infrastructure.Services.BackgroundJobs;
public class BackgroundJobs : IBackgroundJobs
{
    private readonly ISender _mediator;

    public BackgroundJobs(ISender mediator)
    {
        _mediator = mediator;

    }

    public async Task TriggerCampaignSSIS()
    {
        var today = DateTime.Today;
        var firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
        var firstMonday = GetFirstMondayOfMonth(firstDayOfMonth);
        var sundayAfterFirstMonday = firstMonday.AddDays(6);

        if (today >= firstMonday && today <= sundayAfterFirstMonday)
        {
            // Trigger the SSIS package
            await _mediator.Send(new ExecuteSSISPackageCommand());
        }

    }
    public static void ScheduleMonthlyCampaign()
    {
        var currentDate = DateTime.Now;
        var firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
        var firstMonday = GetFirstMondayOfMonth(firstDayOfMonth);
        var firstSunday = firstMonday.AddDays(6);

        var cronExpression = $"{firstMonday.Minute} {firstMonday.Hour} * * {firstMonday.DayOfWeek.ToString().Substring(0, 3)}";
        RecurringJob.AddOrUpdate<IBackgroundJobs>("campaign-job", x => x.TriggerCampaignSSIS(), cronExpression);

    }
    public static DateTime GetFirstMondayOfMonth(DateTime date)
    {
        int daysUntilMonday = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
        return date.AddDays(daysUntilMonday);
    }

}