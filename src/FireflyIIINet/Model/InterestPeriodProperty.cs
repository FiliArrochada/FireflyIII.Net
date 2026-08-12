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
    /// Mandatory when type is liability. Period over which the interest is calculated.
    /// </summary>
    /// <value>Mandatory when type is liability. Period over which the interest is calculated.</value>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum InterestPeriodProperty
    {
        /// <summary>
        /// Enum Daily for value: daily
        /// </summary>
        [EnumMember(Value = "daily")]
        Daily = 1,

        /// <summary>
        /// Enum Weekly for value: weekly
        /// </summary>
        [EnumMember(Value = "weekly")]
        Weekly = 2,

        /// <summary>
        /// Enum Monthly for value: monthly
        /// </summary>
        [EnumMember(Value = "monthly")]
        Monthly = 3,

        /// <summary>
        /// Enum Quarterly for value: quarterly
        /// </summary>
        [EnumMember(Value = "quarterly")]
        Quarterly = 4,

        /// <summary>
        /// Enum HalfYear for value: half-year
        /// </summary>
        [EnumMember(Value = "half-year")]
        HalfYear = 5,

        /// <summary>
        /// Enum Yearly for value: yearly
        /// </summary>
        [EnumMember(Value = "yearly")]
        Yearly = 6,

        /// <summary>
        /// Enum Null for value: null
        /// </summary>
        [EnumMember(Value = "null")]
        Null = 7
    }

}
