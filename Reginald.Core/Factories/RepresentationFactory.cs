﻿using Reginald.Core.AbstractFactories;
using Reginald.Core.AbstractProducts;
using Reginald.Core.DataModels;
using Reginald.Core.Products;
using System;

namespace Reginald.Core.Factories
{
    public class RepresentationFactory : ProcessedInputFactory
    {
        public override Representation CreateRepresentation(InputDataModelBase model)
        {
            Type type = model.GetType();
            return type switch
            {
                Type when type == typeof(CalculatorDataModel) => new Calculator(model),
                Type when type == typeof(LinkDataModel) => new Link(model),
                _ => null,
            };
        }
    }
}