using Common.Domain;
using Common.Domain.Execptions;

namespace Shop.Domain.CommentAgg
{
    public class Comment : AggregateRoot
    {
        public Comment(long userId, long productId, string text)
        {
            NullOrEmptyDomainDataException.CheckString(text, nameof(text));
            UserId = userId;
            ProductId = productId;
            Text = text;
            Status = CommentStatus.Pennding;
        }

        public long UserId { get; set; }
        public long ProductId { get; set; }
        public string Text { get; set; }

        public DateTime? UpdateDate { get; set; }
        public CommentStatus Status { get; set; }

        public void Edit(string text)
        {
            Text = text;
        }

        public void ChangeStatus(CommentStatus status)
        {
            Status = status;
            UpdateDate = DateTime.Now;
        }


    }

    public enum CommentStatus
    {
        Pennding,
        Accepted,
        Rejected
    }
}
