using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Conference.Api.Models;

public class MyModel
{
    [BindNever] public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}