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
    /// Which action is necessary for the rule to fire? Use either store-journal, update-journal or manual-activation.
    /// </summary>
    /// <value>Which action is necessary for the rule to fire? Use either store-journal, update-journal or manual-activation.</value>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum RuleTriggerType
    {
        /// <summary>
        /// Enum StoreJournal for value: store-journal
        /// </summary>
        [EnumMember(Value = "store-journal")]
        StoreJournal = 1,

        /// <summary>
        /// Enum UpdateJournal for value: update-journal
        /// </summary>
        [EnumMember(Value = "update-journal")]
        UpdateJournal = 2,

        /// <summary>
        /// Enum ManualActivation for value: manual-activation
        /// </summary>
        [EnumMember(Value = "manual-activation")]
        ManualActivation = 3
    }

}
