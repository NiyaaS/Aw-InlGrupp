using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace graph_tutorial.ViewModels
{
  public class CreateNewItems
  {
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid")]
    public string Title { get; set; }
    [Required]
    public DateTime Time { get; set; }
    [StringLength(400, MinimumLength = 10, ErrorMessage = "Invalid")]
    public string Description { get; set; }
    [Required]
    public string Address { get; set; }
  }
}
