using System.Text.RegularExpressions;

using FluentValidation;

using Microsoft.AspNetCore.Http;

using Validation.Core.Validators.Common;
using Validation.Core.Validators.Date;
using Validation.Core.Validators.Format;
using Validation.Core.Validators.Localization;
using Validation.Core.Validators.Logic;
using Validation.Core.Validators.Network;
using Validation.Core.Validators.Numeric;
using Validation.Core.Validators.Security;

namespace Validation.Core.Extensions;
public static class RuleBuilderExtensions
{
    public static IRuleBuilderOptions<T, Guid> NotEmptyGuid<T>(
        this IRuleBuilder<T, Guid> ruleBuilder) =>
        ruleBuilder.SetValidator(new GuidNotEmptyValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidEmail<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new EmailValidator<T>());

    public static IRuleBuilderOptions<T, TProp> ValidPagination<T, TProp>(
        this IRuleBuilder<T, TProp> ruleBuilder) where TProp : IPagination =>
        ruleBuilder.SetValidator(new PaginationValidator<TProp>());

    public static IRuleBuilderOptions<T, string> TrimmedNotEmpty<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new TrimmedNotEmptyValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidPhone<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new PhoneNumberValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidUrl<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new UrlValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidIpAddress<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IpAddressValidator<T>());

    public static IRuleBuilderOptions<T, TEnum> ValidEnumValue<T, TEnum>(
        this IRuleBuilder<T, TEnum> ruleBuilder)
        where TEnum : struct, Enum =>
        ruleBuilder.SetValidator(new EnumValueValidator<T, TEnum>());

    public static IRuleBuilderOptions<T, DateTime> NotInFuture<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder) =>
        ruleBuilder.SetValidator(new DateNotInFutureValidator<T>());

    public static IRuleBuilderOptions<T, DateTime> NotInPast<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder) =>
        ruleBuilder.SetValidator(new DateNotInPastValidator<T>());

    public static IRuleBuilderOptions<T, decimal> HasPrecision<T>(
        this IRuleBuilder<T, decimal> ruleBuilder, int maxPrecision, int maxScale) =>
        ruleBuilder.SetValidator(new DecimalPrecisionValidator<T>(maxPrecision, maxScale));

    public static IRuleBuilderOptions<T, IFormFile> ValidFile<T>(
        this IRuleBuilder<T, IFormFile> ruleBuilder,
        long maxSizeInMb,
        string[]? allowedExtensions = null,
        string[]? allowedContentTypes = null) =>
        ruleBuilder.SetValidator(
            new FileValidator<T>(
                maxSizeInMb * 1024 * 1024,
                allowedExtensions,
                allowedContentTypes));

    public static IRuleBuilderOptions<T, string> StrongPassword<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        int minLength = 8) =>
        ruleBuilder.SetValidator(new PasswordStrengthValidator<T>(minLength));

    public static IRuleBuilderOptions<T, string> ValidBase64<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new Base64Validator<T>());

    public static IRuleBuilderOptions<T, string> ValidHex<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new HexStringValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidAccessToken<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new AccessTokenFormatValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidNationalId<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new NationalIdValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidPostalCode<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new PostalCodeValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidCreditCard<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new CreditCardValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidIban<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IBANValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidCurrency<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new CurrencyValidator<T>());

    public static IRuleBuilderOptions<T, string> OnlyLetters<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new OnlyLettersValidator<T>());

    public static IRuleBuilderOptions<T, string> AlphaNumeric<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new AlphaNumericValidator<T>());

    public static IRuleBuilderOptions<T, string> ContainsSpecialCharacter<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new ContainsSpecialCharactersValidator<T>());

    public static IRuleBuilderOptions<T, string> StartsWith<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string prefix,
        bool caseSensitive = false) =>
        ruleBuilder.SetValidator(new StartsWithValidator<T>(prefix, caseSensitive));

    public static IRuleBuilderOptions<T, string> EndsWith<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string suffix,
        bool caseSensitive = false) =>
        ruleBuilder.SetValidator(new EndsWithValidator<T>(suffix, caseSensitive));

    public static IRuleBuilderOptions<T, string> NoWhitespace<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new NoWhitespaceValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidSlug<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new SlugValidator<T>());

    public static IRuleBuilderOptions<T, string> MatchesRegex<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string pattern,
        RegexOptions options = RegexOptions.None) =>
        ruleBuilder.SetValidator(new RegexValidator<T>(pattern, options));

    public static IRuleBuilderOptions<T, string> ValidJson<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new JsonStringValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidXml<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new XmlStringValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidMacAddress<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new MacAddressValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidHostname<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new HostnameValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidYouTubeUrl<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new YouTubeUrlValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidInstagramUrl<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new InstagramUrlValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidVersionString<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new VersionStringValidator<T>());

    public static IRuleBuilderOptions<T, string> ValidJwtToken<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new JwtTokenValidator<T>());

    public static IRuleBuilderOptions<T, int> MustBePrime<T>(
        this IRuleBuilder<T, int> ruleBuilder) =>
        ruleBuilder.SetValidator(new PrimeNumberValidator<T>());

    public static IRuleBuilderOptions<T, int> MustBePowerOfTwo<T>(
        this IRuleBuilder<T, int> ruleBuilder) =>
        ruleBuilder.SetValidator(new PowerOfTwoValidator<T>());

    public static IRuleBuilderOptions<T, int> MustBeEven<T>(
        this IRuleBuilder<T, int> ruleBuilder) =>
        ruleBuilder.SetValidator(new EvenNumberValidator<T>());

    public static IRuleBuilderOptions<T, int> MustBeOdd<T>(
        this IRuleBuilder<T, int> ruleBuilder) =>
        ruleBuilder.SetValidator(new OddNumberValidator<T>());

    public static IRuleBuilderOptions<T, int> MustBeMultipleOf<T>(
        this IRuleBuilder<T, int> ruleBuilder, int divisor) =>
        ruleBuilder.SetValidator(new MultipleOfValidator<T>(divisor));

    public static IRuleBuilderOptions<T, int> MustHaveMinimumDigits<T>(
        this IRuleBuilder<T, int> ruleBuilder, int minDigits) =>
        ruleBuilder.SetValidator(new MinDigitsValidator<T>(minDigits));

    public static IRuleBuilderOptions<T, int> MustHaveMaximumDigits<T>(
        this IRuleBuilder<T, int> ruleBuilder, int maxDigits) =>
        ruleBuilder.SetValidator(new MaxDigitsValidator<T>(maxDigits));

    public static IRuleBuilderOptions<T, TimeOnly> MustBeInTimeRange<T>(
        this IRuleBuilder<T, TimeOnly> ruleBuilder, TimeOnly start, TimeOnly end) =>
        ruleBuilder.SetValidator(new TimeRangeValidator<T>(start, end));

    public static IRuleBuilderOptions<T, DateOnly> MustBeWeekend<T>(
        this IRuleBuilder<T, DateOnly> ruleBuilder) =>
        ruleBuilder.SetValidator(new WeekendValidator<T>());

    public static IRuleBuilderOptions<T, DateOnly> MustBeWeekday<T>(
        this IRuleBuilder<T, DateOnly> ruleBuilder) =>
        ruleBuilder.SetValidator(new WeekdayValidator<T>());

    public static IRuleBuilderOptions<T, DateOnly> MustBeInLeapYear<T>(
        this IRuleBuilder<T, DateOnly> ruleBuilder) =>
        ruleBuilder.SetValidator(new LeapYearValidator<T>());

    public static IRuleBuilderOptions<T, DateOnly> MustBeBusinessDay<T>(
        this IRuleBuilder<T, DateOnly> ruleBuilder) =>
        ruleBuilder.SetValidator(new BusinessDayValidator<T>());

    public static IRuleBuilderOptions<T, string> MustContainUppercase<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new PasswordHasUppercaseValidator<T>());

    public static IRuleBuilderOptions<T, string> MustContainNumber<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new PasswordHasNumberValidator<T>());

    public static IRuleBuilderOptions<T, string> MustContainSymbol<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new PasswordHasSymbolValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeXssSafe<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new XssSafeStringValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeSqlInjectionSafe<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new SqlInjectionSafeValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeEncryptedFormat<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new EncryptedStringValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeValidCountryCode<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new CountryCodeValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeValidLanguageCode<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new LanguageCodeValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeValidCurrencyCode<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new CurrencyCodeValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeValidTurkishPhoneNumber<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new TurkishPhoneNumberValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeEqualTo<T>(
        this IRuleBuilder<T, string> ruleBuilder, string otherPropertyName) =>
        ruleBuilder.SetValidator(new EqualToOtherPropertyValidator<T>(otherPropertyName));

    public static IRuleBuilderOptions<T, string> MustNotBeEqualTo<T>(
        this IRuleBuilder<T, string> ruleBuilder, string otherPropertyName) =>
        ruleBuilder.SetValidator(new NotEqualToOtherPropertyValidator<T>(otherPropertyName));

    public static IRuleBuilderOptions<T, string> RequiredWhen<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        string dependentProperty,
        string? requiredWhenValue = null) =>
        ruleBuilder.SetValidator(new ConditionalRequiredValidator<T>(dependentProperty, requiredWhenValue));

    public static IRuleBuilderOptions<T, T> MustHaveOnlyOneSet<T>(
        this IRuleBuilder<T, T> ruleBuilder, params string[] propertyNames) =>
        ruleBuilder.SetValidator(new MutuallyExclusivePropertiesValidator<T>(propertyNames));

    public static IRuleBuilderOptions<T, string> AlwaysValid<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new AlwaysValidValidator<T>());

    public static IRuleBuilderOptions<T, string> AlwaysInvalid<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new AlwaysInvalidValidator<T>());

    public static IRuleBuilderOptions<T, string> MustStartWithUppercase<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new StartsWithUppercaseValidator<T>());

    public static IRuleBuilderOptions<T, string> LettersIfNotEmpty<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new OptionalOnlyLettersValidator<T>());

    public static IRuleBuilderOptions<T, string> NoSpecialCharacters<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new NoSpecialCharactersValidator<T>());

    public static IRuleBuilderOptions<T, DateTime> MustBeDateOnly<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder) =>
        ruleBuilder.SetValidator(new DateOnlyValidator<T>());

    public static IRuleBuilderOptions<T, DateTime> MustBeInFuture<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder) =>
        ruleBuilder.SetValidator(new FutureDateValidator<T>());

    public static IRuleBuilderOptions<T, DateTime> MustBeInPast<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder) =>
        ruleBuilder.SetValidator(new PastDateValidator<T>());

    public static IRuleBuilderOptions<T, DateTime> MustBeUtc<T>(
        this IRuleBuilder<T, DateTime> ruleBuilder) =>
        ruleBuilder.SetValidator(new UtcDateValidator<T>());

    public static IRuleBuilderOptions<T, decimal> MustBePercentage<T>(
        this IRuleBuilder<T, decimal> ruleBuilder) =>
        ruleBuilder.SetValidator(new RangePercentageValidator<T>());

    public static IRuleBuilderOptions<T, int> MustNotBeZero<T>(
        this IRuleBuilder<T, int> ruleBuilder) =>
        ruleBuilder.SetValidator(new NotZeroValidator<T>());

    public static IRuleBuilderOptions<T, int> MustBeDivisibleBy<T>(
        this IRuleBuilder<T, int> ruleBuilder, int divisor) =>
        ruleBuilder.SetValidator(new DivisibleByValidator<T>(divisor));

    public static IRuleBuilderOptions<T, string> MustBeUppercase<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new UppercaseValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeLowercase<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new LowercaseValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeKebabCase<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new KebabCaseValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeCamelCase<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new CamelCaseValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBePascalCase<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new PascalCaseValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeHexColorCode<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new HexColorCodeValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeMimeType<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new MimeTypeValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeComplexPassword<T>(
        this IRuleBuilder<T, string> ruleBuilder, int minLength = 8) =>
        ruleBuilder.SetValidator(new PasswordComplexityValidator<T>(minLength));

    public static IRuleBuilderOptions<T, string> MustNotContainUnicodeSymbols<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new NoUnicodeSymbolsValidator<T>());

    public static IRuleBuilderOptions<T, string> MustNotContainHtml<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new NoHtmlValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeSafeFileName<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new SafeFileNameValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeHostnameWithPort<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new HostnameWithPortValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeIPv6Address<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IPv6AddressValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeDomainName<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new DomainNameValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeValidTimeZone<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new TimeZoneIdValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeValidCultureCode<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new CultureCodeValidator<T>());

    public static IRuleBuilderOptions<T, string> MustBeValidLanguageTag<T>(
        this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new LanguageTagValidator<T>());

    public static IRuleBuilderOptions<T, TProperty> RequiredIf<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, Func<T, bool> condition) =>
        ruleBuilder.SetValidator(new RequiredIfValidator<T, TProperty>(condition));

    public static IRuleBuilderOptions<T, TProperty> DisallowedIf<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder, Func<T, bool> condition) =>
        ruleBuilder.SetValidator(new DisallowedIfValidator<T, TProperty>(condition));

    public static IRuleBuilderOptions<T, IComparable> MustSatisfyComparison<T>(
        this IRuleBuilder<T, IComparable> ruleBuilder,
        Func<T, IComparable> otherSelector,
        Func<IComparable, IComparable, bool> comparer) =>
        ruleBuilder.SetValidator(new CompareWithOtherPropertyValidator<T>(otherSelector, comparer));

    public static IRuleBuilderOptions<T, TProperty> MustBeNull<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder) =>
        ruleBuilder.SetValidator(new NullValidator<T, TProperty>());

    public static IRuleBuilderOptions<T, TProperty> MustNotBeNull<T, TProperty>(
        this IRuleBuilder<T, TProperty> ruleBuilder) =>
        ruleBuilder.SetValidator(new NotNullOverrideValidator<T, TProperty>());

    public static IRuleBuilderOptions<T, TValue> MustBeConstant<T, TValue>(
        this IRuleBuilder<T, TValue> ruleBuilder, TValue expected) =>
        ruleBuilder.SetValidator(new ConstantValueValidator<T, TValue>(expected));

}
