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
    /// Mandatory when the account_role is ccAsset. Can only be monthlyFull or null.
    /// </summary>
    /// <value>Mandatory when the account_role is ccAsset. Can only be monthlyFull or null.</value>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum CreditCardTypeProperty
    {
        /// <summary>
        /// Enum MonthlyFull for value: monthlyFull
        /// </summary>
        [EnumMember(Value = "monthlyFull")]
        MonthlyFull = 1,

        /// <summary>
        /// Enum Null for value: null
        /// </summary>
        [EnumMember(Value = "null")]
        Null = 2
    }

}
