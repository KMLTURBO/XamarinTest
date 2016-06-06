using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Diagnostics;

namespace Acquaint.Data
{
    public class AzureAcquaintanceDataSource : IDataSource<Acquaintance>
    {
        public MobileServiceClient MobileService { get; set; }
        IMobileServiceSyncTable<Acquaintance> acquaintanceTable;
        readonly string serviceUrl = "";

        public AzureAcquaintanceDataSource(string endpointUrl = "")
        {
            if (!string.IsNullOrEmpty(endpointUrl))
                serviceUrl = endpointUrl;
        }

        bool isInitialized;
        public async Task Initialize()
        {
            if (isInitialized)
                return;

            MobileService = new MobileServiceClient(serviceUrl, null)
            {
                SerializerSettings = new MobileServiceJsonSerializerSettings()
                {
                    CamelCasePropertyNames = true
                }
            };

            var store = new MobileServiceSQLiteStore("acquaintance.db");
            store.DefineTable<Acquaintance>();

            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            acquaintanceTable = MobileService.GetSyncTable<Acquaintance>();

            isInitialized = true;
        }

        public async Task DeleteItem(string id)
        {
            await Initialize();
  
            var item = await GetItem(id);
            await acquaintanceTable.DeleteAsync(item);
            await Sync();
        }

        public async Task<Acquaintance> GetItem(string id)
        {
            await Sync();

            var items = await acquaintanceTable.Where(s => s.Id == id).ToListAsync();

            if (items == null || items.Count == 0)
                return null;

            return items[0];
        }

        public async Task<ICollection<Acquaintance>> GetItems(int start = 0, int count = 100, string query = "")
        {
            await Initialize();
            await Sync();
            return await acquaintanceTable.ToCollectionAsync();
        }

        public async Task SaveItem(Acquaintance item)
        {
            await Initialize();
            await acquaintanceTable.InsertAsync(item);
            //Synchronize todos
            await Sync();
        }

        public async Task Sync()
        {
            var connected = await Plugin.Connectivity.CrossConnectivity.Current.IsReachable(serviceUrl);
            if (connected == false)
                return;

            try
            {
                await MobileService.SyncContext.PushAsync();
                await acquaintanceTable.PullAsync("allAcquaintance", acquaintanceTable.CreateQuery());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync items, that is alright as we have offline capabilities: " + ex);
            }
        }
    }
}

