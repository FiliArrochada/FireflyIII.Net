/*
 * Firefly III API
 *
 * This is the documentation of the Firefly III API. You can find accompanying documentation on the website of Firefly III itself (see below). Please report any bugs or issues.
 *
 * The pinned API version is recorded in FireflyIIINet.csproj and README.md.
 * Contact: james@firefly-iii.org
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FireflyIIINet.Client.OpenAPIDateConverter;

namespace FireflyIIINet.Model
{
    /// <summary>
    /// Defines ConfigValueUpdateFilter
    /// </summary>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum ConfigValueUpdateFilter
    {
        /// <summary>
        /// Enum IsDemoSite for value: configuration.is_demo_site
        /// </summary>
        [EnumMember(Value = "configuration.is_demo_site")]
        IsDemoSite = 1,

        /// <summary>
        /// Enum PermissionUpdateCheck for value: configuration.permission_update_check
        /// </summary>
        [EnumMember(Value = "configuration.permission_update_check")]
        PermissionUpdateCheck = 2,

        /// <summary>
        /// Enum LastUpdateCheck for value: configuration.last_update_check
        /// </summary>
        [EnumMember(Value = "configuration.last_update_check")]
        LastUpdateCheck = 3,

        /// <summary>
        /// Enum SingleUserMode for value: configuration.single_user_mode
        /// </summary>
        [EnumMember(Value = "configuration.single_user_mode")]
        SingleUserMode = 4,

        /// <summary>
        /// Enum EnableExchangeRates for value: configuration.enable_exchange_rates
        /// </summary>
        [EnumMember(Value = "configuration.enable_exchange_rates")]
        EnableExchangeRates = 5,

        /// <summary>
        /// Enum UseRunningBalance for value: configuration.use_running_balance
        /// </summary>
        [EnumMember(Value = "configuration.use_running_balance")]
        UseRunningBalance = 6,

        /// <summary>
        /// Enum EnableExternalMap for value: configuration.enable_external_map
        /// </summary>
        [EnumMember(Value = "configuration.enable_external_map")]
        EnableExternalMap = 7,

        /// <summary>
        /// Enum EnableExternalRates for value: configuration.enable_external_rates
        /// </summary>
        [EnumMember(Value = "configuration.enable_external_rates")]
        EnableExternalRates = 8,

        /// <summary>
        /// Enum AllowWebhooks for value: configuration.allow_webhooks
        /// </summary>
        [EnumMember(Value = "configuration.allow_webhooks")]
        AllowWebhooks = 9,

        /// <summary>
        /// Enum ValidUrlProtocols for value: configuration.valid_url_protocols
        /// </summary>
        [EnumMember(Value = "configuration.valid_url_protocols")]
        ValidUrlProtocols = 10
    }

}
