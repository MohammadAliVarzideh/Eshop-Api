using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Application;
using Microsoft.VisualBasic;

namespace Shop.Application.Comments.Create
{
    public record CreateCommentCommand(string Text, long UserId, long ProductId) : IBaseCommand;
}
