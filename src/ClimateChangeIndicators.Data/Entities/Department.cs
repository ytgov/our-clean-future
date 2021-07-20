using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public enum Department
    {
        [Display(Name = "Community Services")]
        CommunityServices,
        EconomicDevelopment,
        Education,
        EnergyMinesAndResources,
        Environment,
        ExecutiveCouncilOffice,
        Finance,
        FrenchLanguageServicesDirectorate,
        HealthAndSocialServices,
        HighwaysAndPublicWorks,
        Justice,
        PublicServiceCommission,
        TourismandCulture,
        WomensDirectorate,
        YukonEnergyCorporation,
        YukonDevelopmentCorporation,
        YukonHousingCorporation,
        YukonLiquorCorporation,
        YukonLotteryCommissionAndLotteriesYukon,
        YukonWorkersCompensationHealthAndSafetyBoard
    }
}