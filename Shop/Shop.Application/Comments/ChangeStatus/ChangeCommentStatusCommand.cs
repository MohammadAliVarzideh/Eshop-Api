using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.ChangeStatus
{
    public record ChangeCommentStatusCommand(long Id, CommentStatus status):IBaseCommand;

}
