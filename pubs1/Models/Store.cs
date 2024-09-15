
#nullable disable
using System;
using System.Collections.Generic;

namespace pubs1.Models;

public partial class Store
{
    public string StorId { get; set; }

    public string StorName { get; set; }

    public string StorAddress { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string Zip { get; set; }
}