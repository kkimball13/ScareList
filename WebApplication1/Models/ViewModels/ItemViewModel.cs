﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.ViewModels
{
    public class ItemViewModel<T> 
    {
    public T Item { get; set; }
    }
}