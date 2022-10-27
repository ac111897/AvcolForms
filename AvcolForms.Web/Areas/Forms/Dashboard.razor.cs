﻿using AvcolForms.Web.Areas.Forms.ViewModel;
using Microsoft.AspNetCore.Components.Authorization;

namespace AvcolForms.Web.Areas.Forms;

[Route(Routes.Forms.Dash)]
public partial class Dashboard
{
#nullable disable
    private List<UnansweredFormItem> _forms;

    [Inject]
    private NavigationManager NavManager { get; set; }

    [Inject]
    public IDbContextFactory<ApplicationDbContext> Factory { get; set; }

    [CascadingParameter]
    [Inject]
    public AuthenticationStateProvider AuthState { get; set; }

    [Inject]
    public UserManager<ApplicationUser> UserManager { get; set; }
#nullable restore

    private readonly List<BreadcrumbItem> _items = new()
    {
        new("Forms", href: null, disabled: true, icon: Icons.Material.Filled.Forum),
        new("Dashboard", href: null, disabled: true, icon: Icons.Material.Filled.Dashboard)
    };

    protected override async Task OnInitializedAsync()
    {
        var state = await AuthState.GetAuthenticationStateAsync();

        var user = await UserManager.GetUserAsync(state.User);

        if (user is null)
        {
            NavManager.NavigateTo(Routes.Accounts.Login, true);
            return;
        }

        using var context = await Factory.CreateDbContextAsync();

        _forms = await context.Forms
            .Where(f => f.TimeLeft != TimeSpan.Zero || f.Closes == null && f.Recipients.Contains(user))
            .Select(f => new UnansweredFormItem()
            {
                ContentCount = f.Recipients.Count,
                Id = f.Id,
                Title = f.Title,
                EndDate = f.Closes
            })
            .ToListAsync();
    }
}
