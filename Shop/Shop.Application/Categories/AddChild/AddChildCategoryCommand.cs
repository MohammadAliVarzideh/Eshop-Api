using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.AddChild
{
    public record AddChildCategoryCommand(long ParentId, string title, string slug, SeoData SeoData) : IBaseCommand;

}
