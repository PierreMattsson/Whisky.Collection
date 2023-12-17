using System.ComponentModel.DataAnnotations;

namespace Whisky.Collection.BlazorUI.Models.MyWhiskys;

public class MyWhiskyVM
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name of the Producer")]
    public string ProducerName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Name of the whisky")]
    public string WhiskyName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "How old is the whisky")]
    public int WhiskyYearStatement { get; set; }

    [Required]
    [Display(Name = "Discription of the bottle")]
    public string BottleDescription { get; set; } = string.Empty;

    [Required]
    [Display(Name = "How many procent of alkohol")]
    public double AlkoholProcent { get; set; }

    [Required]
    [Display(Name = "Bottle in milliliter")]
    public int BottleContentMilliliter { get; set; }
}
