/*
 * ECE 461 - Spring 2023 - Project 2
 *
 * API for ECE 461/Spring 2023/Project 2: A Trustworthy Module Registry
 *
 * OpenAPI spec version: 2.0.0
 * Contact: davisjam@purdue.edu
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PakageRegistry.Models
{
    /// <summary>
    /// One entry of the history of this package.
    /// </summary>
    [DataContract]
    public partial class PackageHistoryEntry : IEquatable<PackageHistoryEntry>
    {
        /// <summary>
        /// Gets or Sets User
        /// </summary>
        [Required]

        [DataMember(Name = "User")]
        public User User { get; set; }

        /// <summary>
        /// Date of activity using ISO-8601 Datetime standard in UTC format.
        /// </summary>
        /// <value>Date of activity using ISO-8601 Datetime standard in UTC format.</value>
        [Required]

        [DataMember(Name = "Date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Gets or Sets PackageMetadata
        /// </summary>
        [Required]

        [DataMember(Name = "PackageMetadata")]
        public PackageMetadata PackageMetadata { get; set; }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum ActionEnum
        {
            /// <summary>
            /// Enum CREATEEnum for CREATE
            /// </summary>
            [EnumMember(Value = "CREATE")]
            CREATEEnum = 0,
            /// <summary>
            /// Enum UPDATEEnum for UPDATE
            /// </summary>
            [EnumMember(Value = "UPDATE")]
            UPDATEEnum = 1,
            /// <summary>
            /// Enum DOWNLOADEnum for DOWNLOAD
            /// </summary>
            [EnumMember(Value = "DOWNLOAD")]
            DOWNLOADEnum = 2,
            /// <summary>
            /// Enum RATEEnum for RATE
            /// </summary>
            [EnumMember(Value = "RATE")]
            RATEEnum = 3
        }

        /// <summary>
        /// Gets or Sets Action
        /// </summary>
        [Required]

        [DataMember(Name = "Action")]
        public ActionEnum? Action { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PackageHistoryEntry {\n");
            sb.Append("  User: ").Append(User).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  PackageMetadata: ").Append(PackageMetadata).Append("\n");
            sb.Append("  Action: ").Append(Action).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((PackageHistoryEntry)obj);
        }

        /// <summary>
        /// Returns true if PackageHistoryEntry instances are equal
        /// </summary>
        /// <param name="other">Instance of PackageHistoryEntry to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PackageHistoryEntry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    User == other.User ||
                    User != null &&
                    User.Equals(other.User)
                ) &&
                (
                    Date == other.Date ||
                    Date != null &&
                    Date.Equals(other.Date)
                ) &&
                (
                    PackageMetadata == other.PackageMetadata ||
                    PackageMetadata != null &&
                    PackageMetadata.Equals(other.PackageMetadata)
                ) &&
                (
                    Action == other.Action ||
                    Action != null &&
                    Action.Equals(other.Action)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (User != null)
                    hashCode = hashCode * 59 + User.GetHashCode();
                if (Date != null)
                    hashCode = hashCode * 59 + Date.GetHashCode();
                if (PackageMetadata != null)
                    hashCode = hashCode * 59 + PackageMetadata.GetHashCode();
                if (Action != null)
                    hashCode = hashCode * 59 + Action.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(PackageHistoryEntry left, PackageHistoryEntry right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PackageHistoryEntry left, PackageHistoryEntry right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
