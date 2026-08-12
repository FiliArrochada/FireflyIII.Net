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
    /// &#39;credit&#39; indicates somebody owes you the liability. &#39;debit&#39; Indicates you owe this debt yourself. Works only for liabiltiies.
    /// </summary>
    /// <value>&#39;credit&#39; indicates somebody owes you the liability. &#39;debit&#39; Indicates you owe this debt yourself. Works only for liabiltiies.</value>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum LiabilityDirectionProperty
    {
        /// <summary>
        /// Enum Credit for value: credit
        /// </summary>
        [EnumMember(Value = "credit")]
        Credit = 1,

        /// <summary>
        /// Enum Debit for value: debit
        /// </summary>
        [EnumMember(Value = "debit")]
        Debit = 2,

        /// <summary>
        /// Enum Null for value: null
        /// </summary>
        [EnumMember(Value = "null")]
        Null = 3
    }

}
