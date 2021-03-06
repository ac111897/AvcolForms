using System.ComponentModel.DataAnnotations;

namespace AvcolForms.Core.Options;

#nullable disable

/// <summary>
/// Email settings used for the application
/// </summary>
public class EmailOptions
{
    /// <summary>
    /// The email address that sends the email
    /// </summary>
    [EmailAddress]
    public string FromEmail { get; set; }

    /// <summary>
    /// The network port that the server connects to
    /// </summary>
    [Range(0, ushort.MaxValue)]
    public int Port { get; set; }

    /// <summary>
    /// The name of the sender
    /// </summary>
    public string SenderName { get; set; }

    /// <summary>
    /// The smtp server being used for the connection
    /// </summary>
    public string SmtpServer { get; set; }

    /// <summary>
    /// The smtp user name
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The password for smtp authentication
    /// </summary>
    public string Password { get; set; }
}
