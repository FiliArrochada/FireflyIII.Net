/*
 * Fixture tests for the System/About area, fed by the example payloads from the
 * Firefly III OpenAPI spec (the pinned v1 spec in api/):
 *   - SystemInfo   (GET /v1/about)
 *   - UserSingle   (GET /v1/about/user)
 *   - CronResult   (GET /v1/cron/{cliToken})
 *
 * Note: created_at/updated_at on User map onto private-setter properties and are
 * present in the payload only to prove they deserialize without error.
 */

using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class SystemFixtureTests
    {
        [Fact]
        public void SystemInfo_Deserializes_About_Spec_Example()
        {
            const string json = """
            {
              "data": {
                "version": "5.8.0-alpha.1",
                "api_version": "2.0.0-alpha.1",
                "php_version": "8.1.5",
                "os": "Linux",
                "driver": "mysql"
              }
            }
            """;

            var info = JsonSerializer.Deserialize<SystemInfo>(json, SerializerOptions.Default);

            // wire name "version" maps onto the VarVersion property
            Assert.Equal("5.8.0-alpha.1", info.Data.VarVersion);
            Assert.Equal("2.0.0-alpha.1", info.Data.ApiVersion);
            Assert.Equal("8.1.5", info.Data.PhpVersion);
            Assert.Equal("Linux", info.Data.Os);
            Assert.Equal("mysql", info.Data.Driver);
        }

        [Fact]
        public void UserSingle_Deserializes_Spec_Example()
        {
            const string json = """
            {
              "data": {
                "type": "users",
                "id": "1",
                "attributes": {
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "email": "james@firefly-iii.org",
                  "blocked": false,
                  "blocked_code": null,
                  "role": "owner"
                },
                "links": {
                  "self": "https://demo.firefly-iii.org/api/v1/users/1"
                }
              }
            }
            """;

            var single = JsonSerializer.Deserialize<UserSingle>(json, SerializerOptions.Default);

            Assert.Equal("users", single.Data.Type);
            Assert.Equal("1", single.Data.Id);

            var user = single.Data.Attributes;
            Assert.Equal("james@firefly-iii.org", user.Email);
            Assert.False(user.Blocked);
            Assert.Null(user.BlockedCode); // nullable enum, explicit null on the wire
            Assert.Equal(UserRoleProperty.Owner, user.Role);
        }

        [Fact]
        public void User_BlockedCode_Maps_EnumMember_Wire_Value()
        {
            const string json = """
            {
              "email": "james@firefly-iii.org",
              "blocked": true,
              "blocked_code": "email_changed",
              "role": "demo"
            }
            """;

            var user = JsonSerializer.Deserialize<User>(json, SerializerOptions.Default);

            Assert.True(user.Blocked);
            Assert.Equal(UserBlockedCodeProperty.EmailChanged, user.BlockedCode);
            Assert.Equal(UserRoleProperty.Demo, user.Role);
        }

        /// <summary>
        /// 6.7.0 shape: the cron endpoint may run for every user (static cron token), so each job
        /// is a list with one row per user, each row naming its user. The exchange_rates list is
        /// empty when external rate downloads are disabled.
        /// </summary>
        [Fact]
        public void CronResult_Deserializes_Per_User_Rows_With_Nullable_Fields()
        {
            const string json = """
            {
              "recurring_transactions": [
                {
                  "job_fired": true,
                  "job_succeeded": true,
                  "job_errored": false,
                  "message": "The cron job fired successfully.",
                  "user": "1"
                },
                {
                  "job_fired": false,
                  "job_succeeded": null,
                  "job_errored": null,
                  "message": null,
                  "user": "2"
                }
              ],
              "auto_budgets": [
                { "job_fired": false, "job_succeeded": false, "job_errored": false, "message": "Nothing to do.", "user": "1" },
                { "job_fired": false, "job_succeeded": false, "job_errored": false, "message": "Nothing to do.", "user": "2" }
              ],
              "exchange_rates": [],
              "bill_notifications": [
                { "job_fired": true, "job_succeeded": true, "job_errored": false, "message": "OK", "user": "1" }
              ],
              "webhooks": [
                { "job_fired": true, "job_succeeded": true, "job_errored": false, "message": "OK", "user": "1" }
              ]
            }
            """;

            var result = JsonSerializer.Deserialize<CronResult>(json, SerializerOptions.Default);

            Assert.Equal(2, result.RecurringTransactions.Count);
            var first = result.RecurringTransactions[0];
            Assert.True(first.JobFired);
            Assert.True(first.JobSucceeded);
            Assert.False(first.JobErrored);
            Assert.Equal("The cron job fired successfully.", first.Message);
            Assert.Equal("1", first.User);

            var second = result.RecurringTransactions[1];
            Assert.False(second.JobFired);
            Assert.Null(second.JobSucceeded); // nullable per spec, explicit null
            Assert.Null(second.JobErrored);
            Assert.Null(second.Message);
            Assert.Equal("2", second.User);

            Assert.Equal(2, result.AutoBudgets.Count);
            Assert.Empty(result.ExchangeRates);
            Assert.Equal("1", Assert.Single(result.BillNotifications).User);
            Assert.True(Assert.Single(result.Webhooks).JobSucceeded);
        }
    }
}
