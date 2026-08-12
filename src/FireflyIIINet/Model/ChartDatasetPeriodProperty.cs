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
    /// Period of the chart.
    /// </summary>
    /// <value>Period of the chart.</value>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum ChartDatasetPeriodProperty
    {
        /// <summary>
        /// Enum OneDay for value: 1D
        /// </summary>
        [EnumMember(Value = "1D")]
        OneDay = 1,

        /// <summary>
        /// Enum OneWeek for value: 1W
        /// </summary>
        [EnumMember(Value = "1W")]
        OneWeek = 2,

        /// <summary>
        /// Enum OneMonth for value: 1M
        /// </summary>
        [EnumMember(Value = "1M")]
        OneMonth = 3,

        /// <summary>
        /// Enum ThreeMonths for value: 3M
        /// </summary>
        [EnumMember(Value = "3M")]
        ThreeMonths = 4,

        /// <summary>
        /// Enum OneYear for value: 1Y
        /// </summary>
        [EnumMember(Value = "1Y")]
        OneYear = 5,

        /// <summary>
        /// Enum Custom for value: custom
        /// </summary>
        [EnumMember(Value = "custom")]
        Custom = 6
    }

}
