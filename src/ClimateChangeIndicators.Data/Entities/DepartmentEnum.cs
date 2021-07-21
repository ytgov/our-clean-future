using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public enum DepartmentEnum
    {
        NotApplicable,

        [Display(Name = "Community Services")]
        CommunityServices,

        [Display(Name = "Economic Development")]
        EconomicDevelopment,

        [Display(Name = "Education")]
        Education,

        [Display(Name = "Energy, Mines and Resources")]
        EnergyMinesAndResources,

        [Display(Name = "Environment")]
        Environment,

        [Display(Name = "Executive Council Office")]
        ExecutiveCouncilOffice,

        [Display(Name = "Finance")]
        Finance,

        [Display(Name = "French Language Services Directorate")]
        FrenchLanguageServicesDirectorate,

        [Display(Name = "Health and Social Services")]
        HealthAndSocialServices,

        [Display(Name = "Highways and Public Works")]
        HighwaysAndPublicWorks,

        [Display(Name = "Justice")]
        Justice,

        [Display(Name = "Public Service Commission")]
        PublicServiceCommission,

        [Display(Name = "Tourism and Culture")]
        TourismAndCulture,

        [Display(Name = "Women's Directorate")]
        WomensDirectorate,

        [Display(Name = "Yukon Energy Corporation")]
        YukonEnergyCorporation,

        [Display(Name = "Yukon Development Corporation")]
        YukonDevelopmentCorporation,

        [Display(Name = "Yukon Housing Corporation")]
        YukonHousingCorporation,

        [Display(Name = "Yukon Liquor Corporation")]
        YukonLiquorCorporation,

        [Display(Name = "Yukon Lottery Commission and Lotteries Yukon")]
        YukonLotteryCommissionAndLotteriesYukon,

        [Display(Name = "Yukon Workers' Compensation Health and Safety Board")]
        YukonWorkersCompensationHealthAndSafetyBoard
    }
}