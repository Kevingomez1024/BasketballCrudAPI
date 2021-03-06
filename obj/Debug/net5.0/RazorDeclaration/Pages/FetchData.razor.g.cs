// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BasketballCrudAPI.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using BasketballCrudAPI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/kevingomez/Projects/BasketballCrudAPI/_Imports.razor"
using BasketballCrudAPI.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/kevingomez/Projects/BasketballCrudAPI/Pages/FetchData.razor"
using BasketballCrudAPI.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/kevingomez/Projects/BasketballCrudAPI/Pages/FetchData.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/getplayers")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 101 "/Users/kevingomez/Projects/BasketballCrudAPI/Pages/FetchData.razor"
       
    private List<Player> Roster;


    protected override async Task OnInitializedAsync()
    {

        try
        {
            Roster = await Http.GetFromJsonAsync<List<Player>>($"{Navigator.BaseUri}api/players");

        }
        catch
        {
            System.Console.WriteLine("Players didn't load whatsoever");
        }
    }

    async Task DeleteSymbol(string Id)
    {
        bool confirmed = await JsRuntime.InvokeAsync<bool>("confirm", "Are you sure?");
        if (confirmed)
        {
            await Http.DeleteAsync($"{Navigator.BaseUri}api/players/{Id}");
            Roster = await Http.GetFromJsonAsync<List<Player>>($"{Navigator.BaseUri}api/players");
        }
    }

    private void EnableEditing(bool flag, Player player)
    {
        player.IsEditing = flag;

    }

    private async Task UpdatePlayer(Player player)
    {
        EnableEditing(false, player);
        var putBody = new { id = player.Id, name = player.Name, number = player.Number, position = player.Position, points = player.Points, assists = player.Assists, rebounds = player.Rebounds };
        using var response = await Http.PutAsJsonAsync($"{Navigator.BaseUri}api/players/{player.Id}", putBody);
        Roster = await Http.GetFromJsonAsync<List<Player>>($"{Navigator.BaseUri}api/players");

    }






#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager Navigator { get; set; }
    }
}
#pragma warning restore 1591
