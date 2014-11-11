//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Windows.Networking.Connectivity;
//using apiRu = AuthinkDEMO.Model.Data.External.ApiRules;

//namespace AuthinkDEMO.Services
//{
//    public static class InternetConnection
//    {
//        public static bool IsAvailable()
//        {
//            var connections     = NetworkInformation.GetInternetConnectionProfile();
//            return connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
//        }

//        public async static Task<bool> IsServer()
//        {
//           using (var httpClient = new HttpClient())
//           {
//               try
//               {
//                   var request = await httpClient.GetAsync(apiRu::ApiDataSource.BaseUrl);
//                   return request.IsSuccessStatusCode;
//               }
//               catch (Exception e)
//               {
//                   return false;
//               }
//           }
//        }
//    }
//}
