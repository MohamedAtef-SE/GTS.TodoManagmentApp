using GTS.TodoApp.Core.Domain.Entities;

namespace GTS.TodoApp.Core.Application.Specifications
{
    public class TodoSpecifications : BaseSpecification<Todo,Guid>
    {
        public TodoSpecifications(SpecParams specParams) 
        :
        base(
            todo => (String.IsNullOrEmpty(specParams.Title) || todo.Title.Contains(specParams.Title))
                    &&
                    (String.IsNullOrEmpty(specParams.Status) || todo.Status.Equals(specParams.Status))
                    &&
                    (String.IsNullOrEmpty(specParams.Priority) || todo.Priority.Equals(specParams.Priority))
            )
        {
            SortedBy(specParams.Sort);
        }

       
        public override void SortedBy(string? sort)
        {
            switch (sort)
            {
                case "lastModifiedDate":
                    OrderBy = todo => todo.LastModifiedDate;
                    break;
                case "lastModifiedDateDesc":
                    OrderByDesc = todo => todo.LastModifiedDate;
                    break;
                case "priority":
                    OrderBy = todo => todo.Priority;
                    break;
                case "priorityDesc":
                    OrderByDesc = todo => todo.Priority;
                    break;
                case "status":
                    OrderBy = todo => todo.Status;
                    break;
                case "statusDesc":
                    OrderByDesc = todo => todo.Status;
                    break;
                case "createdDate":
                    OrderBy = todo => todo.CreatedDate;
                    break;
                case "createdDateDesc":
                default:
                    OrderByDesc = todo => todo.CreatedDate;
                    break;
            }
        }
    }
}
