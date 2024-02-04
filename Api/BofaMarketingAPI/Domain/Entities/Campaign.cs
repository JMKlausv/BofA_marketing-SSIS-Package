using System;

namespace Domain.Entities 
{
    public class Campaign
    {
        public string? AcctNo { get; set; }
        
        public string? first_name { get; set; }
        public string? last_name { get; set; }
        public string? Email { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine12 { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressState { get; set; }
        public string? AddressZipCd { get; set; }
        public string? Channel { get; set; }
        public string? CompanyName { get; set; }
        public decimal Assets { get; set; }
        public int? AccountHolderAge { get; set; }
        public int? AccountAge { get; set; }
        public string? CampaignName { get; set; }
        public DateTime? CampaignDate { get; set; }
    }
}
