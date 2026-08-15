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
    /// The type of thing this trigger responds to. A limited set is possible
    /// </summary>
    /// <remarks>
    /// The OpenAPI specification lists only the first 36 values, but Firefly III accepts every
    /// search operator as a rule trigger (config/search.php) and returns them verbatim from
    /// GET /api/v1/rules. The remaining members are those operators; unrecognised wire values
    /// deserialize to <see cref="Unknown"/> rather than throwing, since upstream keeps adding
    /// operators the specification does not list.
    /// </remarks>
    /// <value>The type of thing this trigger responds to. A limited set is possible</value>
    [JsonConverter(typeof(FireflyIIINet.Client.StringEnumMemberConverter))]
    public enum RuleTriggerKeyword
    {
        /// <summary>
        /// Enum FromAccountStarts for value: from_account_starts
        /// </summary>
        [EnumMember(Value = "from_account_starts")]
        FromAccountStarts = 1,

        /// <summary>
        /// Enum FromAccountEnds for value: from_account_ends
        /// </summary>
        [EnumMember(Value = "from_account_ends")]
        FromAccountEnds = 2,

        /// <summary>
        /// Enum FromAccountIs for value: from_account_is
        /// </summary>
        [EnumMember(Value = "from_account_is")]
        FromAccountIs = 3,

        /// <summary>
        /// Enum FromAccountContains for value: from_account_contains
        /// </summary>
        [EnumMember(Value = "from_account_contains")]
        FromAccountContains = 4,

        /// <summary>
        /// Enum ToAccountStarts for value: to_account_starts
        /// </summary>
        [EnumMember(Value = "to_account_starts")]
        ToAccountStarts = 5,

        /// <summary>
        /// Enum ToAccountEnds for value: to_account_ends
        /// </summary>
        [EnumMember(Value = "to_account_ends")]
        ToAccountEnds = 6,

        /// <summary>
        /// Enum ToAccountIs for value: to_account_is
        /// </summary>
        [EnumMember(Value = "to_account_is")]
        ToAccountIs = 7,

        /// <summary>
        /// Enum ToAccountContains for value: to_account_contains
        /// </summary>
        [EnumMember(Value = "to_account_contains")]
        ToAccountContains = 8,

        /// <summary>
        /// Enum AmountLess for value: amount_less
        /// </summary>
        [EnumMember(Value = "amount_less")]
        AmountLess = 9,

        /// <summary>
        /// Enum AmountExactly for value: amount_exactly
        /// </summary>
        [EnumMember(Value = "amount_exactly")]
        AmountExactly = 10,

        /// <summary>
        /// Enum AmountMore for value: amount_more
        /// </summary>
        [EnumMember(Value = "amount_more")]
        AmountMore = 11,

        /// <summary>
        /// Enum DescriptionStarts for value: description_starts
        /// </summary>
        [EnumMember(Value = "description_starts")]
        DescriptionStarts = 12,

        /// <summary>
        /// Enum DescriptionEnds for value: description_ends
        /// </summary>
        [EnumMember(Value = "description_ends")]
        DescriptionEnds = 13,

        /// <summary>
        /// Enum DescriptionContains for value: description_contains
        /// </summary>
        [EnumMember(Value = "description_contains")]
        DescriptionContains = 14,

        /// <summary>
        /// Enum DescriptionIs for value: description_is
        /// </summary>
        [EnumMember(Value = "description_is")]
        DescriptionIs = 15,

        /// <summary>
        /// Enum TransactionType for value: transaction_type
        /// </summary>
        [EnumMember(Value = "transaction_type")]
        TransactionType = 16,

        /// <summary>
        /// Enum CategoryIs for value: category_is
        /// </summary>
        [EnumMember(Value = "category_is")]
        CategoryIs = 17,

        /// <summary>
        /// Enum BudgetIs for value: budget_is
        /// </summary>
        [EnumMember(Value = "budget_is")]
        BudgetIs = 18,

        /// <summary>
        /// Enum TagIs for value: tag_is
        /// </summary>
        [EnumMember(Value = "tag_is")]
        TagIs = 19,

        /// <summary>
        /// Enum CurrencyIs for value: currency_is
        /// </summary>
        [EnumMember(Value = "currency_is")]
        CurrencyIs = 20,

        /// <summary>
        /// Enum HasAttachments for value: has_attachments
        /// </summary>
        [EnumMember(Value = "has_attachments")]
        HasAttachments = 21,

        /// <summary>
        /// Enum HasNoCategory for value: has_no_category
        /// </summary>
        [EnumMember(Value = "has_no_category")]
        HasNoCategory = 22,

        /// <summary>
        /// Enum HasAnyCategory for value: has_any_category
        /// </summary>
        [EnumMember(Value = "has_any_category")]
        HasAnyCategory = 23,

        /// <summary>
        /// Enum HasNoBudget for value: has_no_budget
        /// </summary>
        [EnumMember(Value = "has_no_budget")]
        HasNoBudget = 24,

        /// <summary>
        /// Enum HasAnyBudget for value: has_any_budget
        /// </summary>
        [EnumMember(Value = "has_any_budget")]
        HasAnyBudget = 25,

        /// <summary>
        /// Enum HasNoTag for value: has_no_tag
        /// </summary>
        [EnumMember(Value = "has_no_tag")]
        HasNoTag = 26,

        /// <summary>
        /// Enum HasAnyTag for value: has_any_tag
        /// </summary>
        [EnumMember(Value = "has_any_tag")]
        HasAnyTag = 27,

        /// <summary>
        /// Enum NotesContains for value: notes_contains
        /// </summary>
        [EnumMember(Value = "notes_contains")]
        NotesContains = 28,

        /// <summary>
        /// Enum NotesStarts for value: notes_starts
        /// </summary>
        [EnumMember(Value = "notes_starts")]
        NotesStarts = 29,

        /// <summary>
        /// Enum NotesEnd for value: notes_end
        /// </summary>
        [EnumMember(Value = "notes_end")]
        NotesEnd = 30,

        /// <summary>
        /// Enum NotesAre for value: notes_are
        /// </summary>
        [EnumMember(Value = "notes_are")]
        NotesAre = 31,

        /// <summary>
        /// Enum NoNotes for value: no_notes
        /// </summary>
        [EnumMember(Value = "no_notes")]
        NoNotes = 32,

        /// <summary>
        /// Enum AnyNotes for value: any_notes
        /// </summary>
        [EnumMember(Value = "any_notes")]
        AnyNotes = 33,

        /// <summary>
        /// Enum SourceAccountIs for value: source_account_is
        /// </summary>
        [EnumMember(Value = "source_account_is")]
        SourceAccountIs = 34,

        /// <summary>
        /// Enum DestinationAccountIs for value: destination_account_is
        /// </summary>
        [EnumMember(Value = "destination_account_is")]
        DestinationAccountIs = 35,

        /// <summary>
        /// Enum SourceAccountStarts for value: source_account_starts
        /// </summary>
        [EnumMember(Value = "source_account_starts")]
        SourceAccountStarts = 36,

        /// <summary>
        /// Enum AccountContains for value: account_contains
        /// </summary>
        [EnumMember(Value = "account_contains")]
        AccountContains = 37,

        /// <summary>
        /// Enum AccountEnds for value: account_ends
        /// </summary>
        [EnumMember(Value = "account_ends")]
        AccountEnds = 38,

        /// <summary>
        /// Enum AccountId for value: account_id
        /// </summary>
        [EnumMember(Value = "account_id")]
        AccountId = 39,

        /// <summary>
        /// Enum AccountIs for value: account_is
        /// </summary>
        [EnumMember(Value = "account_is")]
        AccountIs = 40,

        /// <summary>
        /// Enum AccountIsCash for value: account_is_cash
        /// </summary>
        [EnumMember(Value = "account_is_cash")]
        AccountIsCash = 41,

        /// <summary>
        /// Enum AccountNrContains for value: account_nr_contains
        /// </summary>
        [EnumMember(Value = "account_nr_contains")]
        AccountNrContains = 42,

        /// <summary>
        /// Enum AccountNrEnds for value: account_nr_ends
        /// </summary>
        [EnumMember(Value = "account_nr_ends")]
        AccountNrEnds = 43,

        /// <summary>
        /// Enum AccountNrIs for value: account_nr_is
        /// </summary>
        [EnumMember(Value = "account_nr_is")]
        AccountNrIs = 44,

        /// <summary>
        /// Enum AccountNrStarts for value: account_nr_starts
        /// </summary>
        [EnumMember(Value = "account_nr_starts")]
        AccountNrStarts = 45,

        /// <summary>
        /// Enum AccountStarts for value: account_starts
        /// </summary>
        [EnumMember(Value = "account_starts")]
        AccountStarts = 46,

        /// <summary>
        /// Enum AmountIs for value: amount_is
        /// </summary>
        [EnumMember(Value = "amount_is")]
        AmountIs = 47,

        /// <summary>
        /// Enum AnyExternalId for value: any_external_id
        /// </summary>
        [EnumMember(Value = "any_external_id")]
        AnyExternalId = 48,

        /// <summary>
        /// Enum AnyExternalUrl for value: any_external_url
        /// </summary>
        [EnumMember(Value = "any_external_url")]
        AnyExternalUrl = 49,

        /// <summary>
        /// Enum AttachmentNameContains for value: attachment_name_contains
        /// </summary>
        [EnumMember(Value = "attachment_name_contains")]
        AttachmentNameContains = 50,

        /// <summary>
        /// Enum AttachmentNameEnds for value: attachment_name_ends
        /// </summary>
        [EnumMember(Value = "attachment_name_ends")]
        AttachmentNameEnds = 51,

        /// <summary>
        /// Enum AttachmentNameIs for value: attachment_name_is
        /// </summary>
        [EnumMember(Value = "attachment_name_is")]
        AttachmentNameIs = 52,

        /// <summary>
        /// Enum AttachmentNameStarts for value: attachment_name_starts
        /// </summary>
        [EnumMember(Value = "attachment_name_starts")]
        AttachmentNameStarts = 53,

        /// <summary>
        /// Enum AttachmentNotesAre for value: attachment_notes_are
        /// </summary>
        [EnumMember(Value = "attachment_notes_are")]
        AttachmentNotesAre = 54,

        /// <summary>
        /// Enum AttachmentNotesContains for value: attachment_notes_contains
        /// </summary>
        [EnumMember(Value = "attachment_notes_contains")]
        AttachmentNotesContains = 55,

        /// <summary>
        /// Enum AttachmentNotesEnds for value: attachment_notes_ends
        /// </summary>
        [EnumMember(Value = "attachment_notes_ends")]
        AttachmentNotesEnds = 56,

        /// <summary>
        /// Enum AttachmentNotesStarts for value: attachment_notes_starts
        /// </summary>
        [EnumMember(Value = "attachment_notes_starts")]
        AttachmentNotesStarts = 57,

        /// <summary>
        /// Enum BillContains for value: bill_contains
        /// </summary>
        [EnumMember(Value = "bill_contains")]
        BillContains = 58,

        /// <summary>
        /// Enum BillEnds for value: bill_ends
        /// </summary>
        [EnumMember(Value = "bill_ends")]
        BillEnds = 59,

        /// <summary>
        /// Enum BillIs for value: bill_is
        /// </summary>
        [EnumMember(Value = "bill_is")]
        BillIs = 60,

        /// <summary>
        /// Enum BillStarts for value: bill_starts
        /// </summary>
        [EnumMember(Value = "bill_starts")]
        BillStarts = 61,

        /// <summary>
        /// Enum BookDateAfter for value: book_date_after
        /// </summary>
        [EnumMember(Value = "book_date_after")]
        BookDateAfter = 62,

        /// <summary>
        /// Enum BookDateBefore for value: book_date_before
        /// </summary>
        [EnumMember(Value = "book_date_before")]
        BookDateBefore = 63,

        /// <summary>
        /// Enum BookDateOn for value: book_date_on
        /// </summary>
        [EnumMember(Value = "book_date_on")]
        BookDateOn = 64,

        /// <summary>
        /// Enum BudgetContains for value: budget_contains
        /// </summary>
        [EnumMember(Value = "budget_contains")]
        BudgetContains = 65,

        /// <summary>
        /// Enum BudgetEnds for value: budget_ends
        /// </summary>
        [EnumMember(Value = "budget_ends")]
        BudgetEnds = 66,

        /// <summary>
        /// Enum BudgetStarts for value: budget_starts
        /// </summary>
        [EnumMember(Value = "budget_starts")]
        BudgetStarts = 67,

        /// <summary>
        /// Enum CategoryContains for value: category_contains
        /// </summary>
        [EnumMember(Value = "category_contains")]
        CategoryContains = 68,

        /// <summary>
        /// Enum CategoryEnds for value: category_ends
        /// </summary>
        [EnumMember(Value = "category_ends")]
        CategoryEnds = 69,

        /// <summary>
        /// Enum CategoryStarts for value: category_starts
        /// </summary>
        [EnumMember(Value = "category_starts")]
        CategoryStarts = 70,

        /// <summary>
        /// Enum CreatedAtAfter for value: created_at_after
        /// </summary>
        [EnumMember(Value = "created_at_after")]
        CreatedAtAfter = 71,

        /// <summary>
        /// Enum CreatedAtBefore for value: created_at_before
        /// </summary>
        [EnumMember(Value = "created_at_before")]
        CreatedAtBefore = 72,

        /// <summary>
        /// Enum CreatedAtOn for value: created_at_on
        /// </summary>
        [EnumMember(Value = "created_at_on")]
        CreatedAtOn = 73,

        /// <summary>
        /// Enum DateAfter for value: date_after
        /// </summary>
        [EnumMember(Value = "date_after")]
        DateAfter = 74,

        /// <summary>
        /// Enum DateBefore for value: date_before
        /// </summary>
        [EnumMember(Value = "date_before")]
        DateBefore = 75,

        /// <summary>
        /// Enum DateOn for value: date_on
        /// </summary>
        [EnumMember(Value = "date_on")]
        DateOn = 76,

        /// <summary>
        /// Enum DestinationAccountContains for value: destination_account_contains
        /// </summary>
        [EnumMember(Value = "destination_account_contains")]
        DestinationAccountContains = 77,

        /// <summary>
        /// Enum DestinationAccountEnds for value: destination_account_ends
        /// </summary>
        [EnumMember(Value = "destination_account_ends")]
        DestinationAccountEnds = 78,

        /// <summary>
        /// Enum DestinationAccountId for value: destination_account_id
        /// </summary>
        [EnumMember(Value = "destination_account_id")]
        DestinationAccountId = 79,

        /// <summary>
        /// Enum DestinationAccountNrContains for value: destination_account_nr_contains
        /// </summary>
        [EnumMember(Value = "destination_account_nr_contains")]
        DestinationAccountNrContains = 80,

        /// <summary>
        /// Enum DestinationAccountNrEnds for value: destination_account_nr_ends
        /// </summary>
        [EnumMember(Value = "destination_account_nr_ends")]
        DestinationAccountNrEnds = 81,

        /// <summary>
        /// Enum DestinationAccountNrIs for value: destination_account_nr_is
        /// </summary>
        [EnumMember(Value = "destination_account_nr_is")]
        DestinationAccountNrIs = 82,

        /// <summary>
        /// Enum DestinationAccountNrStarts for value: destination_account_nr_starts
        /// </summary>
        [EnumMember(Value = "destination_account_nr_starts")]
        DestinationAccountNrStarts = 83,

        /// <summary>
        /// Enum DestinationAccountStarts for value: destination_account_starts
        /// </summary>
        [EnumMember(Value = "destination_account_starts")]
        DestinationAccountStarts = 84,

        /// <summary>
        /// Enum DestinationBalanceGt for value: destination_balance_gt
        /// </summary>
        [EnumMember(Value = "destination_balance_gt")]
        DestinationBalanceGt = 85,

        /// <summary>
        /// Enum DestinationBalanceGte for value: destination_balance_gte
        /// </summary>
        [EnumMember(Value = "destination_balance_gte")]
        DestinationBalanceGte = 86,

        /// <summary>
        /// Enum DestinationBalanceIs for value: destination_balance_is
        /// </summary>
        [EnumMember(Value = "destination_balance_is")]
        DestinationBalanceIs = 87,

        /// <summary>
        /// Enum DestinationBalanceLt for value: destination_balance_lt
        /// </summary>
        [EnumMember(Value = "destination_balance_lt")]
        DestinationBalanceLt = 88,

        /// <summary>
        /// Enum DestinationBalanceLte for value: destination_balance_lte
        /// </summary>
        [EnumMember(Value = "destination_balance_lte")]
        DestinationBalanceLte = 89,

        /// <summary>
        /// Enum DestinationIsCash for value: destination_is_cash
        /// </summary>
        [EnumMember(Value = "destination_is_cash")]
        DestinationIsCash = 90,

        /// <summary>
        /// Enum DueDateAfter for value: due_date_after
        /// </summary>
        [EnumMember(Value = "due_date_after")]
        DueDateAfter = 91,

        /// <summary>
        /// Enum DueDateBefore for value: due_date_before
        /// </summary>
        [EnumMember(Value = "due_date_before")]
        DueDateBefore = 92,

        /// <summary>
        /// Enum DueDateOn for value: due_date_on
        /// </summary>
        [EnumMember(Value = "due_date_on")]
        DueDateOn = 93,

        /// <summary>
        /// Enum Exists for value: exists
        /// </summary>
        [EnumMember(Value = "exists")]
        Exists = 94,

        /// <summary>
        /// Enum ExternalIdContains for value: external_id_contains
        /// </summary>
        [EnumMember(Value = "external_id_contains")]
        ExternalIdContains = 95,

        /// <summary>
        /// Enum ExternalIdEnds for value: external_id_ends
        /// </summary>
        [EnumMember(Value = "external_id_ends")]
        ExternalIdEnds = 96,

        /// <summary>
        /// Enum ExternalIdIs for value: external_id_is
        /// </summary>
        [EnumMember(Value = "external_id_is")]
        ExternalIdIs = 97,

        /// <summary>
        /// Enum ExternalIdStarts for value: external_id_starts
        /// </summary>
        [EnumMember(Value = "external_id_starts")]
        ExternalIdStarts = 98,

        /// <summary>
        /// Enum ExternalUrlContains for value: external_url_contains
        /// </summary>
        [EnumMember(Value = "external_url_contains")]
        ExternalUrlContains = 99,

        /// <summary>
        /// Enum ExternalUrlEnds for value: external_url_ends
        /// </summary>
        [EnumMember(Value = "external_url_ends")]
        ExternalUrlEnds = 100,

        /// <summary>
        /// Enum ExternalUrlIs for value: external_url_is
        /// </summary>
        [EnumMember(Value = "external_url_is")]
        ExternalUrlIs = 101,

        /// <summary>
        /// Enum ExternalUrlStarts for value: external_url_starts
        /// </summary>
        [EnumMember(Value = "external_url_starts")]
        ExternalUrlStarts = 102,

        /// <summary>
        /// Enum ForeignAmountIs for value: foreign_amount_is
        /// </summary>
        [EnumMember(Value = "foreign_amount_is")]
        ForeignAmountIs = 103,

        /// <summary>
        /// Enum ForeignAmountLess for value: foreign_amount_less
        /// </summary>
        [EnumMember(Value = "foreign_amount_less")]
        ForeignAmountLess = 104,

        /// <summary>
        /// Enum ForeignAmountMore for value: foreign_amount_more
        /// </summary>
        [EnumMember(Value = "foreign_amount_more")]
        ForeignAmountMore = 105,

        /// <summary>
        /// Enum ForeignCurrencyIs for value: foreign_currency_is
        /// </summary>
        [EnumMember(Value = "foreign_currency_is")]
        ForeignCurrencyIs = 106,

        /// <summary>
        /// Enum HasAnyBill for value: has_any_bill
        /// </summary>
        [EnumMember(Value = "has_any_bill")]
        HasAnyBill = 107,

        /// <summary>
        /// Enum HasNoAttachments for value: has_no_attachments
        /// </summary>
        [EnumMember(Value = "has_no_attachments")]
        HasNoAttachments = 108,

        /// <summary>
        /// Enum HasNoBill for value: has_no_bill
        /// </summary>
        [EnumMember(Value = "has_no_bill")]
        HasNoBill = 109,

        /// <summary>
        /// Enum Id for value: id
        /// </summary>
        [EnumMember(Value = "id")]
        Id = 110,

        /// <summary>
        /// Enum InterestDateAfter for value: interest_date_after
        /// </summary>
        [EnumMember(Value = "interest_date_after")]
        InterestDateAfter = 111,

        /// <summary>
        /// Enum InterestDateBefore for value: interest_date_before
        /// </summary>
        [EnumMember(Value = "interest_date_before")]
        InterestDateBefore = 112,

        /// <summary>
        /// Enum InterestDateOn for value: interest_date_on
        /// </summary>
        [EnumMember(Value = "interest_date_on")]
        InterestDateOn = 113,

        /// <summary>
        /// Enum InternalReferenceContains for value: internal_reference_contains
        /// </summary>
        [EnumMember(Value = "internal_reference_contains")]
        InternalReferenceContains = 114,

        /// <summary>
        /// Enum InternalReferenceEnds for value: internal_reference_ends
        /// </summary>
        [EnumMember(Value = "internal_reference_ends")]
        InternalReferenceEnds = 115,

        /// <summary>
        /// Enum InternalReferenceIs for value: internal_reference_is
        /// </summary>
        [EnumMember(Value = "internal_reference_is")]
        InternalReferenceIs = 116,

        /// <summary>
        /// Enum InternalReferenceStarts for value: internal_reference_starts
        /// </summary>
        [EnumMember(Value = "internal_reference_starts")]
        InternalReferenceStarts = 117,

        /// <summary>
        /// Enum InvoiceDateAfter for value: invoice_date_after
        /// </summary>
        [EnumMember(Value = "invoice_date_after")]
        InvoiceDateAfter = 118,

        /// <summary>
        /// Enum InvoiceDateBefore for value: invoice_date_before
        /// </summary>
        [EnumMember(Value = "invoice_date_before")]
        InvoiceDateBefore = 119,

        /// <summary>
        /// Enum InvoiceDateOn for value: invoice_date_on
        /// </summary>
        [EnumMember(Value = "invoice_date_on")]
        InvoiceDateOn = 120,

        /// <summary>
        /// Enum JournalId for value: journal_id
        /// </summary>
        [EnumMember(Value = "journal_id")]
        JournalId = 121,

        /// <summary>
        /// Enum NoExternalId for value: no_external_id
        /// </summary>
        [EnumMember(Value = "no_external_id")]
        NoExternalId = 122,

        /// <summary>
        /// Enum NoExternalUrl for value: no_external_url
        /// </summary>
        [EnumMember(Value = "no_external_url")]
        NoExternalUrl = 123,

        /// <summary>
        /// Enum NotesEnds for value: notes_ends
        /// </summary>
        [EnumMember(Value = "notes_ends")]
        NotesEnds = 124,

        /// <summary>
        /// Enum NotesIs for value: notes_is
        /// </summary>
        [EnumMember(Value = "notes_is")]
        NotesIs = 125,

        /// <summary>
        /// Enum PaymentDateAfter for value: payment_date_after
        /// </summary>
        [EnumMember(Value = "payment_date_after")]
        PaymentDateAfter = 126,

        /// <summary>
        /// Enum PaymentDateBefore for value: payment_date_before
        /// </summary>
        [EnumMember(Value = "payment_date_before")]
        PaymentDateBefore = 127,

        /// <summary>
        /// Enum PaymentDateOn for value: payment_date_on
        /// </summary>
        [EnumMember(Value = "payment_date_on")]
        PaymentDateOn = 128,

        /// <summary>
        /// Enum ProcessDateAfter for value: process_date_after
        /// </summary>
        [EnumMember(Value = "process_date_after")]
        ProcessDateAfter = 129,

        /// <summary>
        /// Enum ProcessDateBefore for value: process_date_before
        /// </summary>
        [EnumMember(Value = "process_date_before")]
        ProcessDateBefore = 130,

        /// <summary>
        /// Enum ProcessDateOn for value: process_date_on
        /// </summary>
        [EnumMember(Value = "process_date_on")]
        ProcessDateOn = 131,

        /// <summary>
        /// Enum Reconciled for value: reconciled
        /// </summary>
        [EnumMember(Value = "reconciled")]
        Reconciled = 132,

        /// <summary>
        /// Enum RecurrenceId for value: recurrence_id
        /// </summary>
        [EnumMember(Value = "recurrence_id")]
        RecurrenceId = 133,

        /// <summary>
        /// Enum SepaCtIs for value: sepa_ct_is
        /// </summary>
        [EnumMember(Value = "sepa_ct_is")]
        SepaCtIs = 134,

        /// <summary>
        /// Enum SourceAccountContains for value: source_account_contains
        /// </summary>
        [EnumMember(Value = "source_account_contains")]
        SourceAccountContains = 135,

        /// <summary>
        /// Enum SourceAccountEnds for value: source_account_ends
        /// </summary>
        [EnumMember(Value = "source_account_ends")]
        SourceAccountEnds = 136,

        /// <summary>
        /// Enum SourceAccountId for value: source_account_id
        /// </summary>
        [EnumMember(Value = "source_account_id")]
        SourceAccountId = 137,

        /// <summary>
        /// Enum SourceAccountNrContains for value: source_account_nr_contains
        /// </summary>
        [EnumMember(Value = "source_account_nr_contains")]
        SourceAccountNrContains = 138,

        /// <summary>
        /// Enum SourceAccountNrEnds for value: source_account_nr_ends
        /// </summary>
        [EnumMember(Value = "source_account_nr_ends")]
        SourceAccountNrEnds = 139,

        /// <summary>
        /// Enum SourceAccountNrIs for value: source_account_nr_is
        /// </summary>
        [EnumMember(Value = "source_account_nr_is")]
        SourceAccountNrIs = 140,

        /// <summary>
        /// Enum SourceAccountNrStarts for value: source_account_nr_starts
        /// </summary>
        [EnumMember(Value = "source_account_nr_starts")]
        SourceAccountNrStarts = 141,

        /// <summary>
        /// Enum SourceBalanceGt for value: source_balance_gt
        /// </summary>
        [EnumMember(Value = "source_balance_gt")]
        SourceBalanceGt = 142,

        /// <summary>
        /// Enum SourceBalanceGte for value: source_balance_gte
        /// </summary>
        [EnumMember(Value = "source_balance_gte")]
        SourceBalanceGte = 143,

        /// <summary>
        /// Enum SourceBalanceIs for value: source_balance_is
        /// </summary>
        [EnumMember(Value = "source_balance_is")]
        SourceBalanceIs = 144,

        /// <summary>
        /// Enum SourceBalanceLt for value: source_balance_lt
        /// </summary>
        [EnumMember(Value = "source_balance_lt")]
        SourceBalanceLt = 145,

        /// <summary>
        /// Enum SourceBalanceLte for value: source_balance_lte
        /// </summary>
        [EnumMember(Value = "source_balance_lte")]
        SourceBalanceLte = 146,

        /// <summary>
        /// Enum SourceIsCash for value: source_is_cash
        /// </summary>
        [EnumMember(Value = "source_is_cash")]
        SourceIsCash = 147,

        /// <summary>
        /// Enum TagContains for value: tag_contains
        /// </summary>
        [EnumMember(Value = "tag_contains")]
        TagContains = 148,

        /// <summary>
        /// Enum TagEnds for value: tag_ends
        /// </summary>
        [EnumMember(Value = "tag_ends")]
        TagEnds = 149,

        /// <summary>
        /// Enum TagIsNot for value: tag_is_not
        /// </summary>
        [EnumMember(Value = "tag_is_not")]
        TagIsNot = 150,

        /// <summary>
        /// Enum TagStarts for value: tag_starts
        /// </summary>
        [EnumMember(Value = "tag_starts")]
        TagStarts = 151,

        /// <summary>
        /// Enum UpdatedAtAfter for value: updated_at_after
        /// </summary>
        [EnumMember(Value = "updated_at_after")]
        UpdatedAtAfter = 152,

        /// <summary>
        /// Enum UpdatedAtBefore for value: updated_at_before
        /// </summary>
        [EnumMember(Value = "updated_at_before")]
        UpdatedAtBefore = 153,

        /// <summary>
        /// Enum UpdatedAtOn for value: updated_at_on
        /// </summary>
        [EnumMember(Value = "updated_at_on")]
        UpdatedAtOn = 154,

        /// <summary>
        /// Enum UserAction for value: user_action
        /// </summary>
        [EnumMember(Value = "user_action")]
        UserAction = 155,

        /// <summary>
        /// Enum Unknown: a trigger keyword this SDK does not know. Firefly III adds search
        /// operators faster than the OpenAPI specification lists them, so an unrecognised
        /// value deserializes here instead of failing the whole response. Do not send it back
        /// to the API - a rule read with an Unknown trigger cannot be round-tripped safely.
        /// </summary>
        [EnumMember(Value = "unknown")]
        Unknown = 0
    }

}