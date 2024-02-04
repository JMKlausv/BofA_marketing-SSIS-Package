namespace Infrastructure.Services.BackgroundJobs;
public interface IBackgroundJobs {
    public Task TriggerCampaignSSIS();
}