using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id, string title, string slug, SeoData SeoData) : IBaseCommand;

}
