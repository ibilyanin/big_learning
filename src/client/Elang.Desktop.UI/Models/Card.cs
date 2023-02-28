using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Elang.Desktop.UI.Models;
internal class Card
{
    public long Id { get; init; }
    public string English { get; set; }
    public string Type { get; set; }
    public string Translation { get; set; }
    public string? ContextDescription { get; set; }
    public List<long> Topics { get; set; }
}

