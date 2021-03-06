using System.ComponentModel.DataAnnotations;

namespace AvcolForms.Core.Options;

#nullable disable

/// <summary>
/// Options for the privacy policy
/// </summary>
public class PrivacyOptions
{
    /// <summary>
    /// The file name that the privacy policy is stored in
    /// </summary>
    [Required]
    public string FileName { get; set; }
}
