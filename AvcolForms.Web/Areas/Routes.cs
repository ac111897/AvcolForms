﻿namespace AvcolForms.Web.Areas;

internal static class Routes
{
    public const string Home = "#";

    internal static class Admin
    {
        internal const string Base = "/admin";
        internal const string Dash = $"{Base}/dash";
        internal const string Users = $"{Base}/users";
    }
    internal static class Accounts
    {
        public const string Account = "/account";

        public const string AuthenticateLogin = $"{Account}/authenticate_login";
        public const string Login = $"{Account}/login";
        public const string Register = $"{Account}/register";
        public const string EmailConfirmGet = $"{Account}/authenticate_email";
        public const string ConfirmEmailPage = $"{Account}/confirm_email";
        public const string ResendConfirmation = $"{Account}/resend_email";
        public const string EmailConfirmedPage = $"{Account}/email_confirmed";
        public const string Logout = $"{Account}/logout";
        public const string LogoutPage = $"{Account}/logged_out";
        public const string ForgotPassword = $"{Account}/forgot_password";
        public const string ChangeForgotPassword = $"{Account}/reset_password";
    }
}
