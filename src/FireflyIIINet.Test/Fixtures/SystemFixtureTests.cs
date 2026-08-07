/*
 * Fixture tests for the System/About area, fed by the example payloads from the
 * Firefly III OpenAPI spec (api/firefly-iii-2.0.2-v1.yaml):
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

        [Fact]
        public void CronResult_Deserializes_Spec_Example_With_Nullable_Rows()
        {
            const string json = """
            {
              "recurring_transactions": {
                "job_fired": true,
                "job_succeeded": true,
                "job_errored": false,
                "message": "The cron job fired successfully."
              },
              "auto_budgets": {
                "job_fired": false,
                "job_succeeded": null,
                "job_errored": null,
                "message": null
              },
              "telemetry": {
                "job_fired": true,
                "job_succeeded": true,
                "job_errored": false,
                "message": "The cron job fired successfully."
              }
            }
            """;

            var result = JsonSerializer.Deserialize<CronResult>(json, SerializerOptions.Default);

            Assert.True(result.RecurringTransactions.JobFired);
            Assert.True(result.RecurringTransactions.JobSucceeded);
            Assert.False(result.RecurringTransactions.JobErrored);
            Assert.Equal("The cron job fired successfully.", result.RecurringTransactions.Message);

            Assert.False(result.AutoBudgets.JobFired);
            Assert.Null(result.AutoBudgets.JobSucceeded); // nullable per spec, explicit null
            Assert.Null(result.AutoBudgets.JobErrored);
            Assert.Null(result.AutoBudgets.Message);

            Assert.True(result.Telemetry.JobFired);
        }
    }
}
