﻿using SportsStore.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
   public  interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDtails shippingDtails);
    }
}