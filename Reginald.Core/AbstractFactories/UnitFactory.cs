﻿using Reginald.Core.AbstractProducts;
using Reginald.Core.DataModels;

namespace Reginald.Core.AbstractFactories
{
    public abstract class UnitFactory
    {
        public abstract Unit CreateUnit(UnitDataModelBase model);
    }
}