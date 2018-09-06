using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotion_API_tests
{
    public static class Configurations
    {
        public static class PromotionService
        {
            public static string URL = "http://10.20.112.61/Bingo.Services/Promotion/PromotionService.svc";
            public static string GetPromotionPlanRequest = "http://Bingo.Promotion.Service/IPromotionService/GetPromotionPlanRequest";
        }

    }
}
