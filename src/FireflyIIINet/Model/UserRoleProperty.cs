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
    /// Role for the user. Can be empty or omitted.
    /// </summary>
    /// <value>Role for the user. Can be empty or omitted.</value>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum UserRoleProperty
    {
        /// <summary>
        /// Enum Owner for value: owner
        /// </summary>
        [EnumMember(Value = "owner")]
        Owner = 1,

        /// <summary>
        /// Enum Demo for value: demo
        /// </summary>
        [EnumMember(Value = "demo")]
        Demo = 2,

        /// <summary>
        /// Enum Null for value: null
        /// </summary>
        [EnumMember(Value = "null")]
        Null = 3
    }

}
