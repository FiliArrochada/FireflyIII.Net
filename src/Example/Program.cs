using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FireflyIIINet.Api;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Refit;

namespace example
{
    class Program
    {
        private static string ff3_demo_url = "https://demo.firefly-iii.org/api";
        private static string ff3_demo_pat = "<FF3 personal access token>";

        static async Task Main(string[] args)
        {
            var http = new HttpClient { BaseAddress = new Uri(ff3_demo_url) };
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", ff3_demo_pat);

            var txn_client = RestService.For<ITransactionsApi>(http, FireflyRefitSettings.Create());

            var txn = new TransactionSplitStore(
                type: TransactionTypeProperty.Withdrawal,
                date: DateTime.Now,
                amount: "12.54",
                description: "Test FireflyIII .Net Transaction",
                currencyCode: "EUR",
                // Can set source/dest by account ID or name
                // sourceId: "1",
                sourceName: "Checking Account",
                destinationId: "7"
            );

            var txn_rsp = await txn_client.StoreTransaction(new TransactionStore(transactions: new List<TransactionSplitStore> { txn }));
            Console.WriteLine($"Created transaction {txn_rsp.Data.Id}");

            // Set a breakpoint here:
            await txn_client.DeleteTransaction(txn_rsp.Data.Id);
            Console.WriteLine($"Deleted transaction");
        }
    }
}
